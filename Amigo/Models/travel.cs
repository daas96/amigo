//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Amigo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class travel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public travel()
        {
            this.Passengers = new HashSet<Passengers>();
        }
    
        public int Id { get; set; }
        public int driver { get; set; }
        public string drivername { get; set; }
        public string departure { get; set; }
        public string arrival { get; set; }
        public DateTime date { get; set; }
        public int hour { get; set; }
        public Nullable<bool> smoke { get; set; }
        public Nullable<bool> animal { get; set; }
        public Nullable<bool> luggage { get; set; }
        public int nbpassengers { get; set; }
        public int nbpassengersmax { get; set; }
    
        public virtual users users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Passengers> Passengers { get; set; }
    }
}
