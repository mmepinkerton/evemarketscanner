using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;



namespace MarketScanner
{
    /// <summary>
    /// Formatting of various objects in the project
    /// </summary>
    internal static class Formatting
    {

        /// <summary>
        /// Formats a DataGridView for Eve market Buyers and sellers output. 
        /// </summary>
        /// <param name="dgv"> Takes a DataGridView reference. REMEMBER to set datasource before calling this method!</param>
        /// <param name="formatDGVType">Enum</param>
        internal static void FormatDataGridViewByType( ref MarketScanner.Common.BgPaintedDataGridView dgv, FormatDgvType formatDGVType )
        {
            if (dgv.DataSource != null)
            {
                // Set Header Names

                // Set headernames for initially shown
                dgv.Columns["jumps"].HeaderText = "Jumps";
                dgv.Columns["volRemaining"].HeaderText = "Quantity";
                dgv.Columns["price"].HeaderText = "Price";
                dgv.Columns["stationName"].HeaderText = "Location";
                dgv.Columns["expires"].HeaderText = "Expires";
                // headernames for initially hidden
                dgv.Columns["typeID"].HeaderText = "TypeID";
                dgv.Columns["range"].HeaderText = "Range";
                dgv.Columns["orderID"].HeaderText = "OrderID";
                dgv.Columns["volEntered"].HeaderText = "Volume Entered";
                dgv.Columns["minVolume"].HeaderText = "Min. Volume";
                dgv.Columns["bid"].HeaderText = "Bid";
                dgv.Columns["issued"].HeaderText = "Issued";
                dgv.Columns["duration"].HeaderText = "Duration";
                dgv.Columns["stationID"].HeaderText = "StationID";
                dgv.Columns["regionID"].HeaderText = "RegionID";
                dgv.Columns["solarSystemID"].HeaderText = "SolarSystemID";
                dgv.Columns["corporationName"].HeaderText = "Station Owner";

                switch (formatDGVType)
                {
                    case FormatDgvType.Sellers:

                        // Initially Hidden
                        dgv.Columns["typeID"].Visible = false;
                        dgv.Columns["range"].Visible = false;
                        dgv.Columns["orderID"].Visible = false;
                        dgv.Columns["volEntered"].Visible = false;
                        dgv.Columns["minVolume"].Visible = false;
                        dgv.Columns["bid"].Visible = false;
                        dgv.Columns["issued"].Visible = false;
                        dgv.Columns["duration"].Visible = false;
                        dgv.Columns["stationID"].Visible = false;
                        dgv.Columns["regionID"].Visible = false;
                        dgv.Columns["solarSystemID"].Visible = false;
                        dgv.Columns["corporationName"].Visible = false;

                        // * Visual *
                        dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;

                        // Datatypes formatting
                        dgv.Columns["price"].DefaultCellStyle.Format = "N";
                        dgv.Columns["volRemaining"].DefaultCellStyle.Format = "N0";
                        dgv.Columns["Security"].DefaultCellStyle.Format = "F2";

                        // Column Order
                        dgv.Columns["jumps"].DisplayIndex = 0;
                        dgv.Columns["volRemaining"].DisplayIndex = 1;
                        dgv.Columns["price"].DisplayIndex = 2;
                        dgv.Columns["stationName"].DisplayIndex = 3;
                        dgv.Columns["expires"].DisplayIndex = 5;
                        dgv.Columns["corporationName"].DisplayIndex = 4;

                        // Data Order
                        dgv.Sort( dgv.Columns["price"], System.ComponentModel.ListSortDirection.Ascending );

                        // resize columns
                        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgv.Columns["jumps"].FillWeight = 100;
                        dgv.Columns["jumps"].MinimumWidth = 15;
                        dgv.Columns["volRemaining"].FillWeight = 100;
                        dgv.Columns["volRemaining"].MinimumWidth = 15;
                        dgv.Columns["price"].FillWeight = 200;
                        dgv.Columns["stationName"].FillWeight = 500;
                        dgv.Columns["expires"].FillWeight = 200;
                        dgv.Columns["corporationName"].FillWeight = 200;
                        dgv.Columns["corporationName"].MinimumWidth = 50;
                        break;

                    case FormatDgvType.Buyers:
                        // Hidden
                        dgv.Columns["typeID"].Visible = false;
                        dgv.Columns["orderID"].Visible = false;
                        dgv.Columns["volEntered"].Visible = false;
                        dgv.Columns["bid"].Visible = false;
                        dgv.Columns["issued"].Visible = false;
                        dgv.Columns["duration"].Visible = false;
                        dgv.Columns["stationID"].Visible = false;
                        dgv.Columns["regionID"].Visible = false;
                        dgv.Columns["solarSystemID"].Visible = false;
                        dgv.Columns["corporationName"].Visible = false;

                        // * Visual *
                        dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;

                        // Datatypes formatting
                        dgv.Columns["price"].DefaultCellStyle.Format = "N";
                        dgv.Columns["volRemaining"].DefaultCellStyle.Format = "N0";
                        dgv.Columns["Security"].DefaultCellStyle.Format = "F2";

                        // Column Order
                        dgv.Columns["jumps"].DisplayIndex = 0;
                        dgv.Columns["volRemaining"].DisplayIndex = 1;
                        dgv.Columns["price"].DisplayIndex = 2;
                        dgv.Columns["stationName"].DisplayIndex = 3;
                        dgv.Columns["corporationName"].DisplayIndex = 4;
                        dgv.Columns["range"].DisplayIndex = 5;
                        dgv.Columns["minVolume"].DisplayIndex = 6;
                        dgv.Columns["expires"].DisplayIndex = 7;

                        // Data Order
                        dgv.Sort( dgv.Columns["price"], System.ComponentModel.ListSortDirection.Descending );

                        // resize columns
                        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgv.Columns["jumps"].FillWeight = 100;
                        dgv.Columns["jumps"].MinimumWidth = 15;
                        dgv.Columns["volRemaining"].FillWeight = 100;
                        dgv.Columns["volRemaining"].MinimumWidth = 15;
                        dgv.Columns["price"].FillWeight = 200;
                        dgv.Columns["price"].MinimumWidth = 40;
                        dgv.Columns["stationName"].FillWeight = 400;
                        dgv.Columns["stationName"].MinimumWidth = 50;
                        dgv.Columns["range"].FillWeight = 100;
                        dgv.Columns["range"].MinimumWidth = 50;
                        dgv.Columns["minVolume"].FillWeight = 100;
                        dgv.Columns["minVolume"].MinimumWidth = 15;
                        dgv.Columns["expires"].FillWeight = 200;
                        dgv.Columns["expires"].MinimumWidth = 35;
                        dgv.Columns["corporationName"].FillWeight = 200;
                        dgv.Columns["corporationName"].MinimumWidth = 50;
                        break;
                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal static void dataGridView_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridView dgv = (DataGridView)sender;

            if (e.RowIndex >= 0 &&
                    e.ColumnIndex == dgv.Columns["Security"].Index)
            {
                if (e.Value != null)
                {
                    double dSec = Math.Round( (double)e.Value, 2 );
                    if (dSec >= 1) { e.CellStyle.BackColor = System.Drawing.Color.FromArgb( 112, 231, 231 ); }
                    else if (dSec >= 0.5) { e.CellStyle.BackColor = System.Drawing.Color.FromArgb( 72, 216, 0 ); }
                    else if (dSec > 0.0) { e.CellStyle.BackColor = System.Drawing.Color.FromArgb( 255, 175, 62 ); }
                    else if (dSec <= 0.0) { e.CellStyle.BackColor = System.Drawing.Color.FromArgb( 197, 4, 4 ); }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal static void dataGridView_Sorted( object sender, EventArgs e )
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Rows.Count > 0)
            {
                if (dgv.SortedColumn.Name == "price")
                {
                    // hack to figure out which dataview we are looking at (seller/buyer)
                    DataView dv = (DataView)dgv.DataSource;
                    if (dv.RowFilter == "bid = false")
                    {
                        if (dgv.SortOrder == SortOrder.Ascending)
                        {
                            dgv.Rows[0].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb( 223, 255, 213 );
                            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb( 255, 160, 160 );
                        }
                        else
                        {
                            dgv.Rows[0].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb( 255, 160, 160 );
                            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb( 223, 255, 213 );
                        }
                    }
                    if (dv.RowFilter == "bid = true")
                    {
                        if (dgv.SortOrder == SortOrder.Descending)
                        {
                            dgv.Rows[0].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb( 223, 255, 213 );
                            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb( 255, 160, 160 );
                        }
                        else
                        {
                            dgv.Rows[0].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb( 255, 160, 160 );
                            dgv.Rows[dgv.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb( 223, 255, 213 );
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Draws the first item of a ComboBox, in italic and grey
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal static void cbItalizeFirstItem_DrawItem( object sender, DrawItemEventArgs e )
        {
            // Exit if no data
            if (e.Index == -1 || sender == null)
                return;

            ComboBox cb = (ComboBox)sender;
            Font fFont;
            Brush bBrush;
            String sItem;

            if (e.Index == 0) // First item
            {
                fFont = new Font( e.Font.FontFamily, e.Font.Size, FontStyle.Italic );
                bBrush = Brushes.Gray;
            }
            else // Every other item
            {
                e.DrawBackground();
                fFont = e.Font;
                bBrush = SystemBrushes.ControlText;

                // Item is hovered over
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    bBrush = SystemBrushes.HighlightText;

                //e.DrawFocusRectangle();
                //e.Graphics.FillRectangle( new SolidBrush( e.BackColor ), e.Bounds );
            }

            // Get itemtype and proper text
            if (cb.Items[e.Index] is MarketLog && cb.Name.IndexOf( "Item" ) > 0) // Make exeption for Item combo
            {
                MarketLog ml = (MarketLog)cb.Items[e.Index];
                sItem = ml.Item;
            }
            else
            {
                sItem = cb.Items[e.Index].ToString();
            }

            // Draw the item
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            e.Graphics.DrawString( sItem, fFont, bBrush, e.Bounds );
            e.DrawFocusRectangle();
        }


    }
}