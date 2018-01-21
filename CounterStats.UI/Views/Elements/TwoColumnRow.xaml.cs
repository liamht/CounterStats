using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace CounterStats.UI.Views.Elements
{
    public partial class TwoColumnRow : UserControl
    {
        #region Column Declarations
        public static readonly DependencyProperty ColumnOneProperty
              = DependencyProperty.Register("ColumnOne", typeof(Control), typeof(TwoColumnRow),
                        new FrameworkPropertyMetadata(SetColumnContent));
        
        public static readonly DependencyProperty ColumnTwoProperty
            = DependencyProperty.Register("ColumnTwo", typeof(Control), typeof(TwoColumnRow),
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
        

        #endregion

        private static void SetColumnContent(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var value = e.NewValue as Control;
            var page = source as TwoColumnRow;

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
            }
        }
        
        public TwoColumnRow()
        {
            InitializeComponent();
        }
    }
}
