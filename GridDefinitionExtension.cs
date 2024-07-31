using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows;

namespace XamlShortening
{
    public static class GridDefinitionExtension
    {
        public static readonly DependencyProperty RowsProperty = DependencyProperty.RegisterAttached(
            "Rows", typeof(string), typeof(GridDefinitionExtension), new PropertyMetadata(null, OnRowsChanged));

        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.RegisterAttached(
            "Columns", typeof(string), typeof(GridDefinitionExtension), new PropertyMetadata(null, OnColumnsChanged));

        public static void SetRows(Grid element, string value)
        {
            element.SetValue(RowsProperty, value);
        }

        public static string GetRows(Grid element)
        {
            return (string)element.GetValue(RowsProperty);
        }

        public static void SetColumns(Grid element, string value)
        {
            element.SetValue(ColumnsProperty, value);
        }

        public static string GetColumns(Grid element)
        {
            return (string)element.GetValue(ColumnsProperty);
        }

        private static void OnRowsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Grid grid && e.NewValue is string rows)
            {
                grid.RowDefinitions.Clear();
                foreach (var rowDef in rows.Split(','))
                {
                    grid.RowDefinitions.Add(new RowDefinition
                    {
                        Height = (GridLength)new GridLengthConverter().ConvertFromString(rowDef.Trim())
                    });
                }
            }
        }

        private static void OnColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Grid grid && e.NewValue is string columns)
            {
                grid.ColumnDefinitions.Clear();
                foreach (var colDef in columns.Split(','))
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition
                    {
                        Width = (GridLength)new GridLengthConverter().ConvertFromString(colDef.Trim())
                    });
                }
            }
        }
    }
}
