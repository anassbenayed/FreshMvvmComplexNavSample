using System;
using PropertyChanged;

namespace FreshMvvmComplexNav
{
    [AddINotifyPropertyChangedInterface]
    public class Contact
    {
        public Contact ()
        {
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }
    }
}

