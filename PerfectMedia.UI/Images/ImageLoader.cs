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
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PerfectMedia.UI.Images
{
    /// <summary>
    /// Defines the ImageLoader class, derived from System.Windows.Controls.Image
    /// </summary>
    public class ImageLoader : System.Windows.Controls.Image
    {
        /// <summary>
        /// The ImageUri dependency property.
        /// </summary>
        public static readonly DependencyProperty ImageUriProperty = DependencyProperty.Register("ImageUri", typeof(string), typeof(ImageLoader), new PropertyMetadata(null, OnImageUriChanged));
        private static void OnImageUriChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ImageLoader imageLoader = (ImageLoader)d;
            imageLoader.RetryCount = 0;
            imageLoader.Refresh();
        }

        /// <summary>
        /// Storage for the loaded image.
        /// </summary>
        private BitmapImage _loadedImage;

        /// <summary>
        /// Gets or sets the ImageUri property.
        /// </summary>
        public string ImageUri
        {
            get { return GetValue(ImageUriProperty) as string; }
            set { SetValue(ImageUriProperty, value); }
        }

        /// <summary>
        /// Gets or sets the initial image path string.
        /// </summary>
        public string InitialImage{get;set;}

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
        /// Gets or sets the number of times an image has failed to load in a refresh.
        /// </summary>
        public int RetryCount { get; set; }

        /// <summary>
        /// Handles the download failure event.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void OnDownloadFailed(object sender, ExceptionEventArgs e)
        {
            if (RetryCount < 2)
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
            Source = _loadedImage;
        }

        private void Refresh()
        {
            if (ImageUri != null && PathIsValid(ImageUri))
            {
                RetryCount++;
                LoadImage();

                // The image may be cached, in which case we will not use the initial image
                if (!_loadedImage.IsDownloading)
                {
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
            return (IsPathAnUrl(imagePath) || File.Exists(imagePath));
        }

        private bool IsPathAnUrl(string path)
        {
            return path.StartsWith("http://") || path.StartsWith("https://");
        }

        private void LoadImage()
        {
            _loadedImage = new BitmapImage();
            _loadedImage.BeginInit();
            _loadedImage.CacheOption = BitmapCacheOption.OnLoad;
            _loadedImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            _loadedImage.DownloadCompleted += OnDownloadCompleted;
            _loadedImage.DownloadFailed += OnDownloadFailed;
            _loadedImage.UriSource = new Uri(ImageUri);
            _loadedImage.EndInit();
        }

        private void LoadInitialImage()
        {
            if (!string.IsNullOrWhiteSpace(InitialImage))
            {
                BitmapImage initialImage = new BitmapImage();

                // Load the initial bitmap from the local resource
                initialImage.BeginInit();
                initialImage.UriSource = new Uri(InitialImage, UriKind.Relative);
                initialImage.DecodePixelWidth = (int)ActualWidth;
                initialImage.EndInit();

                // Set the initial image as the image source
                Source = initialImage;
            }
        }
    }
}
