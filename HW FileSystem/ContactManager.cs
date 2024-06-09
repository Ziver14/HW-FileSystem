using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Text.Json;

namespace HW_FileSystem
{
    public class ContactManager
    {
        private List<Contact> contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void RemoveContact(string name)
        {
            var contactToRemove = contacts.FirstOrDefault(c => c.Name == name);
            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        public Contact FindContactByName(string name)
        {
            return contacts.FirstOrDefault(c => c.Name == name);
        }

        public Contact FindContactByPhoneNumber(string phoneNumber)
        {
            return contacts.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
        }

        public void SaveToJson(string filePath)
        {
            try
            {
                var jsonString = JsonConvert.SerializeObject(contacts);
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving to JSON: {ex.Message}");
            }
        }

        public void SaveToXml(string filePath)
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Contact>));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    xmlSerializer.Serialize(stream, contacts);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving to XML: {ex.Message}");
            }
        }

        public void LoadFromJson(string filePath)
        {
            try
            {
                var jsonString = File.ReadAllText(filePath);
                contacts = JsonConvert.DeserializeObject<List<Contact>>(jsonString);
            }
                
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading from JSON: {ex.Message}");
            }


                
               
        }

        public void LoadFromXml(string filePath)
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Contact>));
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    contacts = (List<Contact>)xmlSerializer.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading from XML: {ex.Message}");
            }
        }

        public void DisplayContacts()
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone Number: {contact.PhoneNumber}");
            }
        }
    }
}
