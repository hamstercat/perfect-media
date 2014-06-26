using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.FileInformation
{
    internal static class LanguageHelper
    {
        // Taken from MediaCompanion (https://mediacompanion.codeplex.com/)
        internal static string GetLanguageCode(string language)
        {
            switch (language.ToLower())
            {
                case "english":
                    return "eng";
                case "french":
                    return "fre";
                case "japanese":
                    return "jpn";
                case "":
                    return "";
                case "german":
                    return "deu";
                case "afar":
                    return "aar";
                case "abkhazian":
                    return "abk";
                case "achinese":
                    return "ace";
                case "acoli":
                    return "ach";
                case "adangme":
                    return "ada";
                case "adyghe":
                case "adygei":
                    return "ady";
                case "afroasiatic (other)":
                    return "afa";
                case "afrihili":
                    return "afh";
                case "afrikaans":
                    return "afr";
                case "ainu":
                    return "ain";
                case "akan":
                    return "aka";
                case "akkadian":
                    return "akk";
                case "albanian":
                    return "alb";
                case "aleut":
                    return "ale";
                case "algonquian languages":
                    return "alg";
                case "southern altai":
                    return "alt";
                case "amharic":
                    return "amh";
                case "angika":
                    return "anp";
                case "apache languages":
                    return "apa";
                case "arabic":
                    return "ara";
                case "official aramaic (700300 bce)":
                case "imperial aramaic (700300 bce)":
                    return "arc";
                case "aragonese":
                    return "arg";
                case "armenian":
                    return "arm";
                case "mapudungun":
                case "mapuche":
                    return "arn";
                case "arapaho":
                    return "arp";
                case "artificial (other)":
                    return "art";
                case "arawak":
                    return "arw";
                case "assamese":
                    return "asm";
                case "asturian":
                case "bable":
                case "leonese":
                case "asturleonese":
                    return "ast";
                case "athapascan languages":
                    return "ath";
                case "australian languages":
                    return "aus";
                case "avaric":
                    return "ava";
                case "avestan":
                    return "ave";
                case "awadhi":
                    return "awa";
                case "aymara":
                    return "aym";
                case "azerbaijani":
                    return "aze";
                case "banda languages":
                    return "bad";
                case "bamileke languages":
                    return "bai";
                case "bashkir":
                    return "bak";
                case "baluchi":
                    return "bal";
                case "bambara":
                    return "bam";
                case "balinese":
                    return "ban";
                case "basque":
                    return "baq";
                case "basa":
                    return "bas";
                case "baltic (other)":
                    return "bat";
                case "beja":
                case "bedawiyet":
                    return "bej";
                case "belarusian":
                    return "bel";
                case "bemba":
                    return "bem";
                case "bengali":
                    return "ben";
                case "berber (other)":
                    return "ber";
                case "bhojpuri":
                    return "bho";
                case "bihari":
                    return "bih";
                case "bikol":
                    return "bik";
                case "bini":
                case "edo":
                    return "bin";
                case "bislama":
                    return "bis";
                case "siksika":
                    return "bla";
                case "bantu (other)":
                    return "bnt";
                case "bosnian":
                    return "bos";
                case "braj":
                    return "bra";
                case "breton":
                    return "bre";
                case "batak languages":
                    return "btk";
                case "buriat":
                    return "bua";
                case "buginese":
                    return "bug";
                case "bulgarian":
                    return "bul";
                case "burmese":
                    return "bur";
                case "blin":
                case "bilin":
                    return "byn";
                case "caddo":
                    return "cad";
                case "central american indian (other)":
                    return "cai";
                case "galibi carib":
                    return "car";
                case "catalan":
                case "valencian":
                    return "cat";
                case "caucasian (other)":
                    return "cau";
                case "cebuano":
                    return "ceb";
                case "celtic (other)":
                    return "cel";
                case "chamorro":
                    return "cha";
                case "chibcha":
                    return "chb";
                case "chechen":
                    return "che";
                case "chagatai":
                    return "chg";
                case "chinese":
                    return "chi";
                case "chuukese":
                    return "chk";
                case "mari":
                    return "chm";
                case "chinook jargon":
                    return "chn";
                case "choctaw":
                    return "cho";
                case "chipewyan":
                case "dene suline":
                    return "chp";
                case "cherokee":
                    return "chr";
                case "church slavic":
                case "old slavonic":
                case "church slavonic":
                case "old bulgarian":
                case "old church slavonic":
                    return "chu";
                case "chuvash":
                    return "chv";
                case "cheyenne":
                    return "chy";
                case "chamic languages":
                    return "cmc";
                case "coptic":
                    return "cop";
                case "cornish":
                    return "cor";
                case "corsican":
                    return "cos";
                case "creoles and pidgins":
                    return "cpe";
                case "cree":
                    return "cre";
                case "crimean tatar":
                case "crimean turkish":
                    return "crh";
                case "creoles and pidgins (other)":
                    return "crp";
                case "kashubian":
                    return "csb";
                case "cushitic (other)":
                    return "cus";
                case "czech":
                    return "cze";
                case "dakota":
                    return "dak";
                case "danish":
                    return "dan";
                case "dargwa":
                    return "dar";
                case "land dayak languages":
                    return "day";
                case "delaware":
                    return "del";
                case "slave (athapascan)":
                    return "den";
                case "dogrib":
                    return "dgr";
                case "dinka":
                    return "din";
                case "divehi":
                case "dhivehi":
                case "maldivian":
                    return "div";
                case "dogri":
                    return "doi";
                case "dravidian (other)":
                    return "dra";
                case "lower sorbian":
                    return "dsb";
                case "duala":
                    return "dua";
                case "dutch":
                case "flemish":
                    return "dut";
                case "dyula":
                    return "dyu";
                case "dzongkha":
                    return "dzo";
                case "efik":
                    return "efi";
                case "egyptian (ancient)":
                    return "egy";
                case "ekajuk":
                    return "eka";
                case "elamite":
                    return "elx";
                case "esperanto":
                    return "epo";
                case "estonian":
                    return "est";
                case "ewe":
                    return "ewe";
                case "ewondo":
                    return "ewo";
                case "fang":
                    return "fan";
                case "faroese":
                    return "fao";
                case "fanti":
                    return "fat";
                case "fijian":
                    return "fij";
                case "filipino":
                case "pilipino":
                    return "fil";
                case "finnish":
                    return "fin";
                case "finnougrian (other)":
                    return "fiu";
                case "fon":
                    return "fon";
                case "northern frisian":
                    return "frr";
                case "eastern frisian":
                    return "frs";
                case "western frisian":
                    return "fry";
                case "fulah":
                    return "ful";
                case "friulian":
                    return "fur";
                case "ga":
                    return "gaa";
                case "gayo":
                    return "gay";
                case "gbaya":
                    return "gba";
                case "germanic (other)":
                    return "gem";
                case "georgian":
                    return "geo";
                case "geez":
                    return "gez";
                case "gilbertese":
                    return "gil";
                case "gaelic":
                case "scottish gaelic":
                    return "gla";
                case "irish":
                    return "gle";
                case "galician":
                    return "glg";
                case "manx":
                    return "glv";
                case "gondi":
                    return "gon";
                case "gorontalo":
                    return "gor";
                case "gothic":
                    return "got";
                case "grebo":
                    return "grb";
                case "greek":
                    return "gre";
                case "guarani":
                    return "grn";
                case "swiss german":
                case "alemannic":
                case "alsatian":
                    return "gsw";
                case "gujarati":
                    return "guj";
                case "gwich'in":
                    return "gwi";
                case "haida":
                    return "hai";
                case "haitian":
                case "haitian creole":
                    return "hat";
                case "hausa":
                    return "hau";
                case "hawaiian":
                    return "haw";
                case "hebrew":
                    return "heb";
                case "herero":
                    return "her";
                case "hiligaynon":
                    return "hil";
                case "himachali":
                    return "him";
                case "hindi":
                    return "hin";
                case "hittite":
                    return "hit";
                case "hmong":
                    return "hmn";
                case "hiri motu":
                    return "hmo";
                case "croatian":
                    return "hrv";
                case "upper sorbian":
                    return "hsb";
                case "hungarian":
                    return "hun";
                case "hupa":
                    return "hup";
                case "iban":
                    return "iba";
                case "igbo":
                    return "ibo";
                case "icelandic":
                    return "ice";
                case "ido":
                    return "ido";
                case "sichuan yi":
                case "nuosu":
                    return "iii";
                case "ijo languages":
                    return "ijo";
                case "inuktitut":
                    return "iku";
                case "interlingue":
                case "occidental":
                    return "ile";
                case "iloko":
                    return "ilo";
                case "interlingua (international auxiliary language association)":
                    return "ina";
                case "indic (other)":
                    return "inc";
                case "indonesian":
                    return "ind";
                case "indoeuropean (other)":
                    return "ine";
                case "ingush":
                    return "inh";
                case "inupiaq":
                    return "ipk";
                case "iranian (other)":
                    return "ira";
                case "iroquoian languages":
                    return "iro";
                case "italian":
                    return "ita";
                case "javanese":
                    return "jav";
                case "lojban":
                    return "jbo";
                case "judeopersian":
                    return "jpr";
                case "judeoarabic":
                    return "jrb";
                case "karakalpak":
                    return "kaa";
                case "kabyle":
                    return "kab";
                case "kachin":
                case "jingpho":
                    return "kac";
                case "kalaallisut":
                case "greenlandic":
                    return "kal";
                case "kamba":
                    return "kam";
                case "kannada":
                    return "kan";
                case "karen languages":
                    return "kar";
                case "kashmiri":
                    return "kas";
                case "kanuri":
                    return "kau";
                case "kawi":
                    return "kaw";
                case "kazakh":
                    return "kaz";
                case "kabardian":
                    return "kbd";
                case "khasi":
                    return "kha";
                case "khoisan (other)":
                    return "khi";
                case "central khmer":
                    return "khm";
                case "khotanese":
                case "sakan":
                    return "kho";
                case "kikuyu":
                case "gikuyu":
                    return "kik";
                case "kinyarwanda":
                    return "kin";
                case "kirghiz":
                case "kyrgyz":
                    return "kir";
                case "kimbundu":
                    return "kmb";
                case "konkani":
                    return "kok";
                case "komi":
                    return "kom";
                case "kongo":
                    return "kon";
                case "korean":
                    return "kor";
                case "kosraean":
                    return "kos";
                case "kpelle":
                    return "kpe";
                case "karachaybalkar":
                    return "krc";
                case "karelian":
                    return "krl";
                case "kru languages":
                    return "kro";
                case "kurukh":
                    return "kru";
                case "kuanyama":
                case "kwanyama":
                    return "kua";
                case "kumyk":
                    return "kum";
                case "kurdish":
                    return "kur";
                case "kutenai":
                    return "kut";
                case "ladino":
                    return "lad";
                case "lahnda":
                    return "lah";
                case "lamba":
                    return "lam";
                case "lao":
                    return "lao";
                case "latin":
                    return "lat";
                case "latvian":
                    return "lav";
                case "lezghian":
                    return "lez";
                case "limburgan":
                case "limburger":
                case "limburgish":
                    return "lim";
                case "lingala":
                    return "lin";
                case "lithuanian":
                    return "lit";
                case "mongo":
                    return "lol";
                case "lozi":
                    return "loz";
                case "luxembourgish":
                case "letzeburgesch":
                    return "ltz";
                case "lubalulua":
                    return "lua";
                case "lubakatanga":
                    return "lub";
                case "ganda":
                    return "lug";
                case "luiseno":
                    return "lui";
                case "lunda":
                    return "lun";
                case "luo (kenya and tanzania)":
                    return "luo";
                case "lushai":
                    return "lus";
                case "macedonian":
                    return "mac";
                case "madurese":
                    return "mad";
                case "magahi":
                    return "mag";
                case "marshallese":
                    return "mah";
                case "maithili":
                    return "mai";
                case "makasar":
                    return "mak";
                case "malayalam":
                    return "mal";
                case "mandingo":
                    return "man";
                case "maori":
                    return "mao";
                case "austronesian (other)":
                    return "map";
                case "marathi":
                    return "mar";
                case "masai":
                    return "mas";
                case "malay":
                    return "may";
                case "moksha":
                    return "mdf";
                case "mandar":
                    return "mdr";
                case "mende":
                    return "men";
                case "mi'kmaq":
                case "micmac":
                    return "mic";
                case "minangkabau":
                    return "min";
                case "uncoded languages":
                    return "mis";
                case "monkhmer (other)":
                    return "mkh";
                case "malagasy":
                    return "mlg";
                case "maltese":
                    return "mlt";
                case "manchu":
                    return ("mnc");
                case "manipuri":
                    return "mni";
                case "manobo languages":
                    return "mno";
                case "mohawk":
                    return "moh";
                case "mongolian":
                    return "mon";
                case "mossi":
                    return "mos";
                case "multiple languages":
                    return "mul";
                case "munda languages":
                    return "mun";
                case "creek":
                    return "mus";
                case "mirandese":
                    return "mwl";
                case "marwari":
                    return "mwr";
                case "mayan languages":
                    return "myn";
                case "erzya":
                    return "myv";
                case "nahuatl languages":
                    return "nah";
                case "north american indian":
                    return "nai";
                case "neapolitan":
                    return "nap";
                case "nauru":
                    return "nau";
                case "navajo":
                case "navaho":
                    return "nav";
                case "ndebele":
                    return "nbl";
                case "ndonga":
                    return "ndo";
                case "low german":
                case "low saxon":
                    return "nds";
                case "nepali":
                    return "nep";
                case "nepal bhasa":
                case "newari":
                    return "new";
                case "nias":
                    return "nia";
                case "nigerkordofanian (other)":
                    return "nic";
                case "niuean":
                    return "niu";
                case "norwegian nynorsk":
                case "nynorsk":
                    return "nno";
                case "bokmål":
                    return "nob";
                case "nogai":
                    return "nog";
                case "norse":
                    return "non";
                case "norwegian":
                    return "nor";
                case "n'ko":
                    return "nqo";
                case "pedi":
                case "sepedi":
                case "northern sotho":
                    return "nso";
                case "nubian languages":
                    return "nub";
                case "classical newari":
                case "old newari":
                case "classical nepal bhasa":
                    return "nwc";
                case "chichewa":
                case "chewa":
                case "nyanja":
                    return "nya";
                case "nyamwezi":
                    return "nym";
                case "nyankole":
                    return "nyn";
                case "nyoro":
                    return "nyo";
                case "nzima":
                    return "nzi";
                case "occitan (post 1500)":
                    return "oci";
                case "ojibwa":
                    return "oji";
                case "oriya":
                    return "ori";
                case "oromo":
                    return "orm";
                case "osage":
                    return "osa";
                case "ossetian":
                case "ossetic":
                    return "oss";
                case "otomian languages":
                    return "oto";
                case "papuan (other)":
                    return "paa";
                case "pangasinan":
                    return "pag";
                case "pahlavi":
                    return "pal";
                case "pampanga":
                case "kapampangan":
                    return "pam";
                case "panjabi":
                case "punjabi":
                    return "pan";
                case "papiamento":
                    return "pap";
                case "palauan":
                    return "pau";
                case "persian":
                    return "per";
                case "philippine (other)":
                    return "phi";
                case "phoenician":
                    return "phn";
                case "pali":
                    return "pli";
                case "polish":
                    return "pol";
                case "pohnpeian":
                    return "pon";
                case "portuguese":
                    return "por";
                case "prakrit languages":
                    return "pra";
                case "provençal":
                    return "pro";
                case "pushto":
                case "pashto":
                    return "pus";
                case "reserved for local use":
                    return "qaaqtz";
                case "quechua":
                    return "que";
                case "rajasthani":
                    return "raj";
                case "rapanui":
                    return "rap";
                case "rarotongan":
                case "cook islands maori":
                    return "rar";
                case "romance (other)":
                    return "roa";
                case "romansh":
                    return "roh";
                case "romany":
                    return "rom";
                case "romanian":
                case "moldavian":
                case "moldovan":
                    return "rum";
                case "rundi":
                    return "run";
                case "aromanian":
                case "arumanian":
                case "macedoromanian":
                    return "rup";
                case "russian":
                    return "rus";
                case "sandawe":
                    return "sad";
                case "sango":
                    return "sag";
                case "yakut":
                    return "sah";
                case "south american indian (other)":
                    return "sai";
                case "salishan languages":
                    return "sal";
                case "samaritan aramaic":
                    return "sam";
                case "sanskrit":
                    return "san";
                case "sasak":
                    return "sas";
                case "santali":
                    return "sat";
                case "sicilian":
                    return "scn";
                case "scots":
                    return "sco";
                case "selkup":
                    return "sel";
                case "semitic (other)":
                    return "sem";
                case "sign languages":
                    return "sgn";
                case "shan":
                    return "shn";
                case "sidamo":
                    return "sid";
                case "sinhala":
                case "sinhalese":
                    return "sin";
                case "siouan languages":
                    return "sio";
                case "sinotibetan (other)":
                    return "sit";
                case "slavic (other)":
                    return "sla";
                case "slovak":
                    return "slo";
                case "slovenian":
                    return "slv";
                case "southern sami":
                    return "sma";
                case "northern sami":
                    return "sme";
                case "sami languages (other)":
                    return "smi";
                case "lule sami":
                    return "smj";
                case "inari sami":
                    return "smn";
                case "samoan":
                    return "smo";
                case "skolt sami":
                    return "sms";
                case "shona":
                    return "sna";
                case "sindhi":
                    return "snd";
                case "soninke":
                    return "snk";
                case "sogdian":
                    return "sog";
                case "somali":
                    return "som";
                case "songhai languages":
                    return "son";
                case "sotho":
                    return "sot";
                case "spanish":
                case "castilian":
                    return "spa";
                case "sardinian":
                    return "srd";
                case "sranan tongo":
                    return "srn";
                case "serbian":
                    return "srp";
                case "serer":
                    return "srr";
                case "nilosaharan (other)":
                    return "ssa";
                case "swati":
                    return "ssw";
                case "sukuma":
                    return "suk";
                case "sundanese":
                    return "sun";
                case "susu":
                    return "sus";
                case "sumerian":
                    return "sux";
                case "swahili":
                    return "swa";
                case "swedish":
                    return "swe";
                case "classical syriac":
                    return "syc";
                case "syriac":
                    return "syr";
                case "tahitian":
                    return "tah";
                case "tai (other)":
                    return "tai";
                case "tamil":
                    return "tam";
                case "tatar":
                    return "tat";
                case "telugu":
                    return "tel";
                case "timne":
                    return "tem";
                case "tereno":
                    return "ter";
                case "tetum":
                    return "tet";
                case "tajik":
                    return "tgk";
                case "tagalog":
                    return "tgl";
                case "thai":
                    return "tha";
                case "tibetan":
                    return "tib";
                case "tigre":
                    return "tig";
                case "tigrinya":
                    return "tir";
                case "tiv":
                    return "tiv";
                case "tokelau":
                    return "tkl";
                case "klingon":
                case "tlhinganhol":
                    return "tlh";
                case "tlingit":
                    return "tli";
                case "tamashek":
                    return "tmh";
                case "tonga (nyasa)":
                    return "tog";
                case "tonga (tonga islands)":
                    return "ton";
                case "tok pisin":
                    return "tpi";
                case "tsimshian":
                    return "tsi";
                case "tswana":
                    return "tsn";
                case "tsonga":
                    return "tso";
                case "turkmen":
                    return "tuk";
                case "tumbuka":
                    return "tum";
                case "tupi languages":
                    return "tup";
                case "turkish":
                    return "tur";
                case "altaic (other)":
                    return "tut";
                case "tuvalu":
                    return "tvl";
                case "twi":
                    return "twi";
                case "tuvinian":
                    return "tyv";
                case "udmurt":
                    return "udm";
                case "ugaritic":
                    return "uga";
                case "uighur":
                case "uyghur":
                    return "uig";
                case "ukrainian":
                    return "ukr";
                case "umbundu":
                    return "umb";
                case "undetermined":
                    return "und";
                case "urdu":
                    return "urd";
                case "uzbek":
                    return "uzb";
                case "vai":
                    return "vai";
                case "venda":
                    return "ven";
                case "vietnamese":
                    return "vie";
                case "volapük":
                    return "vol";
                case "votic":
                    return "vot";
                case "wakashan languages":
                    return "wak";
                case "walamo":
                    return "wal";
                case "waray":
                    return "war";
                case "washo":
                    return "was";
                case "welsh":
                    return "wel";
                case "sorbian languages":
                    return "wen";
                case "walloon":
                    return "wln";
                case "wolof":
                    return "wol";
                case "kalmyk":
                case "oirat":
                    return "xal";
                case "xhosa":
                    return "xho";
                case "yao":
                    return "yao";
                case "yapese":
                    return "yap";
                case "yiddish":
                    return "yid";
                case "yoruba":
                    return "yor";
                case "yupik languages":
                    return "ypk";
                case "zapotec":
                    return "zap";
                case "blissymbols":
                case "blissymbolics":
                case "bliss":
                    return "zbl";
                case "zenaga":
                    return "zen";
                case "zhuang":
                case "chuang":
                    return "zha";
                case "zande languages":
                    return "znd";
                case "zulu":
                    return "zul";
                case "zuni":
                    return "zun";
                case "no linguistic content":
                case "not applicable":
                    return "zxx";
                case "zaza":
                case "dimili":
                case "dimli":
                case "kirdki":
                case "kirmanjki":
                case "zazaki":
                    return "zza";
                default:
                    return "";
            }
        }
    }
}
