﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PerfectMedia.UI.Images
{
    /// <summary>
    /// Interaction logic for ImageSelection.xaml
    /// </summary>
    public partial class ImageSelection : UserControl
    {
        public static readonly DependencyProperty OriginalContentProperty = DependencyProperty.Register("OriginalContent", typeof(Control), typeof(SelectableImage));
        public Control OriginalContent
        {
            get { return (Control)base.GetValue(OriginalContentProperty); }
            set { base.SetValue(OriginalContentProperty, value); }
        }

        public ImageSelection()
        {
            InitializeComponent();
        }
    }
}
