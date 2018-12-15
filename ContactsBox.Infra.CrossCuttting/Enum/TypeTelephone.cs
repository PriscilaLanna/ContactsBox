using System.ComponentModel;

namespace ContactsBox.Infra.CrossCuttting.Enum
{
    enum TypeTelephone
    {
        Celular = 1,
        Casa = 2,
        Trabalho = 3,
        Principal =4,
        [Description("Fax do Trabalho")]
        FaxDoTrabalho =5,
        [Description("Fax de Casa")]
        FaxDeCasa = 6,
        Outro =7
    }
}
