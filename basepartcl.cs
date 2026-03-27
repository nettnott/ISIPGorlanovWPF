using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIPGorlanovWPF
{
    public partial class basepart_
    {
        public string Info { get
            {
                switch (parttypeid)
                {
                    case 1:
                        return $"сокет: {cpu_.socket_.name}, количество ядер: {cpu_.numberofcores}, базовая частота ядра: {cpu_.basecorefrequency}," +
                            $" максимальная частота ядра: {cpu_.maxcorefrequency} кэш l3: {cpu_.cachel3} видеоядро: {cpu_.igpu_.name}";
                    case 4:
                        return $"сокет: {motherboard_.socket_.name}, формфактор: {motherboard_.formfactor_.name}, слоты памяти {motherboard_.memoryslots}," +
                            $"мемори тайп {motherboard_.memorytype_.name}";
                    default:
                        return "";
                }
            } 
        }

    }
}
