
using fvalenciaS5.Models;

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace fvalenciaS5               
{ 
    public class PersonRepository 
    {
        string _dbpath; 
        private SQLiteConnection conn;
        public string StatusMessage { get; set; } 

        private void Init() 
        {
            if (conn is not null)
                return;
            conn = new(_dbpath);  
            conn.CreateTable<Persona>();            
                                
        }
                                    
        public PersonRepository (string dbpath) 
        {                                       
            _dbpath = dbpath;
        }
      
       

        
        public void AddNewPerson (string name) 
        {                                     
            int result = 0;

            try 
            {
                Init(); 
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre es rquerido");
                Persona persona = new() { Name = name };
                result= conn.Insert(persona);
                StatusMessage = string.Format("Se inserto una persona", result, name);

            }
            catch (System.Exception ex)
            {

                StatusMessage = string.Format("Error no se inserto una persona",name, ex.Message);
            }

        }

        
        public List<Persona> getAllPeople() 
        {
            try
            {
                Init(); 
                return conn.Table<Persona>().ToList();

            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al listar", ex.Message);
            }
            return new List<Persona>();
        }


        //funcion para actualizar
        public string ActualizarPersona(int id, string name)
        {
            int result = 0;
            try
            { 
                Init();
               
                Persona persona = new() {Id = id, Name = name };
                result =conn.Update(persona);
                StatusMessage = string.Format("Se actualizo persona", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al actualizar", ex.Message);
            }
            return result.ToString();
        }
        
        //funcion para Eliminar  
        public void EliminarPersona(Persona persona)
        {
            int result = 0;
            try
            {
                Init();
                result=conn.Delete(persona);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Se elimino", ex.Message);
            }

        }   



    }
}
