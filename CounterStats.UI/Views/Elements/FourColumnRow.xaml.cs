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
              = DependencyProperty.Register("ColumnOne", typeof(Control), typeof(FourColumnRow),
                        new FrameworkPropertyMetadata(SetColumnContent));
        
        public static readonly DependencyProperty ColumnTwoProperty
            = DependencyProperty.Register("ColumnTwo", typeof(Control), typeof(FourColumnRow),
                new FrameworkPropertyMetadata(SetColumnContent));
        
        public static readonly DependencyProperty ColumnThreeProperty
            = DependencyProperty.Register("ColumnThree", typeof(Control), typeof(FourColumnRow),
                new FrameworkPropertyMetadata(SetColumnContent));
        
        public static readonly DependencyProperty ColumnFourProperty
            = DependencyProperty.Register("ColumnFour", typeof(Control), typeof(FourColumnRow),
                new FrameworkPropertyMetadata(SetColumnContent));
        #endregion

        #region Column Properties
        public Control ColumnOne
        {
            get
            {
                return (Control)GetValue(ColumnOneProperty);
            }
            set
            {
                SetValue(ColumnOneProperty, value);
            }
        }

        public Control ColumnTwo
        {
            get
            {
                return (Control)GetValue(ColumnTwoProperty);
            }
            set
            {
                SetValue(ColumnTwoProperty, value);
            }
        }
        
        public Control ColumnThree
        {
            get
            {
                return (Control)GetValue(ColumnThreeProperty);
            }
            set
            {
                SetValue(ColumnThreeProperty, value);
            }
        }
        
        public Control ColumnFour
        {
            get
            {
                return (Control)GetValue(ColumnFourProperty);
            }
            set
            {
                SetValue(ColumnFourProperty, value);
            }
        }

        #endregion

        private static void SetColumnContent(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var value = e.NewValue as Control;
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
