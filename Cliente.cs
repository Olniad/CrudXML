using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows;
namespace CrudXML
{
    public class Cliente
    {
        #region Atributos
        private string _nome;
        private string _email;
        #endregion

        #region Propriedades
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        #endregion
    }


    //estão sendo feitas a listagem de clientes e o metodo adicionar

    public class Clientes
    {
        private List<Cliente> _clientes;
        public Clientes()
        {
            this._clientes = new List<Cliente>();
        }

        public void Adicionar(Cliente cliente)
        {
            if (this._clientes.Count(c => c.Nome.Equals(cliente.Nome)) > 0)
            {
                throw new Exception("Já existe um cliente com este nome");
            }
            else
            {
                this._clientes.Add(cliente);
            }
        }
        public void Remover(Cliente cliente)
        {
            this._clientes.Remove(cliente);
        }
        public List<Cliente> ListarTodos()
        {
            return this._clientes;
        }
        public void Salvar()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Cliente>));
            FileStream fs = new FileStream("C:Clientes.xml", FileMode.OpenOrCreate);
            ser.Serialize(fs, this._clientes);
            fs.Close();
        }
        public void Carregar()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Cliente>));
            FileStream fs = new FileStream("C:Clientes.xml", FileMode.OpenOrCreate);
            try
            {
                this._clientes = ser.Deserialize(fs) as List<Cliente>;
            }
            catch (InvalidOperationException ex)
            {
                ser.Serialize(fs, this._clientes);
            }
            finally
            {
                fs.Close();
            }
        }
    }

}
