using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RESTmvp
{
    public class Presenter
    {
        Model _model1;
        //View view1;
        public Presenter()
        {
            _model1 = new Model();
        }

        public List<string> GetCountryData(string country)
        {
            return _model1.GetListOfUni(country);
        }

        public string GetCount(List<string> listOfObjects)
        {
            return _model1.GetCount(listOfObjects);
        }
    }
}
