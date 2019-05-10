using System;
using System.Collections.Generic;

namespace FreshMvvmComplexNav
{
    public interface IDatabaseService
    {
        List<Contact> GetContacts ();

        void UpdateContact (Contact contact);

        List<Quote> GetQuotes ();

        void UpdateQuote (Quote quote);
    }
}

