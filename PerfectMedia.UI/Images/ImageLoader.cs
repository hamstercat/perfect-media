// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageLoader.cs" company="Bryan A. Woodruff">
//   Copyright (c) 2011 Bryan A. Woodruff.
// </copyright>
// <summary>
//   The ImageLoader class is a derived class of System.Windows.Controls.Image.
//   It uses BitmapImage as a source to load the associated ImageUri and displays
//   an initial image in place until the image load has completed.
// </summary>
// <license>
//   Microsoft Public License (Ms-PL)
//
//   This license governs use of the accompanying software. If you use the software, you accept this license.
//   If you do not accept the license, do not use the software.
//
//   * Definitions
//   The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here
//   as under U.S. copyright law. A "contribution" is the original software, or any additions or changes to the
//   software. A "contributor" is any person that distributes its contribution under this license.
//   "Licensed patents" are a contributor's patent claims that read directly on its contribution.
//
//   * Grant of Rights
//   (A) Copyright Grant- Subject to the terms of this license, including the license conditions and
//       limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright
//       license to  reproduce its contribution, prepare derivative works of its contribution, and distribute its
//       contribution  or any derivative works that you create.
//   (B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in
//       section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its
//       licensed  patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its
//       contribution in the software or derivative works of the contribution in the software.
//
//   * Conditions and Limitations
//   (A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or
//       trademarks.
//   (B) If you bring a patent claim against any contributor over patents that you claim are infringed by the
//       software, your patent license from such contributor to the software ends automatically.
//   (C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and
//       attribution notices that are present in the software.
//   (D) If you distribute any portion of the software in source code form, you may do so only under this license
//       by including a complete copy of this license with your distribution. If you distribute any portion of the
//       software in compiled or object code form, you may only do so under a license that complies with this
//       license.
//   (E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties,
//       guarantees, or conditions. You may have additional consumer rights under your local laws which this license
//       cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties
//       of merchantability, fitness for a particular purpose and non-infringement.
// </license>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Net.Cache;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PerfectMedia.UI.Images
{
    /// <summary>
    /// Defines the ImageLoader class, derived from System.Windows.Controls.Image.
    /// </summary>
    public class ImageLoader : System.Windows.Controls.Image
    {
        /// <summary>
        /// The ImageUri dependency property.
        /// </summary>
        public static readonly DependencyProperty ImageUriProperty = DependencyProperty.Register("ImageUri", typeof(string), typeof(ImageLoader), new PropertyMetadata(null, OnImageUriChanged));
        private static void OnImageUriChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var imageLoader = (ImageLoader)d;
            if (e.NewValue != e.OldValue)
            {
                imageLoader._retryCount = 0;
                imageLoader.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the ImageUri property.
        /// </summary>
        public string ImageUri
        {
            get { return (string)GetValue(ImageUriProperty); }
            set { SetValue(ImageUriProperty, value); }
        }

        /// <summary>
        /// The WidthRatio dependency property.
        /// </summary>
        public static readonly DependencyProperty WidthRatioProperty = DependencyProperty.Register("WidthRatio", typeof(double), typeof(ImageLoader), new PropertyMetadata(0d, OnRatioChanged));
        private static void OnRatioChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var imageLoader = (ImageLoader)d;
            imageLoader.LoadInitialImage();
        }

        /// <summary>
        /// Gets or sets the width ratio.
        /// </summary>
        public double WidthRatio
        {
            get { return (double)GetValue(WidthRatioProperty); }
            set { SetValue(WidthRatioProperty, value); }
        }

        /// <summary>
        /// The HeightRatio dependency property.
        /// </summary>
        public static readonly DependencyProperty HeightRatioProperty = DependencyProperty.Register("HeightRatio", typeof(double), typeof(ImageLoader), new PropertyMetadata(0d, OnRatioChanged));

        /// <summary>
        /// Gets or sets the height ratio.
        /// </summary>
        public double HeightRatio
        {
            get { return (double)GetValue(HeightRatioProperty); }
            set { SetValue(HeightRatioProperty, value); }
        }

        /// <summary>
        /// Gets or sets the source property which forwards to the base Image class.
        /// This is made an internal property in ImageLoader to prevent confusion with the base class.
        /// This property is managed as a result of the bitmap load operations.
        /// </summary>
        private new ImageSource Source
        {
            get { return base.Source; }
            set { base.Source = value; }
        }

        /// <summary>
        /// Storage for the loaded image.
        /// </summary>
        private BitmapImage _loadedImage;

        /// <summary>
        /// Number of times an image has failed to load in a refresh.
        /// </summary>
        private int _retryCount;

        /// <summary>
        /// True if the image from ImageUri has been loaded.
        /// </summary>
        private bool _imageLoaded;

        /// <summary>
        /// Handles the download failure event.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void OnDownloadFailed(object sender, ExceptionEventArgs e)
        {
            if (_retryCount < 2)
            {
                Refresh();
            }
        }

        /// <summary>
        /// Handles the DownloadCompleted event.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void OnDownloadCompleted(object sender, EventArgs e)
        {
            _imageLoaded = true;
            Source = _loadedImage;
        }

        private void Refresh()
        {
            _imageLoaded = false;
            if (!string.IsNullOrEmpty(ImageUri) && PathIsValid(ImageUri))
            {
                _retryCount++;
                LoadImage();

                // The image may be cached, in which case we will not use the initial image
                if (!_loadedImage.IsDownloading)
                {
                    _imageLoaded = true;
                    Source = _loadedImage;
                }
                else
                {
                    LoadInitialImage();
                }
            }
            else
            {
                LoadInitialImage();
            }
        }

        private bool PathIsValid(string imagePath)
        {
            return IsPathAnUrl(imagePath) || FileExists(imagePath);
        }

        private bool IsPathAnUrl(string path)
        {
            return path.StartsWith("http://") || path.StartsWith("https://");
        }

        private static bool FileExists(string imagePath)
        {
            var file = new FileInfo(imagePath);
            return file.Exists && file.Length > 0;
        }

        private void LoadImage()
        {
            _loadedImage = new BitmapImage();
            _loadedImage.BeginInit();
            _loadedImage.CacheOption = BitmapCacheOption.OnLoad;
            _loadedImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache | BitmapCreateOptions.IgnoreColorProfile;
            _loadedImage.UriCachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
            _loadedImage.DownloadCompleted += OnDownloadCompleted;
            _loadedImage.DownloadFailed += OnDownloadFailed;
            _loadedImage.UriSource = new Uri(ImageUri);
            _loadedImage.EndInit();
        }

        private void LoadInitialImage()
        {
            if (!_imageLoaded)
            {
                // Set the initial image as the image source
                Source = CreateInitialImage();
            }
        }

        private DrawingImage CreateInitialImage()
        {
            var geometryGroup = new GeometryGroup();
            geometryGroup.Children.Add(
                new RectangleGeometry(new Rect(0, 0, WidthRatio, HeightRatio))
            );
            var geometryDrawing = new GeometryDrawing
            {
                Geometry = geometryGroup,
                Brush = new SolidColorBrush(Colors.LightGray)
            };
            var image = new DrawingImage(geometryDrawing);
            image.Freeze();
            return image;
        }
    }
}
