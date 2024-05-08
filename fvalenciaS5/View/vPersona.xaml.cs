using fvalenciaS5.Models;

namespace fvalenciaS5.View;

public partial class vPersona : ContentPage
{
    //private readonly Persona _persona; 
    private int _editarPersonaId;

	public vPersona()
	{
		InitializeComponent();
        
    }

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        if(_editarPersonaId == 0)
        {
            lblStatus.Text = ""; 
            App.personRepo.AddNewPerson(txtName.Text); 
            lblStatus.Text = App.personRepo.StatusMessage;

        }
        else
        {
            lblStatus.Text = "";
           
            App.personRepo.ActualizarPersona (_editarPersonaId,txtName.Text);
            lblStatus.Text = App.personRepo.StatusMessage;
        }



    }

    private void btnInsertar_Clicked_1(object sender, EventArgs e)
    {

    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        List<Persona> people = App.personRepo.getAllPeople();
        ListaPersona.ItemsSource = people;
        lblStatus.Text=App.personRepo.StatusMessage;

            
    }

    private async void ListaPersona_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        
        var persona = (Persona)e.Item;
        var accion = await DisplayActionSheet("Accion","Cancelar", null, "Editar","Eliminar");

        switch (accion)

        {
            case "Editar":
                _editarPersonaId = persona.Id;
                txtName.Text = persona.Name;
                
            break;

            case "Eliminar":
               App.personRepo.EliminarPersona(persona);
            break;
        }
    }

}