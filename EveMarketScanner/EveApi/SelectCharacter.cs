using System;
using System.Windows.Forms;

namespace MarketScanner.EveApi
{
    // A delegate type for hooking up select notifications.
    public delegate void CharacterSelectedEventHandler( object sender, EventArgs e );


    public partial class SelectCharacter : Form
    {
        // The CharacterSelected event
        public event CharacterSelectedEventHandler CharacterSelected;

        private EveAccount eaCurrent;

        public SelectCharacter( EveAccount eAccount )
        {
            InitializeComponent();
            eaCurrent = eAccount;
            listBox1.Items.AddRange( eaCurrent.CharacterList );
            //listBox1.SelectedIndex = 0;
            btnSelectChar.Enabled = false;
        }

        private void button1_Click( object sender, EventArgs e )
        {
            // Get the selected character from the listbox
            eaCurrent.SelectedCharacter = eaCurrent.CharacterList[listBox1.SelectedIndex];
            // Character was selected, fire event
            OnCharacterSelected( EventArgs.Empty );
            // Close the form
            this.Close();
        }

        // Invoke the CharacterSelected event; called when a character is selected
        protected virtual void OnCharacterSelected( EventArgs e )
        {
            if (CharacterSelected != null)
                CharacterSelected( eaCurrent, e );
        }

        private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
        {
            ListBox lb = (ListBox)sender;
            // Enable select button if valid selection is made
            if (lb.SelectedIndex != -1)
                btnSelectChar.Enabled = true;
        }


    }
}