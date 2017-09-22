using System;
using System.Collections.Generic;

namespace OnSoil
{
    public class Soil
    {
        public static string[] SoilAndHorizontsName;
        private static string _difficult;
        private static readonly List<int> Indices = new List<int>();
        private static readonly List<int> Agroindices = new List<int>();
        private static string[] _horrizonts;
        private static string[][] _soils;
        private static string[][] _agrosoils;

        public static void Init(string difficult)
        {
            SoilAndHorizontsName = new string[8];
            _difficult = difficult;
            #region Soils

            _horrizonts = new[]
            {
                "AEL", "AH", "AJ", "AK", "AO", "ASN", "AU", "AV", "AY","[ABC]", "Gs", "CGs",
                "BAN", "BCA", "BSN", "BEL", "BELg", "BFM", "BHF", "BI", "BM", "BMK", "BPL", "BT", "BTg"
                , "CAT", "CR", "CRM", "E", "EL", "ELg", "F", "G", "ML"
                , "O", "P", "PB", "PT", "PTR", "PU", "Q", "RJ"
                , "RU", "RY", "S", "SEL", "SS", "T", "TE", "TO", "TT", "TJ", "TUR"
                , "V", "W", "X", "ТПО"
            };

            _soils = new string[182][];
            //Текстурно-дифференцированныепочвы
            _soils[0] = new[] { "Подзолистые", "O", "EL", "BEL", "BT", "C" };
            _soils[1] = new[] { "Подзолисто-глеевые", "O", "EL", "BELg", "BTg", "G", "CG" };
            _soils[2] = new[] { "Торфяно-подзолисто-глеевые", "T", "ELg", "BELg", "BTg", "G", "CG" };
            _soils[3] = new[] { "Дерново-подзолистые", "AY", "EL", "BEL", "BT", "C" };
            _soils[4] = new[] { "Дерново-подзолисто-глеевые", "AY", "EL", "BELg", "BTg", "G", "CG" };
            _soils[5] = new[] { "Серые", "AY", "AEL", "BEL", "BT", "C" };
            _soils[6] = new[] { "Темно-серые", "AU", "BEL", "BT", "C" };
            _soils[7] = new[] { "Темно-серые глеевые", "AU", "BELg", "BTg", "G", "CG" };
            _soils[8] = new[] { "Темно-гумусовые подбелы", "AU", "EL", "(BEL)", "BT", "C" };
            _soils[9] = new[] { "Темно-гумусовые подбелы глеевые", "AU", "ELg", "BTg", "G", "CG" };
            _soils[10] = new[] { "Дерново-буро-подзолистые", "AY", "BEL", "BT", "C" };
            _soils[11] = new[] { "Дерново-солоди", "AY", "EL", "BT", "BCA", "Cca" };
            _soils[12] = new[] { "Дерново-солодиглеевые", "AY", "EL", "BTg", "BCAg", "Gca(s)", "CGca(s)" };
            _soils[13] = new[] { "Солоди темно-гумусовые", "AU", "EL", "BT", "BCA", "Cca,s" };
            _soils[14] = new[] { "Солоди перегнойно-темногумусовые квазиглеевые", "AH", "EL", "BTq", "BCAq", "Q(s)", "Q(s)" };
            //Альфегумусовые почвы
            _soils[15] = new[] { "Подбуры", "O", "BHF", "C" };
            _soils[16] = new[] { "Подбуры глеевые", "O", "BHF", "G", "CG" };
            _soils[17] = new[] { "Сухо-торфяно-подбуры", "TG", "BHF", "C" };
            _soils[18] = new[] { "Торфяно-подбуры глеевые", "T", "BHFg", "G", "CG" };
            _soils[19] = new[] { "Дерново-подбуры", "AY", "BF", "C" };
            _soils[20] = new[] { "Дерново-подбуры глеевые", "AY", "BHFg", "C", "CG" };
            _soils[21] = new[] { "Подзолы", "O", "E", "BHF", "C" };
            _soils[22] = new[] { "Подзолы глеевые", "O", "Eg", "BHFg", "G", "CG" };
            _soils[23] = new[] { "Сухоторфяно-подзолы", "TJ", "E", "BHF", "C" };
            _soils[24] = new[] { "Дерново-подзолы", "AY", "E", "BHF", "C" };
            _soils[25] = new[] { "Дерново-подзолы глеевые", "AY", "E", "BHFg", "G", "CG" };
            _soils[26] = new[] { "Торфяно-подзолы", "T", "E", "BHF", "C" };
            _soils[27] = new[] { "Торфяно-подзолы глеевые", "T", "E", "BHFg", "G", "CG" };
            _soils[28] = new[] { "Торфяно-подзолы рудяковые", "T", "Eg", "BHFg", "F", "G", "CG" };
            //Железисто-метаморфические почвы
            _soils[29] = new[] { "Ржавоземы", "AY", "BFM", "C" };
            _soils[30] = new[] { "Ржавоземы грубогумусовые", "AO", "BFM", "C" };
            _soils[31] = new[] { "Органо-ржавоземы", "O", "BFM", "C" };
            //Структурно-метаморфические почвы
            _soils[32] = new[] { "Буроземы", "AY", "BM", "C" };
            _soils[33] = new[] { "Буроземы грубо-гумусовые", "AO", "BM", "C" };
            _soils[34] = new[] { "Буроземы темно-гумусовые", "AU", "BM", "C" };
            _soils[35] = new[] { "Серые мета-морфические", "AY", "AEL", "BM", "C" };
            _soils[36] = new[] { "Темно-серые мета-морфические", "AU", "AEL", "BM", "C" };
            _soils[37] = new[] { "Элювиально метаморфические", "O", "EL", "BM", "C" };
            _soils[38] = new[] { "Дерново-элювиально-мета -морфические", "AY", "EL", "BM", "C" };
            _soils[39] = new[] { "Коричневые", "AU", "BM", "BCA", "Cca", "CG" };
            _soils[40] = new[] { "Желтоземы", "AY", "BEL", "BM", "CLM" };
            //Криометаморфические
            _soils[41] = new[] { "Крио-метаморфические", "O", "CRM", "C" };
            _soils[42] = new[] { "Перегнойно-криомета-морфические", "H", "CRM", "C" };
            _soils[43] = new[] { "Крио-метаморфические грубогумусовые", "AO", "CRM", "C" };
            _soils[44] = new[] { "Дерново-криомета-морфические", "AY", "CRM", "C" };
            _soils[45] = new[] { "Светлоземы", "O", "E", "CRM", "C" };
            _soils[46] = new[] { "Светлоземы иллювиально-железистые", "O", "E", "BF", "CRM", "C" };
            _soils[47] = new[] { "Светлоземы текстурно-дифференцированные", "O", "E", "BF", "CRM", "BT", "C" };
            //Палево-метаморфические почвы
            _soils[48] = new[] { "Палевые", "AJ", "BPL", "BCA", "Cca" };
            _soils[49] = new[] { "Палевые темногумусовые", "AU", "BPL", "BCA", "Cca" };
            _soils[50] = new[] { "Криоаридные", "AK", "BPL", "BCA", "Cca" };
            //Криогенные почвы (Криоземы)
            _soils[51] = new[] { "Криоземы", "O", "CR", "C┴" };
            _soils[52] = new[] { "Криоземы грубогумусовые", "AO", "CR", "C┴" };
            _soils[53] = new[] { "Торфяно-криоземы", "T", "CR", "C┴" };
            //Глеевые почвы 
            _soils[54] = new[] { "Глееземы", "O", "G", "CG" };
            _soils[55] = new[] { "Глееземы криомета-морфические", "O", "G", "CRM", "C(g)" };
            _soils[56] = new[] { "Торфяно-глееземы", "T", "G", "CG" };
            _soils[57] = new[] { "Темногумусово-глеевые", "AU", "G", "CG(ca)" };
            _soils[58] = new[] { "Перегнойно-глеевые", "H", "G", "CG" };
            //Аккумулятивно-гумусовые почвы
            _soils[59] = new[] { "Черноземы", "AU", "BCA", "Cca" };
            _soils[60] = new[] { "Черноземы глинисто-иллювиальные", "AU", "BI", "(BCA)", "C(ca)" };
            _soils[61] = new[] { "Черноземы текстурно-карбонатные", "AU", "CAT", "Cca" };
            _soils[62] = new[] { "Темные слитые", "AU", "v", "C(ca)" };
            _soils[63] = new[] { "Черноземовидные", "AU", "CRH", "Cg" };
            _soils[64] = new[] { "Черноземы квазиглеевые", "AU", "BCA", "Q", "CQ" };
            _soils[68] = new[] { "Черноземы глинисто-иллювиальные квазиглеевые", "AU", "BI", "(BCA)", "Q", "CQ" };
            _soils[66] = new[] { "Черноземы глинисто-иллювиальные глеевые", "AU", "BI", "(BCA)", "G", "CG(ca)" };
            _soils[67] = new[] { "Черноземы текстурно-карбонатные квазиглеевые", "AU", "CAT", "Q", "CQ" };
            _soils[68] = new[] { "Черноземовидные глеевые", "AU", "CRH", "G", "CG" };
            //Светлогумусовые аккумулятивно-карбонатные почвы
            _soils[69] = new[] { "Сероземовидные (светлогумусовые аккумулятивно-карбонатные)", "AJ", "BCA", "Cca" };
            _soils[70] = new[] { "Бурые (аридные) почвы", "AJ", "BM", "BCA", "Cca" };
            _soils[71] = new[] { "Каштановые", "AJ", "BMK", "BM", "CAT", "Cca" };
            //Щелочно-глинисто-дифференцированные почвы
            _soils[72] = new[] { "Солонцы темные", "SEL", "ASN", "BCAs,cs", "Cca,s" };
            _soils[73] = new[] { "Солонцы светлые", "SEL", "BSN", "BCAs,cs", "Cca,s" };
            _soils[74] = new[] { "Солонцы темные квазиглеевые", "SEL", "ASN", "BCAs,cs", "Qs", "CQca,s" };
            _soils[77] = new[] { "Солонцы светлые квазиглеевые", "SEL", "BSN", "BCAs,cs", "Qs", "CQca,s" };
            _soils[77] = new[] { "Солонцы темногумусовые", "AU", "SEL", "ASN", "BCAs,cs", "Cca,s" };
            _soils[78] = new[] { "Солонцы светлогумусовые", "AJ", "SEL", "BSN", "BCAs,cs", "Cca,s" };
            _soils[79] = new[] { "Солонцы темногумусовые квазиглеевые", "AU", "SEL", "ASN", "BCAs,cs", "Qs", "CQca,s" };
            _soils[80] = new[] { "Солонцы светлогумусовые квазиглеевые", "AJ", "SEL", "BSN", "BCAs,cs", "Qs", "CQca,s" };
            //Галоморфные почвы
            _soils[81] = new[] { "Солончаки глеевые", "S", "Gs", "CGs" };
            _soils[82] = new[] { "Солончаки сульфидные", "SS", "GsC", "Gss" };
            _soils[83] = new[] { "Солончаки вторичные", "S", "[ABC]" };
            //Гидрометаморфические почвы
            _soils[84] = new[] { "Гумусово-квазиглеевые", "AU", "Q", "CQ" };
            _soils[85] = new[] { "Перегнойно-квазиглеевые", "H", "Q", "CQ" };
            //Органо-аккумулятивные почвы
            _soils[86] = new[] { "Серо-гумусовые", "AY", "C" };
            _soils[87] = new[] { "Темно-гумусовые", "AU", "C" };
            _soils[88] = new[] { "Перегнойные", "H", "C" };
            _soils[89] = new[] { "Перегнойно-темно-гумусовые", "AH", "C" };
            _soils[90] = new[] { "Крио-гумусовые", "AK", "C" };
            _soils[91] = new[] { "Грубо-гумусовые", "AO", "C" };
            _soils[92] = new[] { "Светло-гумусовые", "AJ", "C" };
            //Элювиальные почвы
            _soils[93] = new[] { "Элювоземы", "O", "EL", "D" };
            _soils[94] = new[] { "Элювоземы глеевые", "O", "EL", "DG" };
            _soils[95] = new[] { "Дерново-элювоземы", "AY", "EL", "D" };
            _soils[96] = new[] { "Дерново-элювоземы глеевые", "AY", "EL", "DG" };
            _soils[97] = new[] { "Торфяно-элювоземы глеевые", "T", "EL", "DG" };
            _soils[98] = new[] { "Подзол-элювоземы", "O", "E", "D" };
            _soils[99] = new[] { "Дерново-подзол-элювоземы", "AY", "E", "D" };
            _soils[100] = new[] { "Торфяно-подзол-элювоземы глеевые", "T", "E", "DG" };
            //Литоземы
            _soils[101] = new[] { "Торфяно-литоземы", "T", "(C)", "R" };
            _soils[102] = new[] { "Сухоторфяно литоземы", "TJ", "(C)", "R" };
            _soils[103] = new[] { "Литоземы грубо-гумусовые", "AO", "(C)", "R" };
            _soils[104] = new[] { "Литоземы перегнойные", "H", "(C)", "R" };
            _soils[105] = new[] { "Литоземы серо-гумусовые", "AY", "(C)", "R" };
            _soils[106] = new[] { "Литоземы темно-гумусовые", "AU", "(C)", "R" };
            _soils[107] = new[] { "Литоземы светло-гумусовые", "AJ", "(C)", "R" };
            _soils[108] = new[] { "Литоземы крио-гумусовые", "AK", "R(ca)" };
            _soils[109] = new[] { "Литоземы перегнойно-темногумусовые", "AH", "(C)", "R" };
            _soils[110] = new[] { "Карболитоземы перегнойнo-темногумусовые", "AH", "(Cca)", "Rca" };
            _soils[111] = new[] { "Карболитоземы темногумусовые", "AU", "Cca", "Rca" };
            //Абраземы
            _soils[112] = new[] { "Абраземы глинисто-иллювиальные", "BI", "C" };
            _soils[113] = new[] { "Абраземы альфегумусовые", "BHF", "C" };
            _soils[114] = new[] { "Абраземы железисто-метаморфические", "BFM", "C" };
            _soils[115] = new[] { "Абраземы структурно-метаморфические", "BM", "C" };
            _soils[116] = new[] { "Абраземы палево-метаморфические", "BPL", "C(ca)" };
            _soils[117] = new[] { "Абраземы криомета-морфические", "CRM", "C" };
            _soils[118] = new[] { "Абраземы аккумулятивно-карбонатные", "BCA", "C(ca)" };
            _soils[119] = new[] { "Абраземы текстурно-карбонатные", "CAT", "C(ca)" };
            _soils[120] = new[] { "Абраземы солонцовые", "BSN", "BCAs,cs", "Cca,s" };
            _soils[121] = new[] { "Абраземы солонцовыетемные", "ASN", "BCAs,cs", "Cca,s" };
            //Турбоземы
            _soils[122] = new[] { "Турбоземы", "P", "TUR", "C" };
            _soils[123] = new[] { "Турбоземы темные", "PU", "TUR", "C" };
            _soils[124] = new[] { "Турбоземы темные глеевые", "PU", "TUR", "G", "CG" };
            _soils[125] = new[] { "Турбоземы темные квазиглеевые", "PU", "TUR", "Q", "CQ" };
            _soils[126] = new[] { "Турбоземы глинисто-иллювиальные", "P", "TUR", "BI", "C" };
            _soils[127] = new[] { "Турбоземы глинисто-иллювиальные темные", "PU", "TUR", "BI", "C" };
            _soils[128] = new[] { "Турбоземы глинисто-иллювиальные глеевые", "P", "TUR", "BI", "G", "CG" };
            _soils[129] = new[] { "Турбоземы глинисто-иллювиальные темные квазиглеевые", "PU", "TUR", "BI", "Q", "CQ" };
            _soils[130] = new[] { "Турбоземы аккумулятивно-карбонатные", "P", "TUR", "BCA", "Cca" };
            _soils[131] = new[] { "Турбоземы аккумулятивно-карбонатные темные", "PU", "TUR", "BI", "C" };
            _soils[132] = new[] { "Турбоземы аккумулятивно-карбонатные темные квазиглеевые", "PU", "TUR", "BCA", "Q", "CQ" };
            _soils[133] = new[] { "Турбоземы текстурно-карбонатные", "P", "TUR", "CAT", "Cca" };
            _soils[134] = new[] { "Турбоземы торфяно-минеральные", "PT", "TUR", "G", "CG" };
            _soils[135] = new[] { "Турбоземы постсолонцовые темные", "TUR{AU SEL ASN", "BCAs,cs", "Cca,s" };
            _soils[136] = new[] { "Турбоземы постсолонцовые светлые", "TUR{AJ SEL BSN", "BCAs,cs", "Cca,s" };
            _soils[137] = new[] { "Турбоземы постсолонцовые темные квазиглеевые", "TUR{AU SEL ASN", "BCAs,cs", "Qs", "CQca,s" };
            _soils[138] = new[] { "Турбоземы постсолонцовые светлые квазиглеевые", "TUR{AJ SEL BSN", "BCAs,cs", "Qs", "CQca,s" };
            //Аллювиальные почвы
            _soils[139] = new[] { "Аллювиальные гумусовые", "AY", "C~~" };
            _soils[140] = new[] { "Аллювиальные темногумусовые", "AU", "C~~" };
            _soils[141] = new[] { "Аллювиальные темногумусовые глеевые", "AU", "G", "CG~~" };
            _soils[142] = new[] { "Аллювиальные темногумусовые квазиглеевые", "AU", "Q", "CQ~~" };
            _soils[143] = new[] { "Аллювиальные перегнойно-глеевые", "H", "G", "CG~~" };
            _soils[144] = new[] { "Аллювиальные гумусовые глеевы", "AY", "G", "CG~~" };
            _soils[145] = new[] { "Аллювиальные рудяковые", "AY", "F", "C~~" };
            _soils[146] = new[] { "Аллювиальные слитые", "AU", "V", "C~~" };
            _soils[147] = new[] { "Аллювиальные мергелистые", "AU", "ML", "CG~~", "(CQ~~)" };
            _soils[148] = new[] { "Аллювиальные торфяно-глеевые", "T", "G", "CG~~" };
            //Вулканические почвы
            _soils[149] = new[] { "Охристые", "AO", "BH", "BAN", "C``", "{ABC}", "{ABC}" };
            _soils[150] = new[] { "Перегнойно-охристые", "H", "BAN", "C``", "{ABC}", "{ABC}" };
            _soils[151] = new[] { "Охристо-подзолистые", "AO", "E", "BH", "BAN", "C``", "{ABC}" };
            //Стратоземы
            _soils[152] = new[] { "Стратоземы серогумусовые", "RY", "D" };
            _soils[153] = new[] { "Стратоземы темногумусовые", "RU", "D" };
            _soils[154] = new[] { "Стратоземы светлогумусовые", "RJ", "D" };
            _soils[155] = new[] { "Стратоземы серогумусовые на погребенной почве", "RY", "[ABC]" };
            _soils[156] = new[] { "Стратоземы темногумусовые на погребенной почве", "RU", "[ABC]" };
            _soils[157] = new[] { "Стратоземы светлогумусовые на погребенной почве", "RJ", "[ABC]" };
            //Отдел Слаборазвитых почв
            _soils[158] = new[] { "Пелоземы", "O", "C=" };
            _soils[159] = new[] { "Пелоземы гумусовые", "W", "C=" };
            _soils[160] = new[] { "Псаммоземы", "O", "C.." };
            _soils[161] = new[] { "Псаммоземы гумусовые", "W", "C.." };
            _soils[162] = new[] { "Петроземы", "O", "R" };
            _soils[163] = new[] { "Петроземы гумусовые", "W", "R" };
            _soils[164] = new[] { "Карбо-петроземы", "O", "Rca" };
            _soils[165] = new[] { "Карбо-петроземы гумусовые", "W", "Rca" };
            _soils[166] = new[] { "Гипсо-петроземы", "O", "Rcs" };
            _soils[167] = new[] { "Гипсо-петроземы гумусовые", "W", "Rcs" };
            _soils[168] = new[] { "Солончаки", "S", "Cs,cs" };
            _soils[169] = new[] { "Слоисто-аллювиальные", "O", "С~~" };
            _soils[170] = new[] { "Слоисто-пепловые", "O", "C``" };
            _soils[171] = new[] { "Слоисто-эоловые", "O", "C^^" };
            _soils[172] = new[] { "Слоисто-аллювиальные гумусовые", "W", "С~~" };
            _soils[173] = new[] { "Слоисто-пепловые гумусовые", "W", "C``" };
            _soils[174] = new[] { "Слоисто-эоловые гумусовые", "W", "C^^" };
            //Торфяные почвы
            _soils[175] = new[] { "Торфяные олиготрофные", "TO", "TT" };
            _soils[176] = new[] { "Торфяные олиготрофные глеевые", "TO", "TT", "G" };
            _soils[177] = new[] { "Торфяные эутрофные", "TE", "TT" };
            _soils[178] = new[] { "Торфяные эутрофные глеевые", "TE", "TT", "G" };
            _soils[179] = new[] { "Сухо-торфяные", "TJ", "TT", "R" };
            //Торфоземы
            _soils[180] = new[] { "Торфоземы", "PT", "TT" };
            _soils[181] = new[] { "Торфоземы глеевые", "PT", "TT", "G" };


            _agrosoils = new string[94][];
            //Агро Текстурно-дифференцированные почвы
            _agrosoils[0] = new[] { "Агроторфяноподзолисто глеевые", "PT", "(T)", "ELg", "BELg", "BTg", "C", "G" };
            _agrosoils[1] = new[] { "Агродерново-подзолистые", "P", "(EL)", "BEL", "BT", "C" };
            _agrosoils[2] = new[] { "Агродерново-подзолисто-глеевые", "P", "(ELg)", "BELg", "BTg", "C", "G" };
            _agrosoils[3] = new[] { "Агросерые", "P", "(AY)", "AEL", "BEL", "BT", "C" };
            _agrosoils[4] = new[] { "Агро-темносерые", "PU", "(AU)", "BEL", "BT", "C" };
            _agrosoils[5] = new[] { "Агротемно-серые глеевые", "PU", "(AU)", "BELg", "BTg", "C", "G" };
            _agrosoils[6] = new[] { "Агротемно-гумусовые подбелы", "PU", "EL", "BEL", "BT", "C" };
            _agrosoils[7] = new[] { "Агротемно-гумусовые подбелы глеевые", "PU", "ELg", "BTg", "G", "CG" };
            _agrosoils[8] = new[] { "Агросолоди", "P", "(EL)", "BT", "BCA", "Cca" };
            _agrosoils[9] = new[] { "Агросолоди темные", "PU", "(AU)", "EL", "BT", "BCA", "Cca" };
            _agrosoils[10] = new[] { "Агросолоди глеевые", "P", "EL", "BTg", "BCAg", "Gca", "CGca" };
            _agrosoils[11] = new[] { "Агросолоди темногумусовые квазиглеевые", "PU", "EL", "BTq", "BCAq", "Q", "CQ" };
            //Агро Альфегумусовые почвы
            _agrosoils[12] = new[] { "Агродерново-подзолы", "P", "E", "BHF", "C" };
            _agrosoils[13] = new[] { "Агродерново-подзолы глеевые", "P", "E", "BHFg", "G", "CG" };
            _agrosoils[14] = new[] { "Агроторфяно-подзолы глеевые", "PT", "(T)", "E", "BHFg", "G", "CG" };
            //Агро Структурно-метаморфические почвы
            _agrosoils[15] = new[] { "Агродерново-элювиально-метаморфические", "P", "EL", "BM", "C" };
            _agrosoils[16] = new[] { "Агросерые мета-морфические", "P", "AEL", "BM", "C" };
            _agrosoils[17] = new[] { "Агротемно-серые мета-морфические", "PU", "AEL", "BM", "C" };
            _agrosoils[18] = new[] { "Агро-коричневые", "PU", "AU", "BM", "BCA", "Cca" };
            //Агро Палево-метаморфические почвы
            _agrosoils[19] = new[] { "Агропалевые", "P", "BPL", "BCA", "Cca" };
            //Агро Глеевые почвы
            _agrosoils[20] = new[] { "Агроглееземы криомета-морфические", "P", "G", "CRM", "C(g)" };
            _agrosoils[21] = new[] { "Агроторфяно-глееземы", "PT", "T", "G", "CG" };
            _agrosoils[22] = new[] { "Агротемно-гумусовые глеевые", "PU", "AU", "G", "CG" };
            _agrosoils[23] = new[] { "Агротемно-гумусовые перегнойно-глеевые", "PU", "H", "G", "CG" };
            //Агро Аккумулятивно-гумусовые почвы
            _agrosoils[24] = new[] { "Агро-черноземы", "PU", "AU", "BCA", "Cca" };
            _agrosoils[25] = new[] { "Агрочерноземы глинисто-иллювиальные", "PU", "AU", "BI", "(BCA)", "C(ca)" };
            _agrosoils[26] = new[] { "Агрочерноземы текстурно-карбонатные", "PU", "AU", "CAT", "Cca" };
            _agrosoils[27] = new[] { "Агрослитые темные", "PU", "AU", "V", "Cca" };
            _agrosoils[28] = new[] { "Агро-черноземо-видные", "PU", "AU", "CRH", "Cg" };
            _agrosoils[29] = new[] { "Агро-черноземы квазиглеевые", "PU", "AU", "BCA", "Q", "CQ" };
            _agrosoils[30] = new[] { "Агро черноземы глинисто-иллювиальные квазиглеевые", "PU", "AU", "BI", "(BCA)", "Q", "CQ" };
            _agrosoils[31] = new[] { "Агро черноземы глинисто-иллювиальные глеевые", "PU", "AU", "BI", "(BCA)", "G", "CG(ca)" };
            _agrosoils[32] = new[] { "Агро-черноземы текстурно-карбонатные квазиглеевые", "PU", "AU", "CAT", "Q", "CQ" };
            _agrosoils[33] = new[] { "Агро-черноземо-видные глеевые", "PU", "AU", "CRH", "G", "CG" };
            //Агро Щелочно-глинисто-дифференцированные почвы
            _agrosoils[34] = new[] { "Агросолонцы темногумусовые", "PU", "ASN", "BCAs,cs", "Cca,s" };
            _agrosoils[35] = new[] { "Агросолонцы", "P", "BSN", "BCAs,cs", "Cca,s" };
            _agrosoils[36] = new[] { "Агросолонцы темногумусовые квазиглеевые", "PU", "ASN", "BCAs,cs", "Qs", "Cca,s" };
            _agrosoils[37] = new[] { "Агрослонцы квазиглеевые", "P", "BSN", "BCAs,cs", "Qs", "Cca,s" };
            //Агро Гидрометаморфические почвы
            _agrosoils[38] = new[] { "Агрогумусово-квазиглеевые", "PU", "AU", "Q", "CQ" };
            _agrosoils[39] = new[] { "Агроперегнойные квазиглеевые", "PU", "H", "Q", "CQ" };
            //Агро Органо-аккумулятивные почвы
            _agrosoils[40] = new[] { "Агро-гумусовые", "P", "AY", "C" };
            _agrosoils[41] = new[] { "Агротемно-гумусовые", "PU", "AU", "C" };
            //Агро Элювиальные почвы
            _agrosoils[42] = new[] { "Агродерново-элювоземы", "P", "EL", "D" };
            _agrosoils[43] = new[] { "Агродерново-элювоземы глеевые", "P", "EL", "DG" };
            _agrosoils[44] = new[] { "Агроторфяно-элювоземы глеевые", "PT", "(T)", "EL", "DG" };
            //Агро Литоземы
            _agrosoils[45] = new[] { "Агролитоземы темногумусовые", "PU", "R(ca)" };
            _agrosoils[46] = new[] { "Агро-литоземы гумусовые", "P", "R(ca)" };
            //Агроабраземы
            _agrosoils[47] = new[] { "Агроабраземы", "PB", "C" };
            _agrosoils[48] = new[] { "Агроабраземы глеевые", "PB", "G", "CG" };
            _agrosoils[49] = new[] { "Агроабраземы квазиглеевые", "PB", "Q", "CQ" };
            _agrosoils[50] = new[] { "Агроабраземы глинисто-иллювиальные", "PB", "BI", "C(ca)" };
            _agrosoils[51] = new[] { "Агроабраземы глинисто-иллювиальные глеевые", "PB", "BI", "G", "CG" };
            _agrosoils[52] = new[] { "Агроабраземы альфегумусовые", "PB", "BHF", "C" };
            _agrosoils[53] = new[] { "Агроабраземы альфегумусовые глеевые", "PB", "BH", "G", "CG" };
            _agrosoils[54] = new[] { "Агроабраземы структурно-метаморфические", "PB", "BM", "C" };
            _agrosoils[55] = new[] { "Агроабраземы структурно-метаморфические аккумулятивно-карбонатные", "PB", "BM", "BCA", "Cca" };
            _agrosoils[56] = new[] { "Агроабраземы аккумулятивно-карбонатные", "PB", "BCA", "Cca" };
            _agrosoils[57] = new[] { "Агроабраземы аккумулятивно-карбонатные квазиглеевые", "PB", "BCA", "Q", "CQ" };
            _agrosoils[58] = new[] { "Агроабраземы текстурно-карбонатные", "PB", "CAT", "Cca" };
            _agrosoils[59] = new[] { "Агроабраземы текстурно-карбонатные квазиглеевые", "PB", "CAT", "Q", "CQ" };
            //Агроземы
            _agrosoils[60] = new[] { "Агроземы", "P", "C" };
            _agrosoils[61] = new[] { "Агроземы темные", "PU", "C" };
            _agrosoils[62] = new[] { "Агроземы темные глеевые", "PU", "G", "CG" };
            _agrosoils[63] = new[] { "Агроземы темные квазиглеевые", "PU", "Q", "CQ" };
            _agrosoils[64] = new[] { "Агроземы торфяные", "PT", "C" };
            _agrosoils[65] = new[] { "Агроземы торфяно-минеральные", "PTR", "C" };
            _agrosoils[66] = new[] { "Агроземы текстурно-дифферен-цированные", "P", "BT", "C" };
            _agrosoils[67] = new[] { "Агроземы текстурно-дифферен-цированные глеевые", "P", "BT", "G", "CG" };
            _agrosoils[68] = new[] { "Агроземы альфегумусовые", "P", "BHF", "C" };
            _agrosoils[69] = new[] { "Агроземы альфегумусовые глеевые", "P", "BH", "G", "CG" };
            _agrosoils[70] = new[] { "Агроземы структурно-метаморфические", "P", "BM", "C" };
            _agrosoils[71] = new[] { "Агроземы структурно-метаморфические темные", "PU", "BM", "C" };
            _agrosoils[72] = new[] { "Агроземы темные глинисто-иллювиальные", "PU", "BI", "C" };
            _agrosoils[73] = new[] { "Агроземы темные аккумулятивно-карбонатные", "PU", "BCA", "Cca" };
            _agrosoils[74] = new[] { "Агроземы текстурно-карбонатные", "P", "CAT", "Cca" };
            _agrosoils[75] = new[] { "Агроземы солонцовые темные", "PU", "TUR{SEL ASN", "BCAs,cs", "Cca,s" };
            _agrosoils[76] = new[] { "Агроземы солонцовые светлые", "P", "TUR{SEL BSN", "BCAs,cs", "Cca,s" };
            _agrosoils[77] = new[] { "Агроземы солонцовые темные квазиглеевые", "PU", "TUR{SEL ASN", "BCAs,cs", "Qs", "CQca,s" };
            _agrosoils[78] = new[] { "Агроземы солонцовые светлые квазиглеевые", "P", "TUR{SEL BSN", "BCAs,cs", "Qs", "CQca,s" };
            //Агро Аллювиальные почвы
            _agrosoils[79] = new[] { "Аллювиальные агрогумусовые", "P", "AY", "C~~" };
            _agrosoils[80] = new[] { "Аллювиальные агротемно-гумусовые", "PU", "AU", "C~~", "Cca" };
            _agrosoils[81] = new[] { "Аллювиальные агротемно-гумусовые глеевые", "PU", "AUg", "G", "CG~~" };
            _agrosoils[82] = new[] { "Аллювиальные агротемно-гумусовые квазиглеевые", "PU", "AU", "Q", "CQ~~" };
            _agrosoils[83] = new[] { "Аллювиальные агрогумусово-глеевые", "P", "AYg", "G", "CG~~" };
            _agrosoils[84] = new[] { "Аллювиальные агрослитые", "PU", "AU", "V", "C~~" };
            _agrosoils[85] = new[] { "Аллювиальные агроторфяно-минеральные глеевые", "PTR", "T", "G", "CG~~" };
            _agrosoils[86] = new[] { "Аллювиальные мергелистые", "PU", "AU", "MIL", "CG~~" };
            //Агро Вулканические
            _agrosoils[87] = new[] { "Агроохристые", "P", "BAN", "C``", "{ABC}", "{ABC}" };
            //Агро Стратоземы
            _agrosoils[88] = new[] { "Агро-стратоземы гумусовые", "P", "RY(RJ)", "D" };
            _agrosoils[89] = new[] { "Агростратоземы темногумусовые", "PU", "RU", "D" };
            _agrosoils[90] = new[] { "Агростратоземы гумусовые на погребенной почве", "P", "RY(RJ)", "[ABC]" };
            _agrosoils[91] = new[] { "Агростратоземы темногумусовые на погребенной почве", "PU", "RU", "[ABC]" };
            //Aгро Tорфоземы
            _agrosoils[92] = new[] { "Торфоземы агроминеральные", "PTR", "TT" };
            _agrosoils[93] = new[] { "Торфоземы агроминеральные глеевые", "PTR", "TT", "G" };
            #endregion

            for (var i = 0; i < _soils.Length; i++){
                Indices.Add(i);
            }
            if (difficult != "Легко"){
                for (var i = 0; i < _agrosoils.Length; i++){
                    Agroindices.Add(i);
                }
            }
        }

        public static string[] FillArray()
        {
            for (var i =0;i<SoilAndHorizontsName.Length;i++){
                SoilAndHorizontsName[i] = "";
            }
            var horrizontsToUse = new string[11];
            var rnd = new Random();
            horrizontsToUse[0] = "";

            if (_difficult != "Легко"){
                var random = rnd.Next(2);
                if (random == 0){
                    FillingMainPart(horrizontsToUse, Agroindices, _agrosoils);
                }
            }
            else{
                FillingMainPart(horrizontsToUse, Indices, _soils);
            }
            return FillingOther(horrizontsToUse);
        }

        private static void FillingMainPart(string[] horrizontsToUse, List<int> indicesToUse, string[][] soilsArray)
        {
            var rnd = new Random();
            var randomSoil = 0;
            var arrayIndices = new List<int>();
            for (var i = 1; i < 11; i++)
            {
                arrayIndices.Add(i);
            }
            var random = rnd.Next(indicesToUse.Count);
            randomSoil = indicesToUse[random];
            indicesToUse.RemoveAt(random);
            for (var i = 1; i < soilsArray[randomSoil].Length; i++)
            {
                random = rnd.Next(arrayIndices.Count);
                horrizontsToUse[arrayIndices[random]] = soilsArray[randomSoil][i];
                arrayIndices.RemoveAt(random);
            }
            SaveCurrentSoil(soilsArray[randomSoil]);
        }

        private static string[] FillingOther(string[] horrizontsToUse){
            var rnd = new Random();
            for (var i = 1; i< 11; i++){
                if (String.IsNullOrEmpty(horrizontsToUse[i])){
                    while (true){
                        var randomString = _horrizonts[rnd.Next(_horrizonts.Length)];
                        if (!Array.Exists(horrizontsToUse, element => element == randomString)){
                            horrizontsToUse[i] = randomString;
                            break;
                        }
                    }
                }
            }
            return horrizontsToUse;
        }

        private static void SaveCurrentSoil(string[] soilsArray){
            for (var i = 0; i < soilsArray.Length; i++){
                SoilAndHorizontsName[i] = soilsArray[i];
            }
        }
    }
}