using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
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

namespace Iconizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<String> IconNames = new List<String>();
        public List<PackIconKind> IconKinds = new List<PackIconKind>();
        public int iIconFrom = 0;
        public int iIconTo = 0;
        public List<String> ColorNames = new List<String>();
        public List<SolidColorBrush> ColorBrushes = new List<SolidColorBrush>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cboParent.Text == "None")
                {
                    iconOnly.Visibility = Visibility.Visible;
                    btnCircle.Visibility = Visibility.Collapsed;
                    btnSquare.Visibility = Visibility.Collapsed;

                    iconOnly.Kind = (PackIconKind)Enum.Parse(typeof(PackIconKind), txtIconKind.Text);
                    iconOnly.Width = double.Parse(txtIconWidth.Text);
                    iconOnly.Height = double.Parse(txtIconHeight.Text);
                    iconOnly.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(cboIconColor.Text);
                }
                else if (cboParent.Text == "Button")
                {
                    iconOnly.Visibility = Visibility.Collapsed;
                    btnCircle.Visibility = Visibility.Collapsed;
                    btnSquare.Visibility = Visibility.Collapsed;

                    if (cboParentStyle.Text == "Circle")
                    {
                        btnCircle.Visibility = Visibility.Visible;
                        if (cboParColor.Text != "")
                        {
                            btnCircle.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(cboParColor.Text);
                            btnCircle.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(cboParColor.Text);
                        }
                        if (txtParWidth.Text != "")
                        {
                            btnCircle.Width = double.Parse(txtParWidth.Text);
                        }
                        if (txtParHeight.Text != "")
                        {
                            btnCircle.Height = double.Parse(txtParHeight.Text);
                        }
                        iconCircle.Kind = (PackIconKind)Enum.Parse(typeof(PackIconKind), txtIconKind.Text);
                        iconCircle.Width = double.Parse(txtIconWidth.Text);
                        iconCircle.Height = double.Parse(txtIconHeight.Text);
                        iconCircle.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(cboIconColor.Text);
                        btnCircle.Style = null;                        
                        btnCircle.Style = (Style)Application.Current.Resources["MaterialDesignFloatingActionMiniButton"];
                    } else
                    {
                        btnSquare.Visibility = Visibility.Visible;
                        if (cboParColor.Text != "")
                        {
                            btnSquare.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(cboParColor.Text);
                            btnSquare.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(cboParColor.Text);
                        }
                        if (txtParWidth.Text != "")
                        {
                            btnSquare.Width = double.Parse(txtParWidth.Text);
                        }
                        if (txtParHeight.Text != "")
                        {
                            btnSquare.Height = double.Parse(txtParHeight.Text);
                        }
                        iconSquare.Kind = (PackIconKind)Enum.Parse(typeof(PackIconKind), txtIconKind.Text);
                        iconSquare.Width = double.Parse(txtIconWidth.Text);
                        iconSquare.Height = double.Parse(txtIconHeight.Text);
                        iconSquare.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(cboIconColor.Text);
                    }
                }
                if (cboBackColor.Text != "")
                {
                    grdBack.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(cboBackColor.Text);
                } else
                {
                    grdBack.Background = null;
                }
            } catch (Exception ex)
            {
                ex.ToString();
            }            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sdg = new SaveFileDialog();
            sdg.Filter = "PNG file | *.png";
            if (sdg.ShowDialog() == true)
            {
                try
                {
                    WriteToPng(pnlObj, sdg.FileName);
                    MessageBox.Show("Save PNG done.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Save PNG failed ! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void WriteToPng(UIElement element, string filename)
        {
            var rect = new Rect(element.RenderSize);
            var visual = new DrawingVisual();

            using (var dc = visual.RenderOpen())
            {
                dc.DrawRectangle(new VisualBrush(element), null, rect);
            }

            var bitmap = new RenderTargetBitmap(
                (int)rect.Width, (int)rect.Height, 96, 96, PixelFormats.Default);
            bitmap.Render(visual);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using (var file = File.OpenWrite(filename))
            {
                encoder.Save(file);
            }
        }
             
        public static void SaveAsIcon(Bitmap SourceBitmap, string FilePath)
        {
            FileStream FS = new FileStream(FilePath, FileMode.Create);
            // ICO header
            FS.WriteByte(0); FS.WriteByte(0);
            FS.WriteByte(1); FS.WriteByte(0);
            FS.WriteByte(1); FS.WriteByte(0);

            // Image size
            // Set to 0 for 256 px width/height
            FS.WriteByte(0);
            FS.WriteByte(0);
            // Palette
            FS.WriteByte(0);
            // Reserved
            FS.WriteByte(0);
            // Number of color planes
            FS.WriteByte(1); FS.WriteByte(0);
            // Bits per pixel
            FS.WriteByte(32); FS.WriteByte(0);

            // Data size, will be written after the data
            FS.WriteByte(0);
            FS.WriteByte(0);
            FS.WriteByte(0);
            FS.WriteByte(0);

            // Offset to image data, fixed at 22
            FS.WriteByte(22);
            FS.WriteByte(0);
            FS.WriteByte(0);
            FS.WriteByte(0);

            // Writing actual data
            SourceBitmap.Save(FS, System.Drawing.Imaging.ImageFormat.Png);

            // Getting data length (file length minus header)
            long Len = FS.Length - 22;

            // Write it in the correct place
            FS.Seek(14, SeekOrigin.Begin);
            FS.WriteByte((byte)Len);
            FS.WriteByte((byte)(Len >> 8));

            FS.WriteByte((byte)(Len >> 16));
            FS.WriteByte((byte)(Len >> 24));

            FS.Close();
        }

        private void btnSaveIco_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sdg = new SaveFileDialog();
            sdg.Filter = "ICO file | *.ico";
            if (sdg.ShowDialog() == true)
            {
                try
                {
                    string sfile_ = sdg.FileName + "_";
                    
                    //create temp file
                    WriteToPng(pnlObj, sfile_);

                    System.Drawing.Image iconfile = System.Drawing.Image.FromFile(sfile_);
                    //Returns a correctly resized Bitmap        
                    Bitmap bm = ResizeImage(iconfile, 256, 256);
                    SaveAsIcon(bm, sdg.FileName);

                    iconfile.Dispose();
                    //delete temp file
                    File.Delete(sfile_);

                    MessageBox.Show("Save ICO done.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Save ICO failed ! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new System.Drawing.Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void btnBrowseIcon_Click(object sender, RoutedEventArgs e)
        {
            grdIcons.Visibility = Visibility.Visible;            
            IconKinds.Clear();
            IconNames.Clear();
            foreach (PackIconKind ick in Enum.GetValues(typeof(PackIconKind)))
            {
                IconKinds.Add(ick);                
                IconNames.Add(ick.ToString());
            }

            ListIcons(0);
        }

        private void ListIcons(int ifrom)
        {
            lsvIcons.Items.Clear();
            int ito = ifrom + 99;
            int ilast = ito;
            for (int i = ifrom; i <= ito; i++)
            {
                if (i < IconNames.Count)
                {
                    StackPanel pan = new StackPanel();
                    pan.Orientation = Orientation.Horizontal;
                    PackIcon ic = new PackIcon();
                    ic.Kind = IconKinds[i];
                    ic.Width = 35;
                    TextBlock txb = new TextBlock();
                    txb.Text = IconNames[i];
                    txb.VerticalAlignment = VerticalAlignment.Center;
                    pan.Children.Add(ic);
                    pan.Children.Add(txb);
                    lsvIcons.Items.Add(pan);
                } else
                {
                    ilast = i;                    
                }     
            }
            iIconFrom = ifrom;
            iIconTo = ilast;
            if (ilast < ito)
            {
                btnNextIcons.IsEnabled = false;
            } else
            {
                btnNextIcons.IsEnabled = true;
            }
            if (ifrom <= 0)
            {
                btnPrevIcons.IsEnabled = false;
            } else
            {
                btnPrevIcons.IsEnabled = true;
            }
        }

        private void btnCloseIcon_Click(object sender, RoutedEventArgs e)
        {
            grdIcons.Visibility = Visibility.Collapsed;
        }

        private void lsvIcons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idx = lsvIcons.SelectedIndex;
            if (idx < 0) return;
            int idc = idx + iIconFrom;
            txtIconKind.Text = IconKinds[idc].ToString();
            lsvIcons.ScrollIntoView(lsvIcons.SelectedItem);
        }

        private void btnNextIcons_Click(object sender, RoutedEventArgs e)
        {
            ListIcons(iIconTo + 1);
        }

        private void btnPrevIcons_Click(object sender, RoutedEventArgs e)
        {
            ListIcons(iIconFrom - 100);
        }

        private void btnFindIcons_Click(object sender, RoutedEventArgs e)
        {
            int idx = IconNames.IndexOf(txtFindIcon.Text);
            if (idx >= 0)
            {
                int idf = idx / 100;
                ListIcons(idf*100);
                int ids = idx % 100;
                lsvIcons.SelectedIndex = ids;                
            }
        }

        private void lsvColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCloseColor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBrowseColor_Click(object sender, RoutedEventArgs e)
        {
            grdColors.Visibility = Visibility.Visible;
            ColorNames.Clear();
            ColorBrushes.Clear();
            foreach (SolidColorBrush br in Enum.GetValues(typeof(SolidColorBrush)))
            {
                ColorBrushes.Add(br);
                ColorNames.Add(br.ToString());
            }
            ListColors();
        }

        private void ListColors()
        {
            int ifrom = 0;
            int ito = ColorNames.Count - 1;
            lsvIcons.Items.Clear();
            for (int i = ifrom; i <= ito; i++)
            {
                StackPanel pan = new StackPanel();
                pan.Orientation = Orientation.Horizontal;
                Button bt = new Button();
                bt.Background = ColorBrushes[i];
                bt.BorderBrush = System.Windows.Media.Brushes.Transparent;
                bt.Width = 35;
                TextBlock txb = new TextBlock();
                txb.Text = ColorNames[i];
                txb.VerticalAlignment = VerticalAlignment.Center;
                pan.Children.Add(bt);
                pan.Children.Add(txb);
                lsvIcons.Items.Add(pan);
            }            
        }
    }
}
