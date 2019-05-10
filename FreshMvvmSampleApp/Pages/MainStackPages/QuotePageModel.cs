using Xamarin.Forms;
using PropertyChanged;
using FreshMvvm;
using System.Linq;

namespace FreshMvvmComplexNav
{
    [AddINotifyPropertyChangedInterface]
    public class QuotePageModel : FreshBasePageModel
    {
        IDatabaseService _databaseService;

        public Quote Quote { get; set; }

        public QuotePageModel (IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public override void Init (object initData)
        {			
            if (initData is int)
            {
                Quote = _databaseService.GetQuotes().Where(o => o.Id == (int)initData).FirstOrDefault();
            }
            else
            {
                Quote = initData as Quote;
                if (Quote == null)
                    Quote = new Quote();
            }
        }

        public Command SaveCommand {
            get {
                return new Command (async () => {
                    _databaseService.UpdateQuote (Quote);
                    await CoreMethods.PopPageModel (Quote);
                });
            }
        }

        public Command TestModal {
            get {
                return new Command (async () => {
                    await CoreMethods.PushPageModel<ModalPageModel> (null, true);
                });
            }
        }
    }
}

