using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace CounterStats.UI.Views.Elements
{
    /// <summary>
    /// Interaction logic for FourColumnRow.xaml
    /// </summary>
    public partial class FourColumnRow : UserControl
    {
        #region Column Declarations
        public static readonly DependencyProperty ColumnOneProperty
              = DependencyProperty.Register("ColumnOne", typeof(UIElement), typeof(FourColumnRow),
                        new FrameworkPropertyMetadata(SetColumnContent));
        
        public static readonly DependencyProperty ColumnTwoProperty
            = DependencyProperty.Register("ColumnTwo", typeof(UIElement), typeof(FourColumnRow),
                new FrameworkPropertyMetadata(SetColumnContent));
        
        public static readonly DependencyProperty ColumnThreeProperty
            = DependencyProperty.Register("ColumnThree", typeof(UIElement), typeof(FourColumnRow),
                new FrameworkPropertyMetadata(SetColumnContent));
        
        public static readonly DependencyProperty ColumnFourProperty
            = DependencyProperty.Register("ColumnFour", typeof(UIElement), typeof(FourColumnRow),
                new FrameworkPropertyMetadata(SetColumnContent));
        #endregion

        #region Column Properties
        public UIElement ColumnOne
        {
            get
            {
                return (UIElement)GetValue(ColumnOneProperty);
            }
            set
            {
                SetValue(ColumnOneProperty, value);
            }
        }

        public UIElement ColumnTwo
        {
            get
            {
                return (UIElement)GetValue(ColumnTwoProperty);
            }
            set
            {
                SetValue(ColumnTwoProperty, value);
            }
        }
        
        public UIElement ColumnThree
        {
            get
            {
                return (UIElement)GetValue(ColumnThreeProperty);
            }
            set
            {
                SetValue(ColumnThreeProperty, value);
            }
        }
        
        public UIElement ColumnFour
        {
            get
            {
                return (UIElement)GetValue(ColumnFourProperty);
            }
            set
            {
                SetValue(ColumnFourProperty, value);
            }
        }

        #endregion

        private static void SetColumnContent(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var value = e.NewValue as UIElement;
            var page = source as FourColumnRow;

            if (page == null)
            {
                throw new FileFormatException("Wrong Element");
            }

            switch (e.Property.Name)
            {
                case "ColumnOne":
                    page.ColumnOneContent.Content = value;
                    break;
                case "ColumnTwo":
                    page.ColumnTwoContent.Content = value;
                    break;
                case "ColumnThree":
                    page.ColumnThreeContent.Content = value;
                    break;
                case "ColumnFour":
                    page.ColumnFourContent.Content = value;
                    break;
            }
        }
        
        public FourColumnRow()
        {
            InitializeComponent();
        }
    }
}
