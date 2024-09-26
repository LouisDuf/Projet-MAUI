namespace BookApp.Composants;

public partial class ToggleSwitchView : ContentView
{
    public ToggleSwitchView()
    {
        InitializeComponent();
    }

    // Gestionnaire d'�v�nements pour le changement d'�tat du switch
    private void OnToggled(object sender, ToggledEventArgs e)
    {
        if (e.Value) // Si c'est ON
        {
            OnLabel.Opacity = 1;
            OffLabel.Opacity = 0.25;
        }
        else // Si c'est OFF
        {
            OnLabel.Opacity = 0.25;
            OffLabel.Opacity = 1;
        }
    }
}
