using System;
using System.Drawing;
using System.Windows.Forms;
using MarketScanner.Properties;
using System.Collections;

namespace MarketScanner
{
    public partial class StarSystemsFilter : Form
    {
        private AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();

        public StarSystemsFilter()
        {
            InitializeComponent();

            // Force grip style shown
            this.SizeGripStyle = SizeGripStyle.Show;

            // Set icon
            this.Icon = Values.icoAppIcon;

            // Eventhandler binding
            tbSystemToAdd.KeyUp += new KeyEventHandler( tbSystemToAdd_KeyUp );

            // initialize system names
            string[] saSystemNames = new string[Values.slSolarSystems.Values.Count];
            Values.slSolarSystems.Values.CopyTo( saSystemNames, 0 );
            acsc.AddRange( saSystemNames );

            // add custom autocomplete to system name textbox
            tbSystemToAdd.AutoCompleteCustomSource = acsc;
            tbSystemToAdd.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbSystemToAdd.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Restore previously saved list of system exeptions
            if (Values.ExeptedSystems.Count > 0 && lbExeptedSystems.Items.Count < 1)
            {
                lbExeptedSystems.Items.AddRange( Values.ExeptedSystems.ToArray() );
            }

            // Calculate min form size
            RecalculateMinFormSize();
        }

        private void RecalculateMinFormSize()
        {
            this.MinimumSize = new Size( 221, 10 * lbExeptedSystems.ItemHeight + 131 );
        }

        private void bAddSystem_Click( object sender, EventArgs e )
        {
            int iFound = -1;
            // Search for match to add
            for (int i = 0 ; i < acsc.Count ; i++)
            {
                if (acsc[i].ToLower() != tbSystemToAdd.Text.ToLower()) continue;
                iFound = i;
                break;
            }
            // If system exits in solar system list add it to list of exepted systems
            if (iFound > -1)
            {
                if (lbExeptedSystems.Items.Contains( acsc[iFound] )) return;
                lbExeptedSystems.Items.Add( acsc[iFound] );
                tbSystemToAdd.Text = string.Empty;
            }
            else // Inform user of incorrect system
            {
                MessageBox.Show( string.Format( "'{0}' is not a valid system", tbSystemToAdd.Text ) );
                return;
            }
        }

        private void bCloseAndSave_Click( object sender, EventArgs e )
        {
            // TODO: Save the list to application settings
            if (lbExeptedSystems.Items.Count > -1)
            {
                string[] aSystemsToStore = new string[lbExeptedSystems.Items.Count];
                lbExeptedSystems.Items.CopyTo( aSystemsToStore, 0 );
                Values.ExeptedSystems.Clear();
                Values.ExeptedSystems.AddRange( aSystemsToStore );
            }
            ((Main)this.Owner).ReloadMarketLogs();
            ((Main)this.Owner).RefreshRegions();
            this.Close();
        }

        private void bRemoveSelected_Click( object sender, EventArgs e )
        {
            if (lbExeptedSystems.SelectedIndices.Count < 1) return;
            ArrayList alTrimmedSystemList = new ArrayList();
            for (int i = 0 ; i < lbExeptedSystems.Items.Count ; i++)
            {
                if (lbExeptedSystems.SelectedIndices.Contains( i )) continue; // skip if one of the selected items
                alTrimmedSystemList.Add( lbExeptedSystems.Items[i] );
            }
            lbExeptedSystems.Items.Clear();
            lbExeptedSystems.Items.AddRange( alTrimmedSystemList.ToArray() ); // add the trimmed array
        }

        private void tbSystemToAdd_KeyUp( object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Enter)
                bAddSystem_Click( sender, e );
        }


    }
}
