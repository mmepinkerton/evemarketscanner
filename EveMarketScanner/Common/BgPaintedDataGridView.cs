using System.Windows.Forms;
using System.Drawing;

namespace MarketScanner.Common
{
    class BgPaintedDataGridView : DataGridView
    {

        //public event System.EventHandler BackgroundTextChanged;


        private string m_backgroundText = string.Empty;
        public string BackgroundText
        {
            get { return m_backgroundText; }
            set
            {
                m_backgroundText = value;
                Refresh();
            }
        }

        private TextPosition m_ePos = TextPosition.TopLeft;
        public TextPosition BackgroundTextPosition
        {
            get { return m_ePos; }
            set
            {
                m_ePos = value;
                Refresh();
            }
        }

        public enum TextPosition
        {
            TopLeft,
            TopRight,
            BottomRight,
            BottomLeft,
            Center
        }

        private Font m_fFont = new Font( "Arial", 20 );
        public Font BackgroundTextFont
        {
            get { return m_fFont; }
            set
            {
                m_fFont = value;
                Refresh();
            }
        }

        private int m_iPadding = 0;
        public int BackgroundPadding
        {
            get { return m_iPadding; }
            set
            {
                m_iPadding = value;
                Refresh();
            }
        }

        protected override void PaintBackground( System.Drawing.Graphics grf, System.Drawing.Rectangle r1, System.Drawing.Rectangle r2 )
        {
            base.PaintBackground( grf, r1, r2 );
            //Paint text if BackgroundText property is set
            if (this.BackgroundText != string.Empty)
            {
                grf.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                float xOffset = BackgroundPadding;
                float yOffset = BackgroundPadding;
                // Measure string.
                SizeF bgTextSize = new SizeF();
                bgTextSize = grf.MeasureString( this.BackgroundText, this.BackgroundTextFont );
                // Calculate position of text based on position selected
                switch (BackgroundTextPosition)
                {
                    case TextPosition.TopLeft:
                        //Default position
                        break;
                    case TextPosition.TopRight:
                        xOffset = this.Width - bgTextSize.Width - BackgroundPadding;
                        break;
                    case TextPosition.BottomRight:
                        xOffset = this.Width - bgTextSize.Width - BackgroundPadding;
                        yOffset = this.Height - bgTextSize.Height - BackgroundPadding;
                        break;
                    case TextPosition.BottomLeft:
                        yOffset = this.Height - bgTextSize.Height - BackgroundPadding;
                        break;
                    case TextPosition.Center:
                        xOffset = this.Width / 2 - bgTextSize.Width / 2;
                        yOffset = this.Height / 2 - bgTextSize.Height / 2;
                        break;
                    default:
                        break;
                }
                grf.DrawString( this.BackgroundText, this.BackgroundTextFont, Brushes.Silver, xOffset, yOffset );

            }
        }

        protected override void OnResize( System.EventArgs e )
        {
            base.OnResize( e );
            if (m_backgroundText != string.Empty)
            {
                Refresh();
            }
        }
    }
}
