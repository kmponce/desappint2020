using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tutorias.Models
{
    public class ContactType
    {
        [Key]
        public int ContactTypeID{get; set;}
        public string Contact_Type{get; set;}

        /****************** Relaciones ***************/
        public ICollection<Contact> Contacts{get; set;} //uno a muchos
    }
}