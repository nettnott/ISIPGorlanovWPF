using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIPGorlanovWPF
{
    internal class Lists
    {
        public static List<motherboard_> motherboards = Core.Context.motherboard_.ToList();
        public static List<cpu_> cpus = Core.Context.cpu_.ToList();
        public static List<gpu_> gpus = Core.Context.gpu_.ToList();
        public static List<ram_> rams = Core.Context.ram_.ToList();
        public static List<powersupply_> powersupplies = Core.Context.powersupply_.ToList();
        public static List<case_> cases = Core.Context.case_.ToList();

        public static List<manufacturer_> manufacturers = Core.Context.manufacturer_.ToList();
        public static List<basepart_> baseparts = Core.Context.basepart_.ToList();

        public static List<assembly_> assemblies = Core.Context.assembly_.ToList();
    }
}
