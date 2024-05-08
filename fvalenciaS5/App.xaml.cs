namespace fvalenciaS5
{
  
    public partial class App : Application
    { 
        public static PersonRepository personRepo { get; set; } 
        public App(PersonRepository personRepository) 
        {
            InitializeComponent();

            MainPage = new View.vPersona(); 
            //MainPage = new AppShell();
            personRepo = personRepository; 
        }
    }
}
