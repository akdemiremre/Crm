using Crm.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.BusinessLayer.Results
{
    public class BusinessLayerResult<T> where T : class
    {
        /* 1.YOL | KEYVALUEPAIR KULLANARAK

        public List<KeyValuePair<ErrorMessageCode,string>> Errors { get; set; } // anahtar-değer yani key-value ikilisi tutmak için KeyValuePair kullandık.
        public T Result { get; set; }

        public BusinessLayerResult()
        {
            Errors = new List<KeyValuePair<ErrorMessageCode,string>>();
            
            // DEĞER EKLEMEK İÇİN
            // Errors.Add(new List<KeyValuePair<ErrorMessageCode,string>>(ErrorMessageCode.UsernameAlreadyExists,"Kullanıcı adı kayıtlı"));
            // bu şekilde yazmamız gerekıyor bunu add methoduyla kısaltarak kullanıcaz
        }
        public void AddError(ErrorMessageCode code, string message)
        {
            Errors.Add(new KeyValuePair<ErrorMessageCode, string>(code, message));
        }
        */

        /* 2. YOL -> KEYVALUEPAIR YERINE ERRORMESSAGEOBJ CLASSINI YAZIP KULLANDIK */
        public List<ErrorMessageObj> Errors { get; set; }
        public T Result { get; set; }
        public BusinessLayerResult()
        {
            Errors = new List<ErrorMessageObj>();
        }
        public void AddError(ErrorMessageCode code, string message)
        {
            Errors.Add(new ErrorMessageObj()
            {
                Code = code,
                Message = message
            });
        }
    }
}
