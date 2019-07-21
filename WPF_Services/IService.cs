using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF_Services
{
    public interface IService
    {
        ServiceType Type { get; }
        String Name { get; set; }
    }
}
