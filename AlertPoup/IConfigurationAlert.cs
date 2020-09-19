using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertPoup
{
    public interface IConfigurationAlert
    {
        int MaxSecondsVisible { get; set; }
        int MaxAlertDisplayed { get; set; }
        AlertDirection Direction { get; set; }
    }
}
