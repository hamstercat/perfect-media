using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.FileInformation
{
    internal static class LanguageHelper
    {
        internal static string GetLanguageCode(string language)
        {
            switch (language.ToLower())
            {
                case "aari":
                    return "aiw";
                case "aariya":
                    return "aay";
                case "aasáx":
                    return "aas";
                case "abadi":
                    return "kbt";
                case "abaga":
                    return "abg";
                case "abai sungai":
                    return "abf";
                case "abanyom":
                    return "abm";
                case "abar":
                    return "mij";
                case "abau":
                    return "aau";
                case "abaza":
                    return "abq";
                case "abé":
                    return "aba";
                case "abenlen ayta":
                    return "abp";
                case "abidji":
                    return "abi";
                case "abinomn":
                    return "bsa";
                case "abipon":
                    return "axb";
                case "abishira":
                    return "ash";
                case "abkhazian":
                    return "abk";
                case "abom":
                    return "aob";
                case "abon":
                    return "abo";
                case "abron":
                    return "abr";
                case "abu":
                    return "ado";
                case "abua":
                    return "abn";
                case "abui":
                    return "abz";
                case "abun":
                    return "kgr";
                case "abure":
                    return "abu";
                case "abureni":
                    return "mgj";
                case "acatenango southwestern cakchiquel":
                    return "ckk";
                case "acatepec tlapanec":
                    return "tpx";
                case "achagua":
                    return "aca";
                case "achang":
                    return "acn";
                case "ache":
                    return "yif";
                case "aché":
                    return "guq";
                case "acheron":
                    return "acz";
                case "achinese":
                    return "ace";
                case "achterhoeks":
                    return "act";
                case "achuar-shiwiar":
                    return "acu";
                case "achumawi":
                    return "acv";
                case "acoli":
                    return "ach";
                case "acroá":
                    return "acs";
                case "adabe":
                    return "adb";
                case "adai":
                    return "xad";
                case "adamawa fulfulde":
                    return "fub";
                case "adang":
                    return "adn";
                case "adangbe":
                    return "adq";
                case "adangme":
                    return "ada";
                case "adap":
                    return "adp";
                case "adasen":
                    return "tiu";
                case "adele":
                    return "ade";
                case "adhola":
                    return "adh";
                case "adi":
                    return "adi";
                case "adioukrou":
                    return "adj";
                case "adivasi oriya":
                    return "ort";
                case "adiwasi garasia":
                    return "gas";
                case "adnyamathanha":
                    return "adt";
                case "adonara":
                    return "adr";
                case "aduge":
                    return "adu";
                case "adygei":
                    return "ady";
                case "adzera":
                    return "adz";
                case "aeka":
                    return "aez";
                case "aekyom":
                    return "awi";
                case "aequian":
                    return "xae";
                case "aer":
                    return "aeq";
                case "afade":
                    return "aal";
                case "afar":
                    return "aar";
                case "afitti":
                    return "aft";
                case "afra":
                    return "ulf";
                case "afrihili":
                    return "afh";
                case "afrikaans":
                    return "afr";
                case "afro-seminole creole":
                    return "afs";
                case "agarabi":
                    return "agd";
                case "agariya":
                    return "agi";
                case "agatu":
                    return "agc";
                case "agavotaguerra":
                    return "avo";
                case "aghem":
                    return "agq";
                case "aghu":
                    return "ahh";
                case "aghu tharnggalu":
                    return "ggr";
                case "aghul":
                    return "agx";
                case "aghwan":
                    return "xag";
                case "agi":
                    return "aif";
                case "agob":
                    return "kit";
                case "agoi":
                    return "ibm";
                case "aguacateco":
                    return "agu";
                case "aguano":
                    return "aga";
                case "aguaruna":
                    return "agr";
                case "aguna":
                    return "aug";
                case "agusan manobo":
                    return "msm";
                case "agutaynen":
                    return "agn";
                case "agwagwune":
                    return "yay";
                case "àhàn":
                    return "ahn";
                case "ahanta":
                    return "aha";
                case "aheu":
                    return "thm";
                case "ahirani":
                    return "ahr";
                case "a-hmaos":
                    return "hmd";
                case "ahom":
                    return "aho";
                case "ahtena":
                    return "aht";
                case "ai-cham":
                    return "aih";
                case "aighon":
                    return "aix";
                case "aikanã":
                    return "tba";
                case "aiklep":
                    return "mwg";
                case "aimaq":
                    return "aiq";
                case "aimele":
                    return "ail";
                case "aimol":
                    return "aim";
                case "ainbai":
                    return "aic";
                case "ainu (china)":
                    return "aib";
                case "ainu (japan)":
                    return "ain";
                case "aiome":
                    return "aki";
                case "airoran":
                    return "air";
                case "aiton":
                    return "aio";
                case "aja (benin)":
                    return "ajg";
                case "aja (sudan)":
                    return "aja";
                case "ajawa":
                    return "ajw";
                case "ajië":
                    return "aji";
                case "ajyíninka apurucayali":
                    return "cpc";
                case "ak":
                    return "akq";
                case "aka":
                    return "soh";
                case "aka-bea":
                    return "abj";
                case "aka-bo":
                    return "akm";
                case "aka-cari":
                    return "aci";
                case "aka-jeru":
                    return "akj";
                case "aka-kede":
                    return "akx";
                case "aka-kol":
                    return "aky";
                case "aka-kora":
                    return "ack";
                case "akan":
                    return "aka";
                case "akar-bale":
                    return "acl";
                case "akaselem":
                    return "aks";
                case "akawaio":
                    return "ake";
                case "ake":
                    return "aik";
                case "akebu":
                    return "keu";
                case "akei":
                    return "tsr";
                case "akeu":
                    return "aeu";
                case "akha":
                    return "ahk";
                case "akhvakh":
                    return "akv";
                case "akkadian":
                    return "akk";
                case "akkala sami":
                    return "sia";
                case "aklanon":
                    return "akl";
                case "akolet":
                    return "akt";
                case "akoose":
                    return "bss";
                case "akoye":
                    return "miw";
                case "akpa":
                    return "akf";
                case "akpes":
                    return "ibe";
                case "akrukay":
                    return "afi";
                case "akuku":
                    return "ayk";
                case "akum":
                    return "aku";
                case "akurio":
                    return "ako";
                case "akwa":
                    return "akw";
                case "alaba-k’abeena":
                    return "alw";
                case "alabama":
                    return "akz";
                case "alabat island agta":
                    return "dul";
                case "alacatlatzala mixtec":
                    return "mim";
                case "alago":
                    return "ala";
                case "alagwa":
                    return "wbj";
                case "alak":
                    return "alk";
                case "alamblak":
                    return "amp";
                case "alangan":
                    return "alj";
                case "alanic":
                    return "xln";
                case "alapmunte":
                    return "apv";
                case "alawa":
                    return "alh";
                case "albanian":
                    return "sqi";
                case "albay bicolano":
                    return "bhk";
                case "alcozauca mixtec":
                    return "xta";
                case "alege":
                    return "alf";
                case "alekano":
                    return "gah";
                case "aleut":
                    return "ale";
                case "algerian arabic":
                    return "arq";
                case "algerian saharan arabic":
                    return "aao";
                case "algonquin":
                    return "alq";
                case "ali":
                    return "aiy";
                case "alladian":
                    return "ald";
                case "allar":
                    return "all";
                case "alngith":
                    return "aid";
                case "alo phola":
                    return "ypo";
                case "aloápam zapotec":
                    return "zaq";
                case "alor":
                    return "aol";
                case "alsea":
                    return "aes";
                case "alu kurumba":
                    return "xua";
                case "alugu":
                    return "aub";
                case "alumu-tesu":
                    return "aab";
                case "alune":
                    return "alp";
                case "aluo":
                    return "yna";
                case "alur":
                    return "alz";
                case "alutor":
                    return "alr";
                case "alviri-vidari":
                    return "avd";
                case "alyawarr":
                    return "aly";
                case "ama":
                    return "amm";
                case "amahai":
                    return "amq";
                case "amahuaca":
                    return "amc";
                case "amaimon":
                    return "ali";
                case "amal":
                    return "aad";
                case "amanab":
                    return "amn";
                case "amanayé":
                    return "ama";
                case "amara":
                    return "aie";
                case "amarag":
                    return "amg";
                case "amarakaeri":
                    return "amr";
                case "amarasi":
                    return "aaz";
                case "amatlán zapotec":
                    return "zpo";
                case "amba":
                    return "rwm";
                case "ambai":
                    return "amk";
                case "ambakich":
                    return "aew";
                case "ambala ayta":
                    return "abc";
                case "ambelau":
                    return "amv";
                case "ambele":
                    return "ael";
                case "amblong":
                    return "alm";
                case "ambo":
                    return "amb";
                case "ambonese malay":
                    return "abs";
                case "ambo-pasco quechua":
                    return "qva";
                case "ambrak":
                    return "aag";
                case "ambulas":
                    return "abt";
                case "amdang":
                    return "amj";
                case "amdo tibetan":
                    return "adx";
                case "amele":
                    return "aey";
                case "amganad ifugao":
                    return "ifa";
                case "amharic":
                    return "amh";
                case "ami":
                    return "amy";
                case "amis":
                    return "ami";
                case "amo":
                    return "amo";
                case "amol":
                    return "alx";
                case "amoltepec mixtec":
                    return "mbz";
                case "ampanang":
                    return "apg";
                case "amri karbi":
                    return "ajz";
                case "amto":
                    return "amt";
                case "amundava":
                    return "adw";
                case "ana tinga dogon":
                    return "dti";
                case "anaang":
                    return "anw";
                case "anakalangu":
                    return "akg";
                case "anal":
                    return "anm";
                case "anam":
                    return "pda";
                case "anambé":
                    return "aan";
                case "anamgura":
                    return "imi";
                case "anasi":
                    return "bpo";
                case "áncá":
                    return "acb";
                case "ancient greek":
                    return "grc";
                case "ancient hebrew":
                    return "hbo";
                case "ancient macedonian":
                    return "xmk";
                case "ancient north arabian":
                    return "xna";
                case "ancient zapotec":
                    return "xzp";
                case "andai":
                    return "afd";
                case "andalusian arabic":
                    return "xaa";
                case "andaman creole hindi":
                    return "hca";
                case "andaqui":
                    return "ana";
                case "andarum":
                    return "aod";
                case "andegerebinha":
                    return "adg";
                case "andh":
                    return "anr";
                case "andi":
                    return "ani";
                case "andio":
                    return "bzb";
                case "andoa":
                    return "anb";
                case "andoque":
                    return "ano";
                case "andra-hus":
                    return "anx";
                case "aneityum":
                    return "aty";
                case "anem":
                    return "anz";
                case "aneme wake":
                    return "aby";
                case "anfillo":
                    return "myo";
                case "angaataha":
                    return "agm";
                case "angal":
                    return "age";
                case "angal enen":
                    return "aoe";
                case "angal heneng":
                    return "akh";
                case "angami naga":
                    return "njm";
                case "angguruk yali":
                    return "yli";
                case "angika":
                    return "anp";
                case "anglo-norman":
                    return "xno";
                case "angloromani":
                    return "rme";
                case "angolar":
                    return "aoa";
                case "angor":
                    return "agg";
                case "angoram":
                    return "aog";
                case "angosturas tunebo":
                    return "tnd";
                case "ani":
                    return "hnh";
                case "ani phowa":
                    return "ypn";
                case "anii":
                    return "blo";
                case "animere":
                    return "anf";
                case "anindilyakwa":
                    return "aoi";
                case "anjam":
                    return "boj";
                case "ankave":
                    return "aak";
                case "anmatyerre":
                    return "amx";
                case "anor":
                    return "anj";
                case "anserma":
                    return "ans";
                case "ansus":
                    return "and";
                case "antakarinya":
                    return "ant";
                case "antankarana malagasy":
                    return "xmv";
                case "antigua and barbuda creole english":
                    return "aig";
                case "anu":
                    return "anl";
                case "anuak":
                    return "anu";
                case "anufo":
                    return "cko";
                case "anuki":
                    return "aui";
                case "anus":
                    return "auq";
                case "anuta":
                    return "aud";
                case "anyin":
                    return "any";
                case "anyin morofo":
                    return "mtb";
                case "ao naga":
                    return "njo";
                case "aoheng":
                    return "pni";
                case "aore":
                    return "aor";
                case "ap ma":
                    return "kbx";
                case "apalachee":
                    return "xap";
                case "apalaí":
                    return "apy";
                case "apali":
                    return "ena";
                case "apalik":
                    return "apo";
                case "apasco-apoala mixtec":
                    return "mip";
                case "apatani":
                    return "apt";
                case "apiaká":
                    return "api";
                case "apinayé":
                    return "apn";
                case "apma":
                    return "app";
                case "aproumu aizi":
                    return "ahp";
                case "a-pucikwar":
                    return "apq";
                case "apurinã":
                    return "apu";
                case "aputai":
                    return "apx";
                case "aquitanian":
                    return "xaq";
                case "arabana":
                    return "ard";
                case "arabela":
                    return "arl";
                case "arabic":
                    return "ara";
                case "aragonese":
                    return "arg";
                case "araki":
                    return "akr";
                case "aralle-tabulahan":
                    return "atq";
                case "aramanik":
                    return "aam";
                case "arammba":
                    return "stk";
                case "aranadan":
                    return "aaf";
                case "aranama-tamique":
                    return "xrt";
                case "arandai":
                    return "jbj";
                case "araona":
                    return "aro";
                case "arapaho":
                    return "arp";
                case "arapaso":
                    return "arj";
                case "arawá/aruá":
                    return "aru";
                case "arawak":
                    return "arw";
                case "araweté":
                    return "awt";
                case "arawum":
                    return "awm";
                case "arbëreshë albanian":
                    return "aae";
                case "arbore":
                    return "arv";
                case "archi":
                    return "aqc";
                case "ardhamāgadhī prākrit":
                    return "pka";
                case "are":
                    return "mwc";
                case "areba":
                    return "aea";
                case "arem":
                    return "aem";
                case "arequipa-la unión quechua":
                    return "qxu";
                case "argobba":
                    return "agj";
                case "arguni":
                    return "agf";
                case "arhâ":
                    return "aqr";
                case "arhö":
                    return "aok";
                case "arhuaco":
                    return "arh";
                case "ari":
                    return "aac";
                case "aribwatsa":
                    return "laz";
                case "aribwaung":
                    return "ylu";
                case "arifama-miniafia":
                    return "aai";
                case "arigidi":
                    return "aqg";
                case "arikapú":
                    return "ark";
                case "arikara":
                    return "ari";
                case "arikem":
                    return "ait";
                case "arin":
                    return "xrn";
                case "aringa":
                    return "luc";
                case "arma":
                    return "aoh";
                case "armazic":
                    return "xrm";
                case "armenian":
                    return "hye";
                case "aromanian":
                    return "rup";
                case "arop-lokep":
                    return "apr";
                case "arop-sissano":
                    return "aps";
                case "arosi":
                    return "aia";
                case "arta":
                    return "atz";
                case "aruá":
                    return "arx";
                case "aruamu":
                    return "msy";
                case "aruek":
                    return "aur";
                case "aruop":
                    return "lsr";
                case "arutani":
                    return "atx";
                case "arvanitika albanian":
                    return "aat";
                case "as":
                    return "asz";
                case "asaro'o":
                    return "mtv";
                case "asas":
                    return "asd";
                case "asháninka":
                    return "cni";
                case "ashe":
                    return "ahs";
                case "ashéninka pajonal":
                    return "cjo";
                case "ashéninka perené":
                    return "prq";
                case "ashkun":
                    return "ask";
                case "asho chin":
                    return "csh";
                case "ashtiani":
                    return "atn";
                case "asilulu":
                    return "asl";
                case "askopan":
                    return "eiv";
                case "asoa":
                    return "asv";
                case "assamese":
                    return "asm";
                case "assan":
                    return "xss";
                case "assangori":
                    return "sjg";
                case "assiniboine":
                    return "asb";
                case "assyrian neo-aramaic":
                    return "aii";
                case "asturian":
                    return "ast";
                case "asu":
                    return "asa";
                case "asue awyu":
                    return "psa";
                case "asumboa":
                    return "aua";
                case "asunción mixtepec zapotec":
                    return "zoo";
                case "asuri":
                    return "asr";
                case "ata":
                    return "atm";
                case "ata manobo":
                    return "atd";
                case "atakapa":
                    return "aqp";
                case "atampaya":
                    return "amz";
                case "atatláhuca mixtec":
                    return "mib";
                case "atayal":
                    return "tay";
                case "atemble":
                    return "ate";
                case "athpariya":
                    return "aph";
                case "ati":
                    return "atk";
                case "atikamekw":
                    return "atj";
                case "atohwaim":
                    return "aqm";
                case "atong":
                    return "ato";
                case "a'tong":
                    return "aot";
                case "atorada":
                    return "aox";
                case "atsahuaca":
                    return "atc";
                case "atsam":
                    return "cch";
                case "atsugewi":
                    return "atw";
                case "attapady kurumba":
                    return "pkr";
                case "attié":
                    return "ati";
                case "atzingo matlatzinca":
                    return "ocu";
                case "au":
                    return "avt";
                case "aukan":
                    return "djk";
                case "aulua":
                    return "aul";
                case "aurá":
                    return "aux";
                case "aushi":
                    return "auh";
                case "aushiri":
                    return "avs";
                case "austral":
                    return "aut";
                case "auwe":
                    return "smf";
                case "auye":
                    return "auu";
                case "auyokawa":
                    return "auo";
                case "ava guaraní":
                    return "nhd";
                case "avá-canoeiro":
                    return "avv";
                case "avaric":
                    return "ava";
                case "avatime":
                    return "avn";
                case "avau":
                    return "avb";
                case "avestan":
                    return "ave";
                case "avikam":
                    return "avi";
                case "avokaya":
                    return "avu";
                case "awa":
                    return "awb";
                case "awabakal":
                    return "awk";
                case "awa-cuaiquer":
                    return "kwi";
                case "awad bing":
                    return "bcu";
                case "awadhi":
                    return "awa";
                case "awak":
                    return "awo";
                case "awar":
                    return "aya";
                case "awara":
                    return "awx";
                case "awbono":
                    return "awh";
                case "aweer":
                    return "bob";
                case "awera":
                    return "awr";
                case "awetí":
                    return "awe";
                case "awing":
                    return "azo";
                case "awiyaana":
                    return "auy";
                case "awjilah":
                    return "auj";
                case "awngi":
                    return "awn";
                case "awtuw":
                    return "kmn";
                case "awu":
                    return "yiu";
                case "awun":
                    return "aww";
                case "awutu":
                    return "afu";
                case "awyi":
                    return "auw";
                case "axamb":
                    return "ahb";
                case "axi yi":
                    return "yix";
                case "ayabadhu":
                    return "ayd";
                case "ayacucho quechua":
                    return "quy";
                case "ayautla mazatec":
                    return "vmy";
                case "ayere":
                    return "aye";
                case "ayi":
                    return "ayq";
                case "ayiwo":
                    return "nfl";
                case "ayizi":
                    return "yyz";
                case "ayizo gbe":
                    return "ayb";
                case "aymara":
                    return "aym";
                case "ayoquesco zapotec":
                    return "zaf";
                case "ayoreo":
                    return "ayo";
                case "ayu":
                    return "ayu";
                case "ayutla mixtec":
                    return "miy";
                case "azerbaijani":
                    return "aze";
                case "azha":
                    return "aza";
                case "azhe":
                    return "yiz";
                case "azoyú tlapanec":
                    return "tpc";
                case "baan":
                    return "bvj";
                case "baangi":
                    return "bqx";
                case "baatonum":
                    return "bba";
                case "baba":
                    return "bbw";
                case "baba malay":
                    return "mbf";
                case "babalia creole arabic":
                    return "bbz";
                case "babango":
                    return "bbm";
                case "babanki":
                    return "bbk";
                case "babatana":
                    return "baa";
                case "babine":
                    return "bcr";
                case "babuza":
                    return "bzg";
                case "bacama":
                    return "bcy";
                case "bacanese malay":
                    return "btj";
                case "bachajón tzeltal":
                    return "tzb";
                case "bactrian":
                    return "xbc";
                case "bada":
                    return "bau";
                case "badaga":
                    return "bfq";
                case "bade":
                    return "bde";
                case "badeshi":
                    return "bdz";
                case "bädi kanum":
                    return "khd";
                case "badimaya":
                    return "bia";
                case "badui":
                    return "bac";
                case "badyara":
                    return "pbp";
                case "baeggu":
                    return "bvd";
                case "baelelea":
                    return "bvc";
                case "baetora":
                    return "btr";
                case "bafanji":
                    return "bfj";
                case "bafaw-balong":
                    return "bwt";
                case "bafia":
                    return "ksf";
                case "bafut":
                    return "bfd";
                case "baga binari":
                    return "bcg";
                case "baga kaloum":
                    return "bqf";
                case "baga koga":
                    return "bgo";
                case "baga manduri":
                    return "bmd";
                case "baga mboteni":
                    return "bgm";
                case "baga sitemu":
                    return "bsp";
                case "baga sobané":
                    return "bsv";
                case "bagheli":
                    return "bfy";
                case "bagirmi":
                    return "bmi";
                case "bagirmi fulfulde":
                    return "fui";
                case "bago-kusuntu":
                    return "bqg";
                case "bagri":
                    return "bgq";
                case "bagupi":
                    return "bpi";
                case "bagusa":
                    return "bqb";
                case "bagvalal":
                    return "kva";
                case "baha buyang":
                    return "yha";
                case "baham":
                    return "bdw";
                case "bahamas creole english":
                    return "bah";
                case "baharna arabic":
                    return "abv";
                case "bahau":
                    return "bhv";
                case "bahinemo":
                    return "bjh";
                case "bahing":
                    return "bhj";
                case "bahnar":
                    return "bdq";
                case "bahonsuai":
                    return "bsu";
                case "bai":
                    return "bdj";
                case "baibai":
                    return "bbf";
                case "baikeno":
                    return "bkx";
                case "baima":
                    return "bqh";
                case "baimak":
                    return "bmx";
                case "bainouk-gunyaamolo":
                    return "bcz";
                case "bainouk-gunyuño":
                    return "bab";
                case "bainouk-samik":
                    return "bcb";
                case "baiso":
                    return "bsw";
                case "baissa fali":
                    return "fah";
                case "bajan":
                    return "bjs";
                case "bajelani":
                    return "bjm";
                case "baka":
                    return "bdh";
                case "bakairí":
                    return "bkq";
                case "bakaka":
                    return "bqz";
                case "bakhtiari":
                    return "bqi";
                case "baki":
                    return "bki";
                case "bakoko":
                    return "bkh";
                case "bakole":
                    return "kme";
                case "bakpinka":
                    return "bbs";
                case "bakumpai":
                    return "bkr";
                case "bakwé":
                    return "bjw";
                case "balaesang":
                    return "bls";
                case "balangao":
                    return "blw";
                case "balangingi":
                    return "sse";
                case "balanta-ganja":
                    return "bjt";
                case "balantak":
                    return "blz";
                case "balanta-kentohe":
                    return "ble";
                case "balau":
                    return "blg";
                case "baldemu":
                    return "bdn";
                case "bali":
                    return "bcn";
                case "balinese":
                    return "ban";
                case "balinese malay":
                    return "mhp";
                case "balkan gagauz turkish":
                    return "bgx";
                case "balkan romani":
                    return "rmn";
                case "balo":
                    return "bqo";
                case "baloi":
                    return "biz";
                case "balti":
                    return "bft";
                case "baltic romani":
                    return "rml";
                case "baluan-pam":
                    return "blq";
                case "baluchi":
                    return "bal";
                case "bamali":
                    return "bbq";
                case "bambalang":
                    return "bmo";
                case "bambam":
                    return "ptu";
                case "bambara":
                    return "bam";
                case "bambassi":
                    return "myf";
                case "bambili-bambui":
                    return "baw";
                case "bamenyam":
                    return "bce";
                case "bamu":
                    return "bcf";
                case "bamukumbit":
                    return "bqt";
                case "bamun":
                    return "bax";
                case "bamunka":
                    return "bvm";
                case "bamwe":
                    return "bmg";
                case "bana":
                    return "bcw";
                case "banao itneg":
                    return "bjx";
                case "banaro":
                    return "byz";
                case "banda":
                    return "bnd";
                case "banda malay":
                    return "bpq";
                case "banda-bambari":
                    return "liy";
                case "banda-banda":
                    return "bpd";
                case "banda-mbrès":
                    return "bqk";
                case "banda-ndélé":
                    return "bfl";
                case "banda-yangere":
                    return "yaj";
                case "bandi":
                    return "bza";
                case "bandial":
                    return "bqj";
                case "bandjalang":
                    return "bdy";
                case "bandjigali":
                    return "bjd";
                case "bangala":
                    return "bxg";
                case "bangandu":
                    return "bgf";
                case "bangba":
                    return "bbe";
                case "banggai":
                    return "bgz";
                case "banggarla":
                    return "bjb";
                case "bangi":
                    return "bni";
                case "bangi me":
                    return "dba";
                case "bangka":
                    return "mfb";
                case "bangolan":
                    return "bgj";
                case "bangubangu":
                    return "bnx";
                case "bangwinji":
                    return "bsj";
                case "baniva":
                    return "bvv";
                case "baniwa":
                    return "bwi";
                case "banjar":
                    return "bjn";
                case "bankagooma":
                    return "bxw";
                case "bankon":
                    return "abb";
                case "bannoni":
                    return "bcm";
                case "bantawa":
                    return "bap";
                case "bantik":
                    return "bnq";
                case "bantoanon":
                    return "bno";
                case "baoulé":
                    return "bci";
                case "bara malagasy":
                    return "bhr";
                case "baraamu":
                    return "brd";
                case "barai":
                    return "bbb";
                case "barakai":
                    return "baj";
                case "baram kayan":
                    return "kys";
                case "barama":
                    return "bbg";
                case "barambu":
                    return "brm";
                case "baramu":
                    return "bmz";
                case "barapasi":
                    return "brp";
                case "baras":
                    return "brs";
                case "barasana-eduria":
                    return "bsn";
                case "barbacoas":
                    return "bpb";
                case "barbareño":
                    return "boi";
                case "barclayville grebo":
                    return "gry";
                case "bardi":
                    return "bcj";
                case "baré":
                    return "bae";
                case "barein":
                    return "bva";
                case "bargam":
                    return "mlp";
                case "bari":
                    return "bfa";
                case "barí":
                    return "mot";
                case "bariai":
                    return "bch";
                case "bariji":
                    return "bjc";
                case "barikanchi":
                    return "bxo";
                case "barok":
                    return "bjk";
                case "barombi":
                    return "bbi";
                case "barro negro tunebo":
                    return "tbn";
                case "barrow point":
                    return "bpt";
                case "baruga":
                    return "bjz";
                case "baruya":
                    return "byr";
                case "barwe":
                    return "bwg";
                case "barzani jewish neo-aramaic":
                    return "bjf";
                case "basa":
                    return "bas";
                case "basa-gumna":
                    return "bsl";
                case "basa-gurmana":
                    return "buj";
                case "basap":
                    return "bdb";
                case "basay":
                    return "byq";
                case "bashkardi":
                    return "bsg";
                case "bashkir":
                    return "bak";
                case "basketo":
                    return "bst";
                case "basque":
                    return "eus";
                case "bassa":
                    return "bsq";
                case "bassa-kontagora":
                    return "bsr";
                case "bassari":
                    return "bsc";
                case "bassossi":
                    return "bsi";
                case "bata":
                    return "bta";
                case "bataan ayta":
                    return "ayt";
                case "batad ifugao":
                    return "ifb";
                case "batak":
                    return "bya";
                case "batak alas-kluet":
                    return "btz";
                case "batak angkola":
                    return "akb";
                case "batak dairi":
                    return "btd";
                case "batak karo":
                    return "btx";
                case "batak mandailing":
                    return "btm";
                case "batak simalungun":
                    return "bts";
                case "batak toba":
                    return "bbc";
                case "batanga":
                    return "bnm";
                case "batek":
                    return "btq";
                case "bateri":
                    return "btv";
                case "bathari":
                    return "bhm";
                case "bati":
                    return "btc";
                case "bats":
                    return "bbl";
                case "batu":
                    return "btu";
                case "batui":
                    return "zbt";
                case "batuley":
                    return "bay";
                case "bau":
                    return "bbd";
                case "bau bidayuh":
                    return "sne";
                case "bauchi":
                    return "bsf";
                case "baure":
                    return "brg";
                case "bauria":
                    return "bge";
                case "bauro":
                    return "bxa";
                case "bauwaki":
                    return "bwk";
                case "bauzi":
                    return "bvz";
                case "bavarian":
                    return "bar";
                case "bawm chin":
                    return "bgr";
                case "bay miwok":
                    return "mkq";
                case "bayali":
                    return "bjy";
                case "baygo":
                    return "byg";
                case "bayono":
                    return "byl";
                case "bayot":
                    return "bda";
                case "bayungu":
                    return "bxj";
                case "bazigar":
                    return "bfr";
                case "beami":
                    return "beo";
                case "beaver":
                    return "bea";
                case "beba":
                    return "bfp";
                case "bebe":
                    return "bzv";
                case "bebele":
                    return "beb";
                case "bebeli":
                    return "bek";
                case "bebil":
                    return "bxp";
                case "bedawiyet":
                    return "bej";
                case "bedik":
                    return "tnr";
                case "bedjond":
                    return "bjv";
                case "bedoanas":
                    return "bed";
                case "beeke":
                    return "bkf";
                case "beele":
                    return "bxq";
                case "beembe":
                    return "beq";
                case "beezen":
                    return "bnz";
                case "befang":
                    return "bby";
                case "begbere-ejar":
                    return "bqv";
                case "bekati'":
                    return "bei";
                case "bekwarra":
                    return "bkv";
                case "bekwil":
                    return "bkw";
                case "belait":
                    return "beg";
                case "belanda bor":
                    return "bxb";
                case "belanda viri":
                    return "bvi";
                case "belarusian":
                    return "bel";
                case "belhariya":
                    return "byw";
                case "beli":
                    return "bey";
                case "belize kriol english":
                    return "bzj";
                case "bella coola":
                    return "blc";
                case "bellari":
                    return "brw";
                case "bemba":
                    return "bem";
                case "bembe":
                    return "bmb";
                case "bena":
                    return "bez";
                case "benabena":
                    return "bef";
                case "bench":
                    return "bcq";
                case "bende":
                    return "bdp";
                case "bendi":
                    return "bct";
                case "beneraf":
                    return "bnv";
                case "beng":
                    return "nhb";
                case "benga":
                    return "bng";
                case "bengali":
                    return "ben";
                case "benggoi":
                    return "bgy";
                case "bentong":
                    return "bnu";
                case "benyadu'":
                    return "byd";
                case "beothuk":
                    return "bue";
                case "bepour":
                    return "bie";
                case "bera":
                    return "brf";
                case "berakou":
                    return "bxv";
                case "berau malay":
                    return "bve";
                case "berbice creole dutch":
                    return "brc";
                case "berik":
                    return "bkl";
                case "berinomo":
                    return "bit";
                case "berom":
                    return "bom";
                case "berta":
                    return "wti";
                case "berti":
                    return "byt";
                case "besisi":
                    return "mhe";
                case "besme":
                    return "bes";
                case "besoa":
                    return "bep";
                case "betaf":
                    return "bfe";
                case "betawi":
                    return "bew";
                case "bete":
                    return "byf";
                case "bete-bendi":
                    return "btt";
                case "beti":
                    return "btb";
                case "betta kurumba":
                    return "xub";
                case "bezhta":
                    return "kap";
                case "bhadrawahi":
                    return "bhd";
                case "bhalay":
                    return "bhx";
                case "bharia":
                    return "bha";
                case "bhatola":
                    return "btl";
                case "bhatri":
                    return "bgw";
                case "bhattiyali":
                    return "bht";
                case "bhaya":
                    return "bhe";
                case "bhele":
                    return "bhy";
                case "bhilali":
                    return "bhi";
                case "bhili":
                    return "bhb";
                case "bhojpuri":
                    return "bho";
                case "bhoti kinnauri":
                    return "nes";
                case "bhunjia":
                    return "bhu";
                case "biafada":
                    return "bif";
                case "biak":
                    return "bhw";
                case "biali":
                    return "beh";
                case "bian marind":
                    return "bpv";
                case "biangai":
                    return "big";
                case "biao":
                    return "byk";
                case "biao mon":
                    return "bmt";
                case "biao-jiao mien":
                    return "bje";
                case "biatah bidayuh":
                    return "bth";
                case "bidiyo":
                    return "bid";
                case "bidyara":
                    return "bym";
                case "bidyogo":
                    return "bjg";
                case "biem":
                    return "bmc";
                case "bierebo":
                    return "bnk";
                case "bieria":
                    return "brj";
                case "biete":
                    return "biu";
                case "big nambas":
                    return "nmb";
                case "biga":
                    return "bhc";
                case "bijori":
                    return "bix";
                case "bikaru":
                    return "bic";
                case "bikol":
                    return "bik";
                case "bikya":
                    return "byb";
                case "bila":
                    return "bip";
                case "bilakura":
                    return "bql";
                case "bilaspuri":
                    return "kfs";
                case "bilba":
                    return "bpz";
                case "bilbil":
                    return "brz";
                case "bile":
                    return "bil";
                case "bilin":
                    return "byn";
                case "bilma kanuri":
                    return "bms";
                case "biloxi":
                    return "bll";
                case "bilua":
                    return "blb";
                case "bilur":
                    return "bxf";
                case "bima":
                    return "bhp";
                case "bimin":
                    return "bhl";
                case "bimoba":
                    return "bim";
                case "bina":
                    return "bmn";
                case "binahari":
                    return "bxz";
                case "binandere":
                    return "bhg";
                case "bine":
                    return "bon";
                case "bini":
                    return "bin";
                case "binji":
                    return "bpj";
                case "binongan itneg":
                    return "itb";
                case "bintauna":
                    return "bne";
                case "bintulu":
                    return "bny";
                case "binukid":
                    return "bkd";
                case "binumarien":
                    return "bjr";
                case "bipi":
                    return "biq";
                case "birale":
                    return "bxe";
                case "birao":
                    return "brr";
                case "birgit":
                    return "btf";
                case "birhor":
                    return "biy";
                case "biri":
                    return "bzr";
                case "biritai":
                    return "bqq";
                case "birked":
                    return "brk";
                case "birri":
                    return "bvq";
                case "birwa":
                    return "brl";
                case "biseni":
                    return "ije";
                case "bishnupriya":
                    return "bpy";
                case "bishuo":
                    return "bwh";
                case "bisis":
                    return "bnw";
                case "bislama":
                    return "bis";
                case "bisorio":
                    return "bir";
                case "bissa":
                    return "bib";
                case "bisu":
                    return "bzi";
                case "bit":
                    return "bgk";
                case "bitare":
                    return "brt";
                case "bitur":
                    return "mcc";
                case "biwat":
                    return "bwm";
                case "biyo":
                    return "byo";
                case "biyom":
                    return "bpm";
                case "blablanga":
                    return "blp";
                case "blafe":
                    return "bfh";
                case "blagar":
                    return "beu";
                case "blang":
                    return "blr";
                case "bliss":
                    return "zbl";
                case "bo":
                    return "bgl";
                case "boano":
                    return "bzl";
                case "bobongko":
                    return "bgb";
                case "bobot":
                    return "bty";
                case "bodo":
                    return "boy";
                case "bodo gadaba":
                    return "gbj";
                case "bodo parja":
                    return "bdv";
                case "bofi":
                    return "bff";
                case "boga":
                    return "bvw";
                case "bogaya":
                    return "boq";
                case "boghom":
                    return "bux";
                case "boguru":
                    return "bqu";
                case "bohtan neo-aramaic":
                    return "bhn";
                case "boikin":
                    return "bzf";
                case "bokha":
                    return "ybk";
                case "boko":
                    return "bkp";
                case "bokobaru":
                    return "bus";
                case "bokoto":
                    return "bdt";
                case "bokyi":
                    return "bky";
                case "bola":
                    return "bnp";
                case "bolango":
                    return "bld";
                case "bole":
                    return "bol";
                case "bolgarian":
                    return "xbo";
                case "bolgo":
                    return "bvo";
                case "bolia":
                    return "bli";
                case "bolinao":
                    return "smk";
                case "bolo":
                    return "blv";
                case "boloki":
                    return "bkt";
                case "bolon":
                    return "bof";
                case "bolondo":
                    return "bzm";
                case "bolongan":
                    return "blj";
                case "bolyu":
                    return "ply";
                case "bom":
                    return "bmf";
                case "boma":
                    return "boh";
                case "bomboli":
                    return "bml";
                case "bomboma":
                    return "bws";
                case "bomitaba":
                    return "zmx";
                case "bomu":
                    return "bmq";
                case "bomwali":
                    return "bmw";
                case "bon gula":
                    return "glc";
                case "bonan":
                    return "peh";
                case "bondei":
                    return "bou";
                case "bondo":
                    return "bfw";
                case "bondoukou kulango":
                    return "kzc";
                case "bondum dom dogon":
                    return "dbu";
                case "bonerate":
                    return "bna";
                case "bonggi":
                    return "bdg";
                case "bonggo":
                    return "bpg";
                case "bongili":
                    return "bui";
                case "bongo":
                    return "bot";
                case "bongu":
                    return "bpu";
                case "bonjo":
                    return "bok";
                case "bonkeng":
                    return "bvg";
                case "bonkiman":
                    return "bop";
                case "bookan":
                    return "bnb";
                case "boon":
                    return "bnl";
                case "boor":
                    return "bvf";
                case "bora":
                    return "boa";
                case "borana-arsi-guji oromo":
                    return "gax";
                case "border kuna":
                    return "kvn";
                case "borei":
                    return "gai";
                case "borgu fulfulde":
                    return "fue";
                case "borna":
                    return "bwo";
                case "borong":
                    return "ksr";
                case "borôro":
                    return "bor";
                case "boruca":
                    return "brn";
                case "bo-rukul":
                    return "mae";
                case "boselewa":
                    return "bwf";
                case "bosngun":
                    return "bqs";
                case "bosnian":
                    return "bos";
                case "bote-majhi":
                    return "bmj";
                case "botlikh":
                    return "bph";
                case "botolan sambal":
                    return "sbl";
                case "bouna kulango":
                    return "nku";
                case "bo-ung":
                    return "mux";
                case "bouyei":
                    return "pcc";
                case "bozaba":
                    return "bzo";
                case "bragat":
                    return "aof";
                case "brahui":
                    return "brh";
                case "braj":
                    return "bra";
                case "brek karen":
                    return "kvl";
                case "brem":
                    return "buq";
                case "breri":
                    return "brq";
                case "breton":
                    return "bre";
                case "bribri":
                    return "bzd";
                case "brithenig":
                    return "bzt";
                case "brokkat":
                    return "bro";
                case "brokpake":
                    return "sgt";
                case "brokskat":
                    return "bkk";
                case "brooke's point palawano":
                    return "plw";
                case "broome pearling lugger pidgin":
                    return "bpl";
                case "brunei":
                    return "kxd";
                case "brunei bisaya":
                    return "bsb";
                case "bu":
                    return "jid";
                case "bua":
                    return "bub";
                case "bualkhaw chin":
                    return "cbl";
                case "buamu":
                    return "box";
                case "bube":
                    return "bvb";
                case "bubi":
                    return "buw";
                case "bubia":
                    return "bbx";
                case "budeh stieng":
                    return "stt";
                case "budibud":
                    return "btp";
                case "budong-budong":
                    return "bdx";
                case "budu":
                    return "buu";
                case "budukh":
                    return "bdk";
                case "buduma":
                    return "bdm";
                case "budza":
                    return "bja";
                case "bugan":
                    return "bbh";
                case "bugawac":
                    return "buk";
                case "bughotu":
                    return "bgt";
                case "buginese":
                    return "bug";
                case "buglere":
                    return "sab";
                case "bugun":
                    return "bgg";
                case "buhid":
                    return "bku";
                case "buhutu":
                    return "bxh";
                case "bujhyal":
                    return "byh";
                case "bukar-sadung bidayuh":
                    return "sdo";
                case "bukat":
                    return "bvk";
                case "bukharic":
                    return "bhh";
                case "bukit malay":
                    return "bvu";
                case "bukitan":
                    return "bkn";
                case "bukiyip":
                    return "ape";
                case "buksa":
                    return "tkb";
                case "bukusu":
                    return "bxk";
                case "bukwen":
                    return "buz";
                case "bulgarian":
                    return "bul";
                case "bulgebi":
                    return "bmp";
                case "buli":
                    return "bwu";
                case "bullom so":
                    return "buy";
                case "bulo stieng":
                    return "sti";
                case "bulu":
                    return "bjl";
                case "bum":
                    return "bmv";
                case "bumaji":
                    return "byp";
                case "bumbita arapesh":
                    return "aon";
                case "bumthangkha":
                    return "kjz";
                case "bun":
                    return "buv";
                case "buna":
                    return "bvn";
                case "bunaba":
                    return "bck";
                case "bunak":
                    return "bfn";
                case "bunama":
                    return "bdd";
                case "bu-nao bunu":
                    return "bwx";
                case "bundeli":
                    return "bns";
                case "bung":
                    return "bqd";
                case "bungain":
                    return "but";
                case "bungku":
                    return "bkz";
                case "bungu":
                    return "wun";
                case "bunoge dogon":
                    return "dgb";
                case "bunun":
                    return "bnn";
                case "buol":
                    return "blf";
                case "burak":
                    return "bys";
                case "buraka":
                    return "bkg";
                case "bura-pabir":
                    return "bwr";
                case "burarra":
                    return "bvr";
                case "burate":
                    return "bti";
                case "burduna":
                    return "bxn";
                case "bure":
                    return "bvh";
                case "buriat":
                    return "bua";
                case "burji":
                    return "bji";
                case "burmbar":
                    return "vrt";
                case "burmese":
                    return "mya";
                case "burmeso":
                    return "bzu";
                case "buru":
                    return "bqw";
                case "burui":
                    return "bry";
                case "burumakok":
                    return "aip";
                case "burum-mindik":
                    return "bmu";
                case "burun":
                    return "bdi";
                case "burunge":
                    return "bds";
                case "burushaski":
                    return "bsk";
                case "burusu":
                    return "bqr";
                case "buruwai":
                    return "asi";
                case "busa":
                    return "bqp";
                case "busam":
                    return "bxs";
                case "busami":
                    return "bsm";
                case "busang kayan":
                    return "bfg";
                case "bushi":
                    return "buc";
                case "bushoong":
                    return "buf";
                case "buso":
                    return "bso";
                case "busoa":
                    return "bup";
                case "bussa":
                    return "dox";
                case "busuu":
                    return "bju";
                case "butbut kalinga":
                    return "kyb";
                case "butmas-tur":
                    return "bnr";
                case "butuanon":
                    return "btw";
                case "buwal":
                    return "bhs";
                case "buya":
                    return "byy";
                case "buyu":
                    return "byi";
                case "buyuan jinuo":
                    return "jiy";
                case "bwa":
                    return "bww";
                case "bwaidoka":
                    return "bwd";
                case "bwanabwana":
                    return "tte";
                case "bwatoo":
                    return "bwa";
                case "bwe karen":
                    return "bwe";
                case "bwela":
                    return "bwl";
                case "bwile":
                    return "bwc";
                case "bwisi":
                    return "bwz";
                case "byangsi":
                    return "bee";
                case "byep":
                    return "mkk";
                case "caac":
                    return "msq";
                case "cabécar":
                    return "cjp";
                case "cabiyarí":
                    return "cbb";
                case "cacaloxtepec mixtec":
                    return "miu";
                case "cacaopera":
                    return "ccr";
                case "cacgia roglai":
                    return "roc";
                case "cacua":
                    return "cbv";
                case "caddo":
                    return "cad";
                case "cafundo creole":
                    return "ccd";
                case "cagua":
                    return "cbh";
                case "cahuarano":
                    return "cah";
                case "cahuilla":
                    return "chl";
                case "cajamarca quechua":
                    return "qvc";
                case "cajatambo north lima quechua":
                    return "qvl";
                case "cajonos zapotec":
                    return "zad";
                case "cajun french":
                    return "frc";
                case "caka":
                    return "ckx";
                case "cakchiquel-quiché mixed language":
                    return "ckz";
                case "cakfem-mushere":
                    return "cky";
                case "calamian tagbanwa":
                    return "tbk";
                case "calderón highland quichua":
                    return "qud";
                case "callawalla":
                    return "caw";
                case "caló":
                    return "rmr";
                case "caluyanun":
                    return "clu";
                case "camarines norte agta":
                    return "abd";
                case "cameroon mambila":
                    return "mcu";
                case "cameroon pidgin":
                    return "wes";
                case "camling":
                    return "rab";
                case "campalagian":
                    return "cml";
                case "campidanese sardinian":
                    return "sro";
                case "camsá":
                    return "kbh";
                case "camtho":
                    return "cmt";
                case "camunic":
                    return "xcc";
                case "cañar highland quichua":
                    return "qxr";
                case "candoshi-shapra":
                    return "cbu";
                case "canela":
                    return "ram";
                case "canichana":
                    return "caz";
                case "cao lan":
                    return "mlc";
                case "cao miao":
                    return "cov";
                case "capanahua":
                    return "kaq";
                case "capiznon":
                    return "cps";
                case "cappadocian greek":
                    return "cpg";
                case "caquinte":
                    return "cot";
                case "car nicobarese":
                    return "caq";
                case "cara":
                    return "cfd";
                case "carabayo":
                    return "cby";
                case "caramanta":
                    return "crf";
                case "carapana":
                    return "cbc";
                case "carian":
                    return "xcr";
                case "caribbean hindustani":
                    return "hns";
                case "caribbean javanese":
                    return "jvn";
                case "carijona":
                    return "cbd";
                case "carolina algonquian":
                    return "crr";
                case "carolinian":
                    return "cal";
                case "carpathian romani":
                    return "rmc";
                case "carrier":
                    return "crx";
                case "cashibo-cacataibo":
                    return "cbr";
                case "cashinahua":
                    return "cbs";
                case "casiguran dumagat agta":
                    return "dgc";
                case "casuarina coast asmat":
                    return "asc";
                case "cataelano mandaya":
                    return "mst";
                case "catalan":
                    return "cat";
                case "catawba":
                    return "chc";
                case "cauca":
                    return "cca";
                case "cavineña":
                    return "cav";
                case "cayubaba":
                    return "cyb";
                case "cayuga":
                    return "cay";
                case "cayuse":
                    return "xcy";
                case "cebaara senoufo":
                    return "sef";
                case "cebuano":
                    return "ceb";
                case "celtiberian":
                    return "xce";
                case "cemuhî":
                    return "cam";
                case "cen":
                    return "cen";
                case "central asmat":
                    return "cns";
                case "central atlas tamazight":
                    return "tzm";
                case "central awyu":
                    return "awu";
                case "central aymara":
                    return "ayr";
                case "central bai":
                    return "bca";
                case "central berawan":
                    return "zbc";
                case "central bicolano":
                    return "bcl";
                case "central bontoc":
                    return "bnc";
                case "central cagayan agta":
                    return "agt";
                case "central cakchiquel":
                    return "cak";
                case "central dusun":
                    return "dtp";
                case "central grebo":
                    return "grv";
                case "central hongshuihe zhuang":
                    return "zch";
                case "central huasteca nahuatl":
                    return "nch";
                case "central huishui hmong":
                    return "hmc";
                case "central kanuri":
                    return "knc";
                case "central khmer":
                    return "khm";
                case "central kurdish":
                    return "ckb";
                case "central maewo":
                    return "mwo";
                case "central malay":
                    return "pse";
                case "central mam":
                    return "mvc";
                case "central masela":
                    return "mxz";
                case "central mashan hmong":
                    return "hmm";
                case "central mazahua":
                    return "maz";
                case "central melanau":
                    return "mel";
                case "central mnong":
                    return "cmo";
                case "central nahuatl":
                    return "nhn";
                case "central nicobarese":
                    return "ncb";
                case "central ojibwa":
                    return "ojc";
                case "central okinawan":
                    return "ryu";
                case "central palawano":
                    return "plc";
                case "central pame":
                    return "pbs";
                case "central pashto":
                    return "pst";
                case "central pokomam":
                    return "poc";
                case "central pomo":
                    return "poo";
                case "central puebla nahuatl":
                    return "ncx";
                case "central quiché":
                    return "quc";
                case "central sama":
                    return "sml";
                case "central siberian yupik":
                    return "ess";
                case "central sierra miwok":
                    return "csm";
                case "central subanen":
                    return "syb";
                case "central tagbanwa":
                    return "tgt";
                case "central tarahumara":
                    return "tar";
                case "central tunebo":
                    return "tuf";
                case "central yupik":
                    return "esu";
                case "central-eastern niger fulfulde":
                    return "fuq";
                case "centúúm":
                    return "cet";
                case "cerma":
                    return "cme";
                case "chachapoyas quechua":
                    return "quk";
                case "chachi":
                    return "cbi";
                case "chácobo":
                    return "cao";
                case "chadian arabic":
                    return "shu";
                case "chadong":
                    return "cdy";
                case "chagatai":
                    return "chg";
                case "chaima":
                    return "ciy";
                case "chajul ixil":
                    return "ixj";
                case "chak":
                    return "ckh";
                case "chakali":
                    return "cli";
                case "chakma":
                    return "ccp";
                case "chala":
                    return "cll";
                case "chaldean neo-aramaic":
                    return "cld";
                case "chalikha":
                    return "tgf";
                case "chamacoco":
                    return "ceg";
                case "chamalal":
                    return "cji";
                case "chamari":
                    return "cdg";
                case "chambeali":
                    return "cdh";
                case "chambri":
                    return "can";
                case "chamicuro":
                    return "ccc";
                case "chamorro":
                    return "cha";
                case "chamula tzotzil":
                    return "tzc";
                case "chan santa cruz maya":
                    return "yus";
                case "chané":
                    return "caj";
                case "chang naga":
                    return "nbc";
                case "changriwa":
                    return "cga";
                case "changthang":
                    return "cna";
                case "chantyal":
                    return "chx";
                case "chara":
                    return "cra";
                case "chaudangsi":
                    return "cdn";
                case "chaungtha":
                    return "ccq";
                case "chaura":
                    return "crv";
                case "chavacano":
                    return "cbk";
                case "chayahuita":
                    return "cbt";
                case "chayuco mixtec":
                    return "mih";
                case "chazumba mixtec":
                    return "xtb";
                case "che":
                    return "ruk";
                case "chechen":
                    return "che";
                case "cheke holo":
                    return "mrn";
                case "chemakum":
                    return "xch";
                case "chenalhó tzotzil":
                    return "tze";
                case "chenapian":
                    return "cjn";
                case "chenchu":
                    return "cde";
                case "chenoua":
                    return "cnu";
                case "chepang":
                    return "cdm";
                case "chepya":
                    return "ycp";
                case "cheq wong/chewong":
                    return "cwg";
                case "cherepon":
                    return "cpn";
                case "cherokee":
                    return "chr";
                case "chesu":
                    return "ych";
                case "chetco":
                    return "ctc";
                case "chewa":
                    return "nya";
                case "cheyenne":
                    return "chy";
                case "chhattisgarhi":
                    return "hne";
                case "chhintange":
                    return "ctn";
                case "chhulung":
                    return "cur";
                case "chiapanec":
                    return "cip";
                case "chibcha":
                    return "chb";
                case "chicahuaxtla triqui":
                    return "trs";
                case "chichicapan zapotec":
                    return "zpv";
                case "chichimeca-jonaz":
                    return "pei";
                case "chichonyi-chidzihana-chikauma":
                    return "coh";
                case "chickasaw":
                    return "cic";
                case "chicomuceltec":
                    return "cob";
                case "chidigo/digo":
                    return "dig";
                case "chiduruma":
                    return "dug";
                case "chiga":
                    return "cgg";
                case "chigmecatitlán mixtec":
                    return "mii";
                case "chilcotin":
                    return "clc";
                case "chilean quechua":
                    return "cqu";
                case "chilisso":
                    return "clh";
                case "chiltepec chinantec":
                    return "csa";
                case "chimakum":
                    return "cmk";
                case "chimalapa zoque":
                    return "zoh";
                case "chimariko":
                    return "cid";
                case "chimborazo highland quichua":
                    return "qug";
                case "chimila":
                    return "cbg";
                case "china buriat":
                    return "bxu";
                case "chinali":
                    return "cih";
                case "chinbon chin":
                    return "cnb";
                case "chincha quechua":
                    return "qxc";
                case "chinese":
                    return "zho";
                case "chinese pidgin english":
                    return "cpi";
                case "chinook":
                    return "chh";
                case "chinook jargon":
                    return "chn";
                case "chipaya":
                    return "cap";
                case "chipewyan":
                    return "chp";
                case "chipiajes":
                    return "cbe";
                case "chippewa":
                    return "ciw";
                case "chiquián ancash quechua":
                    return "qxa";
                case "chiquihuitlán mazatec":
                    return "maq";
                case "chiquitano":
                    return "cax";
                case "chiru":
                    return "cdf";
                case "chitimacha":
                    return "ctm";
                case "chitkuli kinnauri":
                    return "cik";
                case "chittagonian":
                    return "ctg";
                case "chitwania tharu":
                    return "the";
                case "choapan zapotec":
                    return "zpc";
                case "chocangacakha":
                    return "cgk";
                case "chochotec":
                    return "coz";
                case "choctaw":
                    return "cho";
                case "chodri":
                    return "cdi";
                case "chokri naga":
                    return "nri";
                case "chokwe":
                    return "cjk";
                case "cholón":
                    return "cht";
                case "chong":
                    return "cog";
                case "choni":
                    return "cda";
                case "chopi":
                    return "cce";
                case "chorasmian":
                    return "xco";
                case "chorotega":
                    return "cjr";
                case "chortí":
                    return "caa";
                case "chothe naga":
                    return "nct";
                case "chrau":
                    return "crw";
                case "chru":
                    return "cje";
                case "chuang":
                    return "zha";
                case "chuanqiandian cluster miao":
                    return "cqd";
                case "chuave":
                    return "cjv";
                case "chug":
                    return "cvg";
                case "chuka/gichuka":
                    return "cuh";
                case "chukot":
                    return "ckt";
                case "chukwa":
                    return "cuw";
                case "chulym":
                    return "clw";
                case "chumash":
                    return "chs";
                case "chumburung":
                    return "ncu";
                case "churahi":
                    return "cdj";
                case "church slavic":
                    return "chu";
                case "chut":
                    return "scb";
                case "chuukese":
                    return "chk";
                case "chuvantsy":
                    return "xcv";
                case "chuvash":
                    return "chv";
                case "chuwabu":
                    return "chw";
                case "ci gbe":
                    return "cib";
                case "cia-cia":
                    return "cia";
                case "cibak":
                    return "ckl";
                case "cimbrian":
                    return "cim";
                case "cinamiguin manobo":
                    return "mkx";
                case "cinda-regi-tiyal":
                    return "cdr";
                case "cineni":
                    return "cie";
                case "cinta larga":
                    return "cin";
                case "cisalpine gaulish":
                    return "xcg";
                case "cishingini":
                    return "asg";
                case "citak":
                    return "txt";
                case "ciwogai":
                    return "tgd";
                case "clallam":
                    return "clm";
                case "classical armenian":
                    return "xcl";
                case "classical mandaic":
                    return "myz";
                case "classical mongolian":
                    return "cmg";
                case "classical nahuatl":
                    return "nci";
                case "classical nepal bhasa":
                    return "nwc";
                case "classical quechua":
                    return "qwc";
                case "classical syriac":
                    return "syc";
                case "classical tibetan":
                    return "xct";
                case "c'lela":
                    return "dri";
                case "coahuilteco":
                    return "xcw";
                case "coast miwok":
                    return "csi";
                case "coastal kadazan":
                    return "kzj";
                case "coastal konjo":
                    return "kjc";
                case "coatecas altas zapotec":
                    return "zca";
                case "coatepec nahuatl":
                    return "naz";
                case "coatlán mixe":
                    return "mco";
                case "coatlán zapotec":
                    return "zps";
                case "coatzospan mixtec":
                    return "miz";
                case "cocama-cocamilla":
                    return "cod";
                case "cochimi":
                    return "coj";
                case "cocopa":
                    return "coc";
                case "cocos islands malay":
                    return "coa";
                case "coeur d'alene":
                    return "crd";
                case "cofán":
                    return "con";
                case "cogui":
                    return "kog";
                case "col":
                    return "liw";
                case "colonia tovar german":
                    return "gct";
                case "colorado":
                    return "cof";
                case "columbia-wenatchi":
                    return "col";
                case "comaltepec chinantec":
                    return "cco";
                case "comanche":
                    return "com";
                case "comecrudo":
                    return "xcm";
                case "como karim":
                    return "cfg";
                case "comorian":
                    return "swb";
                case "comox":
                    return "coo";
                case "con":
                    return "cno";
                case "congo swahili":
                    return "swc";
                case "cook islands maori":
                    return "rar";
                case "côông":
                    return "cnc";
                case "coos":
                    return "csz";
                case "copainalá zoque":
                    return "zoc";
                case "copala triqui":
                    return "trc";
                case "coptic":
                    return "cop";
                case "coquille":
                    return "coq";
                case "cori":
                    return "cry";
                case "cornish":
                    return "cor";
                case "corongo ancash quechua":
                    return "qwa";
                case "corsican":
                    return "cos";
                case "cotabato manobo":
                    return "mta";
                case "cotoname":
                    return "xcn";
                case "cowlitz":
                    return "cow";
                case "coxima":
                    return "kox";
                case "coyaima":
                    return "coy";
                case "coyotepec popoloca":
                    return "pbf";
                case "coyutla totonac":
                    return "toc";
                case "cree":
                    return "cre";
                case "creek":
                    return "mus";
                case "crimean tatar/crimean turkish":
                    return "crh";
                case "croatian":
                    return "hrv";
                case "cross river mbembe":
                    return "mfn";
                case "crow":
                    return "cro";
                case "cruzeño":
                    return "crz";
                case "cua":
                    return "cua";
                case "cubeo":
                    return "cub";
                case "cubulco achí":
                    return "acc";
                case "cuiba":
                    return "cui";
                case "culina/kulina":
                    return "cul";
                case "cumanagoto":
                    return "cuo";
                case "cumbric":
                    return "xcb";
                case "cumeral":
                    return "cum";
                case "cun":
                    return "cuq";
                case "cuneiform luwian":
                    return "xlu";
                case "cunén quiché":
                    return "cun";
                case "cung":
                    return "cug";
                case "cupeño":
                    return "cup";
                case "curonian":
                    return "xcu";
                case "curripaco":
                    return "kpc";
                case "cusco quechua":
                    return "quz";
                case "cutchi-swahili":
                    return "ccl";
                case "cuvok":
                    return "cuv";
                case "cuyamecalco mixtec":
                    return "xtu";
                case "cuyonon":
                    return "cyo";
                case "cwi bwamu":
                    return "bwy";
                case "cypriot arabic":
                    return "acy";
                case "czech":
                    return "ces";
                case "da'a kaili":
                    return "kzf";
                case "daai chin":
                    return "dao";
                case "daasanach":
                    return "dsh";
                case "daba":
                    return "dbq";
                case "dabarre":
                    return "dbr";
                case "dabe":
                    return "dbe";
                case "dacian":
                    return "xdc";
                case "dadibi":
                    return "mps";
                case "dadiya":
                    return "dbd";
                case "daga":
                    return "dgz";
                case "dagaari dioula":
                    return "dgd";
                case "dagba":
                    return "dgk";
                case "dagbani":
                    return "dag";
                case "dagik":
                    return "dec";
                case "dagoman":
                    return "dgn";
                case "dahalo":
                    return "dal";
                case "daho-doo":
                    return "das";
                case "dai":
                    return "dij";
                case "dai zhuang":
                    return "zhd";
                case "dair":
                    return "drb";
                case "dakaka":
                    return "bpa";
                case "dakka":
                    return "dkk";
                case "dakota":
                    return "dak";
                case "dakpakha":
                    return "dka";
                case "dalmatian":
                    return "dlm";
                case "daloa bété":
                    return "bev";
                case "dama":
                    return "dmm";
                case "damal":
                    return "uhn";
                case "dambi":
                    return "dac";
                case "dameli":
                    return "dml";
                case "dampelas":
                    return "dms";
                case "dan":
                    return "daf";
                case "danaru":
                    return "dnr";
                case "danau":
                    return "dnu";
                case "dandami maria":
                    return "daq";
                case "dangaléat":
                    return "daa";
                case "dangaura tharu":
                    return "thl";
                case "danish":
                    return "dan";
                case "dano":
                    return "aso";
                case "dao":
                    return "daz";
                case "daonda":
                    return "dnd";
                case "dar daju daju":
                    return "djc";
                case "dar fur daju":
                    return "daj";
                case "dar sila daju":
                    return "dau";
                case "darai":
                    return "dry";
                case "darang deng":
                    return "mhu";
                case "dargwa":
                    return "dar";
                case "dari":
                    return "prs";
                case "darkhat":
                    return "drh";
                case "darling":
                    return "drl";
                case "darlong":
                    return "dln";
                case "darmiya":
                    return "drd";
                case "daro-matu melanau":
                    return "dro";
                case "darwazi":
                    return "drw";
                case "dass":
                    return "dot";
                case "datooga":
                    return "tcc";
                case "daur":
                    return "dta";
                case "davawenyo":
                    return "daw";
                case "dâw":
                    return "kwa";
                case "dawawa":
                    return "dww";
                case "dawera-daweloor":
                    return "ddw";
                case "dawida/taita":
                    return "dav";
                case "day":
                    return "dai";
                case "dayi":
                    return "dax";
                case "daza":
                    return "dzd";
                case "dazaga":
                    return "dzg";
                case "deccan":
                    return "dcc";
                case "dedua":
                    return "ded";
                case "defaka":
                    return "afn";
                case "defi gbe":
                    return "gbh";
                case "deg":
                    return "mzw";
                case "degaru":
                    return "dgu";
                case "degema":
                    return "deg";
                case "degenan":
                    return "dge";
                case "degexit'an":
                    return "ing";
                case "dehu":
                    return "dhv";
                case "dehwari":
                    return "deh";
                case "dek":
                    return "dek";
                case "dela-oenale":
                    return "row";
                case "delaware":
                    return "del";
                case "delo":
                    return "ntr";
                case "dem":
                    return "dem";
                case "dema":
                    return "dmx";
                case "demisa":
                    return "dei";
                case "demta":
                    return "dmy";
                case "dendi":
                    return "ddn";
                case "dengese":
                    return "dez";
                case "dengka":
                    return "dnk";
                case "dení":
                    return "dny";
                case "deno":
                    return "dbb";
                case "denya":
                    return "anv";
                case "deori":
                    return "der";
                case "dera":
                    return "kbv";
                case "desano":
                    return "des";
                case "desiya":
                    return "dso";
                case "dewoin":
                    return "dee";
                case "dezfuli":
                    return "def";
                case "dghwede":
                    return "dgh";
                case "dhaiso":
                    return "dhs";
                case "dhalandji":
                    return "dhl";
                case "dhangu":
                    return "dhg";
                case "dhanki":
                    return "dhn";
                case "dhanwar":
                    return "dha";
                case "dhao":
                    return "nfa";
                case "dhargari":
                    return "dhr";
                case "dhatki":
                    return "mki";
                case "dhimal":
                    return "dhi";
                case "dhivehi/divehi/maldivian":
                    return "div";
                case "dhodia":
                    return "dho";
                case "dhofari arabic":
                    return "adf";
                case "dholuo":
                    return "luo";
                case "dhundari":
                    return "dhd";
                case "dhurga":
                    return "dhu";
                case "dhuwal":
                    return "duj";
                case "dia":
                    return "dia";
                case "dibabawon manobo":
                    return "mbd";
                case "dibiyaso":
                    return "dby";
                case "dibo":
                    return "dio";
                case "dibole":
                    return "bvx";
                case "dicamay agta":
                    return "duy";
                case "didinga":
                    return "did";
                case "dido":
                    return "ddo";
                case "diebroud":
                    return "tbp";
                case "dieri":
                    return "dif";
                case "dii":
                    return "dur";
                case "dijim-bwilim":
                    return "cfa";
                case "dilling":
                    return "dil";
                case "dima":
                    return "jma";
                case "dimasa":
                    return "dis";
                case "dimbong":
                    return "dii";
                case "dime":
                    return "dim";
                case "dimir":
                    return "dmc";
                case "dimli":
                    return "diq";
                case "dineor":
                    return "mrx";
                case "ding":
                    return "diz";
                case "dinka":
                    return "din";
                case "diodio":
                    return "ddi";
                case "dirari":
                    return "dit";
                case "dirasha":
                    return "gdl";
                case "diri":
                    return "dwa";
                case "diriku":
                    return "diu";
                case "dirim":
                    return "dir";
                case "disa":
                    return "dsi";
                case "ditammari":
                    return "tbz";
                case "diuwe":
                    return "diy";
                case "diuxi-tilantongo mixtec":
                    return "xtd";
                case "dixon reef":
                    return "dix";
                case "dizi":
                    return "mdx";
                case "djambarrpuyngu":
                    return "djr";
                case "djamindjung":
                    return "djd";
                case "djangun":
                    return "djf";
                case "djauan":
                    return "djn";
                case "djawi":
                    return "djw";
                case "djeebbana":
                    return "djj";
                case "djimini senoufo":
                    return "dyi";
                case "djinang":
                    return "dji";
                case "djinba":
                    return "djb";
                case "djingili":
                    return "jig";
                case "djiwarli":
                    return "djl";
                case "dobel":
                    return "kvo";
                case "dobu":
                    return "dob";
                case "doe":
                    return "doe";
                case "doga":
                    return "dgg";
                case "doghoro":
                    return "dgx";
                case "dogosé":
                    return "dos";
                case "dogoso":
                    return "dgs";
                case "dogri":
                    return "dgo";
                case "dogrib":
                    return "dgr";
                case "dogul dom dogon":
                    return "dbg";
                case "doka":
                    return "dbi";
                case "doko-uyanga":
                    return "uya";
                case "dolgan":
                    return "dlg";
                case "dolpo":
                    return "dre";
                case "dom":
                    return "doa";
                case "domaaki":
                    return "dmk";
                case "domari":
                    return "rmt";
                case "dombe":
                    return "dov";
                case "dompo":
                    return "doy";
                case "domu":
                    return "dof";
                case "domung":
                    return "dev";
                case "dondo":
                    return "dok";
                case "dong":
                    return "doh";
                case "dongo":
                    return "doo";
                case "dongotono":
                    return "ddd";
                case "dongshanba lalo":
                    return "yik";
                case "dongxiang":
                    return "sce";
                case "donno so dogon":
                    return "dds";
                case "doondo":
                    return "dde";
                case "dori'o":
                    return "dor";
                case "doromu-koki":
                    return "kqc";
                case "dororo":
                    return "drr";
                case "dorze":
                    return "doz";
                case "doso":
                    return "dol";
                case "doutai":
                    return "tds";
                case "doyayo":
                    return "dow";
                case "drents":
                    return "drt";
                case "drung":
                    return "duu";
                case "duala":
                    return "dua";
                case "duano":
                    return "dup";
                case "duau":
                    return "dva";
                case "dubli":
                    return "dub";
                case "dubu":
                    return "dmu";
                case "duduela":
                    return "duk";
                case "dugun":
                    return "ndu";
                case "duguri":
                    return "dbm";
                case "dugwor":
                    return "dme";
                case "duhwa":
                    return "kbz";
                case "duke":
                    return "nke";
                case "dulbu":
                    return "dbo";
                case "duli":
                    return "duz";
                case "duma":
                    return "dma";
                case "dumbea":
                    return "duf";
                case "dumi":
                    return "dus";
                case "dumpas":
                    return "dmv";
                case "dumpu":
                    return "wtf";
                case "dumun":
                    return "dui";
                case "duna":
                    return "duc";
                case "dungan":
                    return "dng";
                case "dungmali":
                    return "raa";
                case "dungra bhil":
                    return "duh";
                case "dungu":
                    return "dbv";
                case "dupaninan agta":
                    return "duo";
                case "dura":
                    return "drq";
                case "durango nahuatl":
                    return "nln";
                case "duri":
                    return "mvp";
                case "duriankere":
                    return "dbn";
                case "duruwa":
                    return "pci";
                case "dusner":
                    return "dsn";
                case "dusun deyah":
                    return "dun";
                case "dusun malang":
                    return "duq";
                case "dusun witu":
                    return "duw";
                case "dutch":
                    return "nld";
                case "dutton world speedwords":
                    return "dws";
                case "duungooma":
                    return "dux";
                case "duupa":
                    return "dae";
                case "duvle":
                    return "duv";
                case "duwai":
                    return "dbp";
                case "duwet":
                    return "gve";
                case "dwang":
                    return "nnu";
                case "dyaabugay":
                    return "dyy";
                case "dyaberdyaber":
                    return "dyb";
                case "dyan":
                    return "dya";
                case "dyangadi":
                    return "dyn";
                case "dyirbal":
                    return "dbl";
                case "dyugun":
                    return "dyd";
                case "dyula":
                    return "dyu";
                case "dza":
                    return "jen";
                case "dzalakha":
                    return "dzl";
                case "dzando":
                    return "dzn";
                case "dzao min":
                    return "bpn";
                case "dzodinka":
                    return "add";
                case "dzongkha":
                    return "dzo";
                case "dzùùngoo":
                    return "dnn";
                case "early tripuri":
                    return "xtr";
                case "east ambae":
                    return "omb";
                case "east berawan":
                    return "zbe";
                case "east damar":
                    return "dmr";
                case "east futuna":
                    return "fud";
                case "east kewa":
                    return "kjs";
                case "east limba":
                    return "lma";
                case "east makian":
                    return "mky";
                case "east masela":
                    return "vme";
                case "east nyala":
                    return "nle";
                case "east tarangan":
                    return "tre";
                case "east yugur":
                    return "yuy";
                case "eastern abnaki":
                    return "aaq";
                case "eastern acipa":
                    return "acp";
                case "eastern apurímac quechua":
                    return "qve";
                case "eastern arrernte":
                    return "aer";
                case "eastern balochi":
                    return "bgp";
                case "eastern bolivian guaraní":
                    return "gui";
                case "eastern bru":
                    return "bru";
                case "eastern cakchiquel":
                    return "cke";
                case "eastern canadian inuktitut":
                    return "ike";
                case "eastern cham":
                    return "cjm";
                case "eastern egyptian bedawi arabic":
                    return "avl";
                case "eastern frisian":
                    return "frs";
                case "eastern gorkha tamang":
                    return "tge";
                case "eastern gurung":
                    return "ggn";
                case "eastern highland chatino":
                    return "cly";
                case "eastern highland otomi":
                    return "otm";
                case "eastern hongshuihe zhuang":
                    return "zeh";
                case "eastern huasteca nahuatl":
                    return "nhe";
                case "eastern huishui hmong":
                    return "hme";
                case "eastern jacalteco":
                    return "jac";
                case "eastern kanjobal":
                    return "kjb";
                case "eastern karaboro":
                    return "xrb";
                case "eastern katu":
                    return "ktv";
                case "eastern kayah":
                    return "eky";
                case "eastern keres":
                    return "kee";
                case "eastern krahn":
                    return "kqo";
                case "eastern lalu":
                    return "yit";
                case "eastern lawa":
                    return "lwl";
                case "eastern magar":
                    return "mgp";
                case "eastern maninkakan":
                    return "emk";
                case "eastern mari":
                    return "mhr";
                case "eastern meohang":
                    return "emg";
                case "eastern mnong":
                    return "mng";
                case "eastern muria":
                    return "emu";
                case "eastern ngad'a":
                    return "nea";
                case "eastern nisu":
                    return "nos";
                case "eastern ojibwa":
                    return "ojg";
                case "eastern oromo":
                    return "hae";
                case "eastern parbate kham":
                    return "kif";
                case "eastern penan":
                    return "pez";
                case "eastern pokomam":
                    return "poa";
                case "eastern pokomchí":
                    return "poh";
                case "eastern pomo":
                    return "peb";
                case "eastern qiandong miao":
                    return "hmq";
                case "eastern quiché":
                    return "quu";
                case "eastern tamang":
                    return "taj";
                case "eastern tawbuid":
                    return "bnj";
                case "eastern tzutujil":
                    return "tzj";
                case "eastern xiangxi miao":
                    return "muq";
                case "eastern xwla gbe":
                    return "gbx";
                case "eastern yiddish":
                    return "ydd";
                case "ebira":
                    return "igb";
                case "eblan":
                    return "xeb";
                case "ebrié":
                    return "ebr";
                case "ebughu":
                    return "ebg";
                case "ede cabe":
                    return "cbj";
                case "ede ica":
                    return "ica";
                case "ede idaca":
                    return "idd";
                case "ede ije":
                    return "ijj";
                case "ede nago":
                    return "nqg";
                case "edera awyu":
                    return "awy";
                case "edolo":
                    return "etr";
                case "edomite":
                    return "xdm";
                case "edopi":
                    return "dbf";
                case "efai":
                    return "efa";
                case "efe":
                    return "efe";
                case "efik":
                    return "efi";
                case "efutop":
                    return "ofu";
                case "ega":
                    return "ega";
                case "eggon":
                    return "ego";
                case "egyptian":
                    return "egy";
                case "egyptian arabic":
                    return "arz";
                case "ehueun":
                    return "ehu";
                case "eipomek":
                    return "eip";
                case "eitiep":
                    return "eit";
                case "ejagham":
                    return "etu";
                case "ejamat":
                    return "eja";
                case "ekajuk":
                    return "eka";
                case "ekari":
                    return "ekg";
                case "ekegusii":
                    return "guz";
                case "eki":
                    return "eki";
                case "ekit":
                    return "eke";
                case "ekpeye":
                    return "ekp";
                case "el alto zapotec":
                    return "zpp";
                case "el hugeirat":
                    return "elh";
                case "el molo":
                    return "elo";
                case "el nayar cora":
                    return "crn";
                case "elamite":
                    return "elx";
                case "eleme":
                    return "elm";
                case "elepi":
                    return "ele";
                case "elip":
                    return "ekm";
                case "elkei":
                    return "elk";
                case "elotepec zapotec":
                    return "zte";
                case "eloyi":
                    return "afo";
                case "elpaputih":
                    return "elp";
                case "elseng":
                    return "mrf";
                case "elu":
                    return "elu";
                case "elymian":
                    return "xly";
                case "e'ma buyang":
                    return "yzg";
                case "emae":
                    return "mmw";
                case "emai-iuleha-ora":
                    return "ema";
                case "eman":
                    return "emn";
                case "embaloh":
                    return "emb";
                case "emberá-baudó":
                    return "bdc";
                case "emberá-catío":
                    return "cto";
                case "emberá-chamí":
                    return "cmi";
                case "emberá-tadó":
                    return "tdc";
                case "embu":
                    return "ebu";
                case "emem":
                    return "enr";
                case "emerillon":
                    return "eme";
                case "emiliano-romagnolo":
                    return "eml";
                case "emok":
                    return "emo";
                case "emplawas":
                    return "emw";
                case "en":
                    return "enc";
                case "e'ñapa woromaipu":
                    return "pbh";
                case "enawené-nawé":
                    return "unk";
                case "ende":
                    return "end";
                case "enga":
                    return "enq";
                case "engenni":
                    return "enn";
                case "enggano":
                    return "eno";
                case "english":
                    return "eng";
                case "enrekang":
                    return "ptt";
                case "enu":
                    return "enu";
                case "enwan":
                    return "enw";
                case "enya":
                    return "gey";
                case "epena":
                    return "sja";
                case "epie":
                    return "epi";
                case "epigraphic mayan":
                    return "emy";
                case "epi-olmec":
                    return "xep";
                case "eravallan":
                    return "era";
                case "erave":
                    return "kjy";
                case "ere":
                    return "twp";
                case "eritai":
                    return "ert";
                case "erokwanas":
                    return "erw";
                case "erre":
                    return "err";
                case "ersu":
                    return "ers";
                case "eruwa":
                    return "erh";
                case "erzya":
                    return "myv";
                case "esan":
                    return "ish";
                case "ese":
                    return "mcq";
                case "ese ejja":
                    return "ese";
                case "eshtehardi":
                    return "esh";
                case "esimbi":
                    return "ags";
                case "esperanto":
                    return "epo";
                case "esselen":
                    return "esq";
                case "estado de méxico otomi":
                    return "ots";
                case "estonian":
                    return "est";
                case "esuma":
                    return "esm";
                case "etchemin":
                    return "etc";
                case "etebi":
                    return "etb";
                case "eten":
                    return "etx";
                case "eteocretan":
                    return "ecr";
                case "eteocypriot":
                    return "ecy";
                case "etkywan":
                    return "ich";
                case "eton":
                    return "etn";
                case "etruscan":
                    return "ett";
                case "etulo":
                    return "utr";
                case "europanto":
                    return "eur";
                case "evant":
                    return "bzz";
                case "even":
                    return "eve";
                case "evenki":
                    return "evn";
                case "ewage-notu":
                    return "nou";
                case "ewe":
                    return "ewe";
                case "ewondo":
                    return "ewo";
                case "extremaduran":
                    return "ext";
                case "eyak":
                    return "eya";
                case "fa d'ambu":
                    return "fab";
                case "fagani":
                    return "faf";
                case "faire atta":
                    return "azt";
                case "faita":
                    return "faj";
                case "faiwol":
                    return "fai";
                case "fala":
                    return "fax";
                case "falam chin":
                    return "cfm";
                case "fali":
                    return "fli";
                case "faliscan":
                    return "xfa";
                case "fam":
                    return "fam";
                case "fanagalo":
                    return "fng";
                case "fang":
                    return "fak";
                case "fania":
                    return "fni";
                case "fanti":
                    return "fat";
                case "far western muria":
                    return "fmu";
                case "farefare":
                    return "gur";
                case "faroese":
                    return "fao";
                case "fas":
                    return "fqs";
                case "fasu":
                    return "faa";
                case "fataleka":
                    return "far";
                case "fataluku":
                    return "ddg";
                case "fayu":
                    return "fau";
                case "fedan":
                    return "pdn";
                case "fe'fe'":
                    return "fmp";
                case "fembe":
                    return "agl";
                case "fernando po creole english":
                    return "fpe";
                case "feroge":
                    return "fer";
                case "fijian":
                    return "fij";
                case "fijian hindustani":
                    return "hif";
                case "filipino":
                    return "fil";
                case "filomena mata-coahuitlán totonac":
                    return "tlp";
                case "finallig":
                    return "bkb";
                case "finnish":
                    return "fin";
                case "finongan":
                    return "fag";
                case "fipa":
                    return "fip";
                case "firan":
                    return "fir";
                case "fiwaga":
                    return "fiw";
                case "flinders island":
                    return "fln";
                case "foau":
                    return "flh";
                case "foi":
                    return "foi";
                case "foia foia":
                    return "ffi";
                case "folopa":
                    return "ppo";
                case "foma":
                    return "fom";
                case "fon":
                    return "fon";
                case "fongoro":
                    return "fgr";
                case "foodo":
                    return "fod";
                case "forak":
                    return "frq";
                case "fordata":
                    return "frd";
                case "fore":
                    return "for";
                case "forest enets":
                    return "enf";
                case "forest maninka":
                    return "myq";
                case "fortsenal":
                    return "frt";
                case "francisco león zoque":
                    return "zos";
                case "franco-provençal":
                    return "frp";
                case "frankish":
                    return "frk";
                case "french":
                    return "fra";
                case "friulian":
                    return "fur";
                case "fulah":
                    return "ful";
                case "fuliiru":
                    return "flr";
                case "fulniô":
                    return "fun";
                case "fum":
                    return "fum";
                case "fungwa":
                    return "ula";
                case "fur":
                    return "fvr";
                case "furu":
                    return "fuu";
                case "futuna-aniwa":
                    return "fut";
                case "fuyug":
                    return "fuy";
                case "fwâi":
                    return "fwa";
                case "fwe":
                    return "fwe";
                case "fyam":
                    return "pym";
                case "fyer":
                    return "fie";
                case "ga":
                    return "gaa";
                case "gaa":
                    return "ttb";
                case "gaam":
                    return "tbi";
                case "ga'anda":
                    return "gqa";
                case "gabri":
                    return "gab";
                case "gabrielino-fernandeño":
                    return "xgf";
                case "gabutamon":
                    return "gav";
                case "gadang":
                    return "gdk";
                case "ga'dang":
                    return "gdg";
                case "gaddang":
                    return "gad";
                case "gaddi":
                    return "gbk";
                case "gade":
                    return "ged";
                case "gade lohar":
                    return "gda";
                case "gadjerawang":
                    return "gdh";
                case "gadsup":
                    return "gaj";
                case "gaelic":
                    return "gla";
                case "gafat":
                    return "gft";
                case "gagadu":
                    return "gbu";
                case "gagauz":
                    return "gag";
                case "gagnoa bété":
                    return "btg";
                case "gagu":
                    return "ggu";
                case "gahri":
                    return "bfu";
                case "gaikundi":
                    return "gbf";
                case "gail":
                    return "gic";
                case "gaina":
                    return "gcn";
                case "gal":
                    return "gap";
                case "galambu":
                    return "glo";
                case "galatian":
                    return "xga";
                case "galela":
                    return "gbi";
                case "galeya":
                    return "gar";
                case "galibi carib":
                    return "car";
                case "galice":
                    return "gce";
                case "galician":
                    return "glg";
                case "galindan":
                    return "xgl";
                case "gallurese sardinian":
                    return "sdn";
                case "galo adi":
                    return "adl";
                case "galoli":
                    return "gal";
                case "gamale kham":
                    return "kgj";
                case "gambera":
                    return "gma";
                case "gambian wolof":
                    return "wof";
                case "gamilaraay":
                    return "kld";
                case "gamit":
                    return "gbl";
                case "gamkonora":
                    return "gak";
                case "gamo-gofa-dawro":
                    return "gmo";
                case "gamo-ningi":
                    return "bte";
                case "gan chinese":
                    return "gan";
                case "gana":
                    return "gnk";
                case "ganang":
                    return "gne";
                case "ganda":
                    return "lug";
                case "gane":
                    return "gzn";
                case "ganggalida":
                    return "gcd";
                case "ganglau":
                    return "ggl";
                case "gangte":
                    return "gnb";
                case "gangulu":
                    return "gnl";
                case "gants":
                    return "gao";
                case "ganza":
                    return "gza";
                case "ganzi":
                    return "gnz";
                case "gao":
                    return "gga";
                case "gapapaiwa":
                    return "pwg";
                case "garawa":
                    return "gbc";
                case "garhwali":
                    return "gbm";
                case "garifuna":
                    return "cab";
                case "garig-ilgar":
                    return "ilg";
                case "garo":
                    return "grt";
                case "garre":
                    return "gex";
                case "garus":
                    return "gyb";
                case "garza":
                    return "xgr";
                case "gata'":
                    return "gaq";
                case "gavar":
                    return "gou";
                case "gavião do jiparaná":
                    return "gvo";
                case "gawar-bati":
                    return "gwt";
                case "gawwada":
                    return "gwd";
                case "gayil":
                    return "gyl";
                case "gayo":
                    return "gay";
                case "gazi":
                    return "gzi";
                case "gbagyi":
                    return "gbr";
                case "gbanu":
                    return "gbv";
                case "gbanziri":
                    return "gbg";
                case "gbari":
                    return "gby";
                case "gbati-ri":
                    return "gti";
                case "gbaya":
                    return "gba";
                case "gbaya-bossangoa":
                    return "gbp";
                case "gbaya-bozoum":
                    return "gbq";
                case "gbaya-mbodomo":
                    return "gmm";
                case "gbayi":
                    return "gyg";
                case "gbesi gbe":
                    return "gbs";
                case "gbii":
                    return "ggb";
                case "gbiri-niragu":
                    return "grh";
                case "gboloo grebo":
                    return "gec";
                case "ge":
                    return "hmj";
                case "geba karen":
                    return "kvq";
                case "gebe":
                    return "gei";
                case "gedaged":
                    return "gdd";
                case "gedeo":
                    return "drs";
                case "geez":
                    return "gez";
                case "geji":
                    return "gji";
                case "geko karen":
                    return "ghk";
                case "gela":
                    return "nlg";
                case "gelao":
                    return "gio";
                case "geman deng":
                    return "mxj";
                case "geme":
                    return "geq";
                case "gen":
                    return "gej";
                case "gende":
                    return "gaf";
                case "gengle":
                    return "geg";
                case "georgian":
                    return "kat";
                case "gepo":
                    return "ygp";
                case "gera":
                    return "gew";
                case "german":
                    return "deu";
                case "geruma":
                    return "gea";
                case "geser-gorom":
                    return "ges";
                case "gey":
                    return "guv";
                case "ghadamès":
                    return "gha";
                case "ghanongga":
                    return "ghn";
                case "ghari":
                    return "gri";
                case "ghayavi":
                    return "bmk";
                case "gheg albanian":
                    return "aln";
                case "ghera":
                    return "ghr";
                case "ghodoberi":
                    return "gdo";
                case "ghomálá'":
                    return "bbj";
                case "ghomara":
                    return "gho";
                case "ghotuo":
                    return "aaa";
                case "ghulfan":
                    return "ghl";
                case "giangan":
                    return "bgi";
                case "gibanawa":
                    return "gib";
                case "gidar":
                    return "gid";
                case "giiwo":
                    return "kks";
                case "gikuyu":
                    return "kik";
                case "gikyode":
                    return "acd";
                case "gilaki":
                    return "glk";
                case "gilbertese":
                    return "gil";
                case "gilima":
                    return "gix";
                case "gilyak":
                    return "niv";
                case "gimi":
                    return "gim";
                case "gimme":
                    return "kmp";
                case "gimnime":
                    return "gmn";
                case "ginuman":
                    return "gnm";
                case "ginyanga":
                    return "ayg";
                case "girawa":
                    return "bbr";
                case "giryama":
                    return "nyf";
                case "gitonga":
                    return "toh";
                case "gitua":
                    return "ggt";
                case "gitxsan":
                    return "git";
                case "giyug":
                    return "giy";
                case "gizrra":
                    return "tof";
                case "glaro-twabo":
                    return "glr";
                case "glavda":
                    return "glw";
                case "glio-oubi":
                    return "oub";
                case "gnau":
                    return "gnu";
                case "goan konkani":
                    return "gom";
                case "goaria":
                    return "gig";
                case "gobasi":
                    return "goi";
                case "gobu":
                    return "gox";
                case "godié":
                    return "god";
                case "godwari":
                    return "gdx";
                case "goemai":
                    return "ank";
                case "gogo":
                    return "gog";
                case "gogodala":
                    return "ggw";
                case "gokana":
                    return "gkn";
                case "gola":
                    return "gol";
                case "golin":
                    return "gvf";
                case "gondi":
                    return "gon";
                case "gone dau":
                    return "goo";
                case "gongduk":
                    return "goe";
                case "gonja":
                    return "gjn";
                case "gooniyandi":
                    return "gni";
                case "gor":
                    return "gqr";
                case "gorakor":
                    return "goc";
                case "gorap":
                    return "goq";
                case "gorontalo":
                    return "gor";
                case "gorovu":
                    return "grq";
                case "gorowa":
                    return "gow";
                case "gothic":
                    return "got";
                case "goundo":
                    return "goy";
                case "gourmanchéma":
                    return "gux";
                case "gowlan":
                    return "goj";
                case "gowli":
                    return "gok";
                case "gowro":
                    return "gwf";
                case "gozarkhani":
                    return "goz";
                case "grangali":
                    return "nli";
                case "grass koiari":
                    return "kbk";
                case "grebo":
                    return "grb";
                case "green gelao":
                    return "giq";
                case "greenlandic":
                    return "kal";
                case "grenadian creole english":
                    return "gcl";
                case "gresi":
                    return "grs";
                case "groma":
                    return "gro";
                case "gronings":
                    return "gos";
                case "gros ventre":
                    return "ats";
                case "gua":
                    return "gwx";
                case "guadeloupean creole french":
                    return "gcf";
                case "guahibo":
                    return "guh";
                case "guajá":
                    return "gvj";
                case "guajajára":
                    return "gub";
                case "guambiano":
                    return "gum";
                case "guana":
                    return "gqn";
                case "guanano":
                    return "gvc";
                case "guanche":
                    return "gnc";
                case "guanyinqiao":
                    return "jiq";
                case "guarani":
                    return "grn";
                case "guarayu":
                    return "gyr";
                case "guarequena":
                    return "gae";
                case "guató":
                    return "gta";
                case "guayabero":
                    return "guo";
                case "gudanji":
                    return "nji";
                case "gude":
                    return "gde";
                case "gudu":
                    return "gdu";
                case "guduf-gava":
                    return "gdf";
                case "guerrero amuzgo":
                    return "amu";
                case "guerrero nahuatl":
                    return "ngu";
                case "guevea de humboldt zapotec":
                    return "zpg";
                case "gugadj":
                    return "ggd";
                case "gugu badhun":
                    return "gdc";
                case "gugu warra":
                    return "wrw";
                case "gugubera":
                    return "kkp";
                case "guguyimidjir":
                    return "kky";
                case "guhu-samane":
                    return "ghs";
                case "guianese creole french":
                    return "gcr";
                case "guibei zhuang":
                    return "zgb";
                case "guiberoua béte":
                    return "bet";
                case "guibian zhuang":
                    return "zgn";
                case "güilá zapotec":
                    return "ztu";
                case "guinea kpelle":
                    return "gkp";
                case "guiqiong":
                    return "gqi";
                case "gujarati":
                    return "guj";
                case "gujari":
                    return "gju";
                case "gula":
                    return "glu";
                case "gula iro":
                    return "glj";
                case "gula'alaa":
                    return "gmb";
                case "gulay":
                    return "gvl";
                case "gule":
                    return "gly";
                case "gulf arabic":
                    return "afb";
                case "guliguli":
                    return "gli";
                case "gumalu":
                    return "gmu";
                case "gumatj":
                    return "gnn";
                case "gumawana":
                    return "gvs";
                case "gumuz":
                    return "guk";
                case "gun":
                    return "guw";
                case "gundi":
                    return "gdi";
                case "gungabula":
                    return "gyf";
                case "gungu":
                    return "rub";
                case "guntai":
                    return "gnt";
                case "gunwinggu":
                    return "gup";
                case "gunya":
                    return "gyy";
                case "gupa-abawa":
                    return "gpa";
                case "gupapuyngu":
                    return "guf";
                case "guragone":
                    return "gge";
                case "guramalum":
                    return "grz";
                case "gurani":
                    return "hac";
                case "gurdjar":
                    return "gdj";
                case "gureng gureng":
                    return "gnr";
                case "gurgula":
                    return "ggg";
                case "guriaso":
                    return "grx";
                case "gurinji":
                    return "gue";
                case "gurmana":
                    return "gvm";
                case "guro":
                    return "goa";
                case "guruntum-mbaaru":
                    return "grd";
                case "gusan":
                    return "gsn";
                case "gusilay":
                    return "gsl";
                case "guwamu":
                    return "gwu";
                case "guya":
                    return "gka";
                case "guyanese creole english":
                    return "gyn";
                case "guyani":
                    return "gvy";
                case "gvoko":
                    return "ngs";
                case "gwa":
                    return "gwb";
                case "gwahatike":
                    return "dah";
                case "gwamhi-wuri":
                    return "bga";
                case "gwandara":
                    return "gwn";
                case "gweda":
                    return "grw";
                case "gweno":
                    return "gwe";
                case "gwere":
                    return "gwr";
                case "gwi":
                    return "gwj";
                case "gwichʼin":
                    return "gwi";
                case "gyele":
                    return "gyi";
                case "gyem":
                    return "gye";
                case "ha":
                    return "haq";
                case "habu":
                    return "hbu";
                case "hadiyya":
                    return "hdy";
                case "hadothi":
                    return "hoj";
                case "hadrami":
                    return "xhd";
                case "hadrami arabic":
                    return "ayh";
                case "hadza":
                    return "hts";
                case "haeke":
                    return "aek";
                case "hahon":
                    return "hah";
                case "hai":
                    return "hgm";
                case "haida":
                    return "hai";
                case "haigwai":
                    return "hgw";
                case "hainyaxo bozo":
                    return "bzx";
                case "haisla":
                    return "has";
                case "haitian":
                    return "hat";
                case "haitian vodoun culture language":
                    return "hvc";
                case "haji":
                    return "hji";
                case "hajong":
                    return "haj";
                case "haka chin":
                    return "cnh";
                case "hakka chinese":
                    return "hak";
                case "hakö":
                    return "hao";
                case "halang":
                    return "hal";
                case "halang doan":
                    return "hld";
                case "halbi":
                    return "hlb";
                case "halh mongolian":
                    return "khk";
                case "halia":
                    return "hla";
                case "halkomelem":
                    return "hur";
                case "hamap":
                    return "hmu";
                case "hamba":
                    return "hba";
                case "hamer-banna":
                    return "amf";
                case "hamtai":
                    return "hmt";
                case "han":
                    return "haa";
                case "hanga":
                    return "hag";
                case "hanga hundi":
                    return "wos";
                case "hangaza":
                    return "han";
                case "hani":
                    return "hni";
                case "hano":
                    return "lml";
                case "hanunoo":
                    return "hnn";
                case "harami":
                    return "xha";
                case "harari":
                    return "har";
                case "harijan kinnauri":
                    return "kjo";
                case "haroi":
                    return "hro";
                case "harsusi":
                    return "hss";
                case "haruai":
                    return "tmd";
                case "haruku":
                    return "hrk";
                case "haryanvi":
                    return "bgc";
                case "harzani":
                    return "hrz";
                case "hasha":
                    return "ybj";
                case "hassaniyya":
                    return "mey";
                case "hatam":
                    return "had";
                case "hattic":
                    return "xht";
                case "hausa":
                    return "hau";
                case "havasupai-walapai-yavapai":
                    return "yuf";
                case "haveke":
                    return "hvk";
                case "havu":
                    return "hav";
                case "hawai'i creole english":
                    return "hwc";
                case "hawaiian":
                    return "haw";
                case "haya":
                    return "hay";
                case "hazaragi":
                    return "haz";
                case "hdi":
                    return "xed";
                case "hebrew":
                    return "heb";
                case "hehe":
                    return "heh";
                case "heiban":
                    return "hbn";
                case "heiltsuk":
                    return "hei";
                case "helambu sherpa":
                    return "scp";
                case "helong":
                    return "heg";
                case "hema":
                    return "nix";
                case "hemba":
                    return "hem";
                case "herdé":
                    return "hed";
                case "herero":
                    return "her";
                case "hermit":
                    return "llf";
                case "hernican":
                    return "xhr";
                case "hértevin":
                    return "hrt";
                case "hewa":
                    return "ham";
                case "heyo":
                    return "auk";
                case "hiberno-scottish gaelic":
                    return "ghc";
                case "hibito":
                    return "hib";
                case "hidatsa":
                    return "hid";
                case "hieroglyphic luwian":
                    return "hlu";
                case "higaonon":
                    return "mba";
                case "highland konjo":
                    return "kjk";
                case "highland oaxaca chontal":
                    return "chd";
                case "highland popoluca":
                    return "poi";
                case "highland puebla nahuatl":
                    return "azz";
                case "highland totonac":
                    return "tos";
                case "hijazi arabic":
                    return "acw";
                case "hijuk":
                    return "hij";
                case "hiligaynon":
                    return "hil";
                case "himarimã":
                    return "hir";
                case "hindi":
                    return "hin";
                case "hinduri":
                    return "hii";
                case "hinukh":
                    return "gin";
                case "hiri motu":
                    return "hmo";
                case "hittite":
                    return "hit";
                case "hitu":
                    return "htu";
                case "hiw":
                    return "hiw";
                case "hixkaryána":
                    return "hix";
                case "hlai":
                    return "lic";
                case "hlepho phowa":
                    return "yhl";
                case "hlersu":
                    return "hle";
                case "hmar":
                    return "hmr";
                case "hmong":
                    return "hmn";
                case "hmong daw":
                    return "mww";
                case "hmong dô":
                    return "hmv";
                case "hmong don":
                    return "hmf";
                case "hmong njua":
                    return "hnj";
                case "hmong shua":
                    return "hmz";
                case "hmwaveke":
                    return "mrk";
                case "ho":
                    return "hoc";
                case "hoava":
                    return "hoa";
                case "hobyót":
                    return "hoh";
                case "ho-chunk":
                    return "win";
                case "hoia hoia":
                    return "hhi";
                case "holikachuk":
                    return "hoi";
                case "holiya":
                    return "hoy";
                case "holma":
                    return "hod";
                case "holoholo":
                    return "hoo";
                case "holu":
                    return "hol";
                case "homa":
                    return "hom";
                case "hõne":
                    return "juh";
                case "honi":
                    return "how";
                case "hopi":
                    return "hop";
                case "horned miao":
                    return "hrm";
                case "horo":
                    return "hor";
                case "horom":
                    return "hoe";
                case "horpa":
                    return "ero";
                case "horuru":
                    return "hrr";
                case "hote":
                    return "hot";
                case "hoti":
                    return "hti";
                case "hovongan":
                    return "hov";
                case "hoyahoya":
                    return "hhy";
                case "hozo":
                    return "hoz";
                case "hpon":
                    return "hpo";
                case "hrangkhol":
                    return "hra";
                case "hre":
                    return "hre";
                case "hruso":
                    return "hru";
                case "hu":
                    return "huo";
                case "hua":
                    return "huc";
                case "huachipaeri":
                    return "hug";
                case "huallaga huánuco quechua":
                    return "qub";
                case "huamalíes-dos de mayo huánuco quechua":
                    return "qvh";
                case "huambisa":
                    return "hub";
                case "huarijio":
                    return "var";
                case "huaulu":
                    return "hud";
                case "huautla mazatec":
                    return "mau";
                case "huaxcaleca nahuatl":
                    return "nhq";
                case "huaylas ancash quechua":
                    return "qwh";
                case "huaylla wanca quechua":
                    return "qvw";
                case "huba":
                    return "hbb";
                case "huehuetla tepehua":
                    return "tee";
                case "huichol":
                    return "hch";
                case "huilliche":
                    return "huh";
                case "huitepec mixtec":
                    return "mxs";
                case "huixtán tzotzil":
                    return "tzu";
                case "huizhou chinese":
                    return "czh";
                case "hukumina":
                    return "huw";
                case "hula":
                    return "hul";
                case "hulaulá":
                    return "huy";
                case "huli":
                    return "hui";
                case "hulung":
                    return "huk";
                case "humburi senni songhay":
                    return "hmb";
                case "humene":
                    return "huf";
                case "humla":
                    return "hut";
                case "hunde":
                    return "hke";
                case "hung":
                    return "hnu";
                case "hungana":
                    return "hum";
                case "hungarian":
                    return "hun";
                case "hungworo":
                    return "nat";
                case "hunjara-kaina ke":
                    return "hkk";
                case "hunnic":
                    return "xhc";
                case "hun-saare":
                    return "dud";
                case "hunsrik":
                    return "hrx";
                case "hunzib":
                    return "huz";
                case "hupa":
                    return "hup";
                case "hupdë":
                    return "jup";
                case "hupla":
                    return "hap";
                case "hurrian":
                    return "xhu";
                case "hutterisch":
                    return "geh";
                case "hwana":
                    return "hwo";
                case "hya":
                    return "hya";
                case "hyam":
                    return "jab";
                case "iaai":
                    return "iai";
                case "iamalele":
                    return "yml";
                case "iapama":
                    return "iap";
                case "iatmul":
                    return "ian";
                case "iau":
                    return "tmu";
                case "ibali teke":
                    return "tek";
                case "ibaloi":
                    return "ibl";
                case "iban":
                    return "iba";
                case "ibanag":
                    return "ibg";
                case "ibani":
                    return "iby";
                case "ibatan":
                    return "ivb";
                case "iberian":
                    return "xib";
                case "ibibio":
                    return "ibb";
                case "ibilo":
                    return "ibi";
                case "ibino":
                    return "ibn";
                case "ibu":
                    return "ibu";
                case "ibuoro":
                    return "ibr";
                case "icelandic":
                    return "isl";
                case "iceve-maci":
                    return "bec";
                case "ida'an":
                    return "dbj";
                case "idakho-isukha-tiriki":
                    return "ida";
                case "idaté":
                    return "idt";
                case "idere":
                    return "ide";
                case "idesa":
                    return "ids";
                case "idi":
                    return "idi";
                case "ido":
                    return "ido";
                case "idoma":
                    return "idu";
                case "idon":
                    return "idc";
                case "idu-mishmi":
                    return "clk";
                case "idun":
                    return "ldb";
                case "iduna":
                    return "viv";
                case "ifè":
                    return "ife";
                case "ifo":
                    return "iff";
                case "igala":
                    return "igl";
                case "igana":
                    return "igg";
                case "igbo":
                    return "ibo";
                case "igede":
                    return "ige";
                case "ignaciano":
                    return "ign";
                case "igo":
                    return "ahl";
                case "iguta":
                    return "nar";
                case "igwe":
                    return "igw";
                case "iha":
                    return "ihp";
                case "iha based pidgin":
                    return "ihb";
                case "ihievbe":
                    return "ihi";
                case "ija-zuba":
                    return "vki";
                case "ik":
                    return "ikx";
                case "ika":
                    return "ikk";
                case "ikizu":
                    return "ikz";
                case "iko":
                    return "iki";
                case "ikobi-mena":
                    return "meb";
                case "ikoma-nata-isenye":
                    return "ntk";
                case "ikpeng":
                    return "txi";
                case "ikpeshi":
                    return "ikp";
                case "ikposo":
                    return "kpo";
                case "iku-gora-ankwa":
                    return "ikv";
                case "ikulu":
                    return "ikl";
                case "ikwere":
                    return "ikw";
                case "ila":
                    return "ilb";
                case "ile ape":
                    return "ila";
                case "ili turki":
                    return "ili";
                case "ilianen manobo":
                    return "mbi";
                case "ili'uun":
                    return "ilu";
                case "illyrian":
                    return "xil";
                case "iloko":
                    return "ilo";
                case "ilongot":
                    return "ilk";
                case "ilue":
                    return "ilv";
                case "ilwana":
                    return "mlk";
                case "imbabura highland quichua":
                    return "qvi";
                case "imbongu":
                    return "imo";
                case "imeraguen":
                    return "ime";
                case "imonda":
                    return "imn";
                case "imperial aramaic":
                    return "arc";
                case "imroing":
                    return "imr";
                case "inabaknon":
                    return "abx";
                case "inapang":
                    return "mzu";
                case "iñapari":
                    return "inp";
                case "inari sami":
                    return "smn";
                case "indonesian":
                    return "ind";
                case "indonesian bajau":
                    return "bdl";
                case "indo-portuguese":
                    return "idb";
                case "indri":
                    return "idr";
                case "indus kohistani":
                    return "mvy";
                case "indus valley language":
                    return "xiv";
                case "inebu one":
                    return "oin";
                case "ineseño":
                    return "inz";
                case "inga":
                    return "inb";
                case "ingrian":
                    return "izh";
                case "ingush":
                    return "inh";
                case "inlaod itneg":
                    return "iti";
                case "inoke-yate":
                    return "ino";
                case "inonhan":
                    return "loc";
                case "inor":
                    return "ior";
                case "inpui naga":
                    return "nkf";
                case "interglossa":
                    return "igs";
                case "interlingua":
                    return "ina";
                case "interlingue":
                    return "ile";
                case "intha":
                    return "int";
                case "inuktitut":
                    return "iku";
                case "inupiaq":
                    return "ipk";
                case "iowa-oto":
                    return "iow";
                case "ipalapa amuzgo":
                    return "azm";
                case "ipiko":
                    return "ipo";
                case "ipili":
                    return "ipi";
                case "ipulo":
                    return "ass";
                case "iquito":
                    return "iqu";
                case "ir":
                    return "irr";
                case "irántxe":
                    return "irn";
                case "iranun":
                    return "ill";
                case "iraqw":
                    return "irk";
                case "irarutu":
                    return "irh";
                case "iraya":
                    return "iry";
                case "iresim":
                    return "ire";
                case "iriga bicolano":
                    return "bto";
                case "irigwe":
                    return "iri";
                case "irish":
                    return "gle";
                case "irula":
                    return "iru";
                case "isabi":
                    return "isa";
                case "isanzu":
                    return "isn";
                case "isarog agta":
                    return "agk";
                case "isconahua":
                    return "isc";
                case "isebe":
                    return "igo";
                case "isekiri":
                    return "its";
                case "isinai":
                    return "inn";
                case "isirawa":
                    return "srl";
                case "island carib":
                    return "crb";
                case "islander creole english":
                    return "icr";
                case "isnag":
                    return "isd";
                case "isoko":
                    return "iso";
                case "isthmus mixe":
                    return "mir";
                case "isthmus zapotec":
                    return "zai";
                case "isthmus-cosoleacaque nahuatl":
                    return "nhk";
                case "isthmus-mecayapan nahuatl":
                    return "nhx";
                case "isthmus-pajapan nahuatl":
                    return "nhp";
                case "istriot":
                    return "ist";
                case "istro romanian":
                    return "ruo";
                case "isu":
                    return "isu";
                case "italian":
                    return "ita";
                case "itawit":
                    return "itv";
                case "itelmen":
                    return "itl";
                case "itene":
                    return "ite";
                case "iteri":
                    return "itr";
                case "itik":
                    return "itx";
                case "ito":
                    return "itw";
                case "itonama":
                    return "ito";
                case "itu mbon uzo":
                    return "itm";
                case "itundujia mixtec":
                    return "mce";
                case "itzá":
                    return "itz";
                case "iu mien":
                    return "ium";
                case "ivatan":
                    return "ivv";
                case "ivbie north-okpela-arhe":
                    return "atg";
                case "iwaidja":
                    return "ibd";
                case "i-wak":
                    return "iwk";
                case "iwal":
                    return "kbm";
                case "iwam":
                    return "iwm";
                case "iwur":
                    return "iwo";
                case "ixcatec":
                    return "ixc";
                case "ixcatlán mazatec":
                    return "mzi";
                case "ixtatán chuj":
                    return "cnm";
                case "ixtayutla mixtec":
                    return "vmj";
                case "ixtenco otomi":
                    return "otz";
                case "iyayu":
                    return "iya";
                case "iyive":
                    return "uiv";
                case "iyo":
                    return "nca";
                case "iyojwa'ja chorote":
                    return "crt";
                case "iyo'wujwa chorote":
                    return "crq";
                case "izere":
                    return "izr";
                case "izi-ezaa-ikwo-mgbo":
                    return "izi";
                case "izon":
                    return "ijc";
                case "izora":
                    return "cbo";
                case "jabutí":
                    return "jbt";
                case "jad":
                    return "jda";
                case "jadgali":
                    return "jdg";
                case "jah hut":
                    return "jah";
                case "jahanka":
                    return "jad";
                case "jair awyu":
                    return "awv";
                case "jakati":
                    return "jat";
                case "jakun":
                    return "jak";
                case "jalapa de díaz mazatec":
                    return "maj";
                case "jalkunan":
                    return "bxl";
                case "jamaican creole english":
                    return "jam";
                case "jamamadí":
                    return "jaa";
                case "jambi malay":
                    return "jax";
                case "jamiltepec mixtec":
                    return "mxt";
                case "jamsay dogon":
                    return "djm";
                case "jandavra":
                    return "jnd";
                case "jangkang":
                    return "djo";
                case "jangshung":
                    return "jna";
                case "janji":
                    return "jni";
                case "japanese":
                    return "jpn";
                case "japrería":
                    return "jru";
                case "jaqaru":
                    return "jqr";
                case "jara":
                    return "jaf";
                case "jarai":
                    return "jra";
                case "jarawa":
                    return "jar";
                case "jaru":
                    return "ddj";
                case "jauja wanca quechua":
                    return "qxw";
                case "jaunsari":
                    return "jns";
                case "javanese":
                    return "jav";
                case "javindo":
                    return "jvd";
                case "jawe":
                    return "jaz";
                case "jaya":
                    return "jyy";
                case "jebero":
                    return "jeb";
                case "jeh":
                    return "jeh";
                case "jehai":
                    return "jhi";
                case "jemez":
                    return "tow";
                case "jenaama bozo":
                    return "bze";
                case "jeng":
                    return "jeg";
                case "jennu kurumba":
                    return "xuj";
                case "jere":
                    return "jer";
                case "jeri kuo":
                    return "jek";
                case "jerung":
                    return "jee";
                case "jewish babylonian aramaic":
                    return "tmr";
                case "jewish palestinian aramaic":
                    return "jpa";
                case "jiamao":
                    return "jio";
                case "jiarong":
                    return "jya";
                case "jiba":
                    return "juo";
                case "jibu":
                    return "jib";
                case "jicarilla apache":
                    return "apj";
                case "jiiddu":
                    return "jii";
                case "jilbe":
                    return "jie";
                case "jilim":
                    return "jil";
                case "jimi":
                    return "jim";
                case "jina":
                    return "jia";
                case "jingpho":
                    return "kac";
                case "jinyu chinese":
                    return "cjy";
                case "jiongnai bunu":
                    return "pnu";
                case "jirel":
                    return "jul";
                case "jiru":
                    return "jrr";
                case "jita":
                    return "jit";
                case "jju":
                    return "kaj";
                case "joba":
                    return "job";
                case "jofotek-bromnya":
                    return "jbr";
                case "jola-fonyi":
                    return "dyo";
                case "jola-kasa":
                    return "csk";
                case "jonkor bourmataguil":
                    return "jeu";
                case "jorá":
                    return "jor";
                case "jorto":
                    return "jrt";
                case "jowulu":
                    return "jow";
                case "joyabaj quiché":
                    return "quj";
                case "ju":
                    return "juu";
                case "juang":
                    return "jun";
                case "judeo-arabic":
                    return "jrb";
                case "judeo-berber":
                    return "jbe";
                case "judeo-georgian":
                    return "jge";
                case "judeo-iraqi arabic":
                    return "yhd";
                case "judeo-italian":
                    return "itk";
                case "judeo-moroccan arabic":
                    return "aju";
                case "judeo-persian":
                    return "jpr";
                case "judeo-tat":
                    return "jdt";
                case "judeo-tripolitanian arabic":
                    return "yud";
                case "judeo-tunisian arabic":
                    return "ajt";
                case "judeo-yemeni arabic":
                    return "jye";
                case "jukun takum":
                    return "jbu";
                case "júma":
                    return "jua";
                case "jumjum":
                    return "jum";
                case "jumli":
                    return "jml";
                case "jungle inga":
                    return "inj";
                case "juquila mixe":
                    return "mxq";
                case "jur modo":
                    return "bex";
                case "juray":
                    return "juy";
                case "jurchen":
                    return "juc";
                case "jurúna":
                    return "jur";
                case "jutish":
                    return "jut";
                case "juwal":
                    return "mwb";
                case "juxtlahuaca mixtec":
                    return "vmc";
                case "jwira-pepesa":
                    return "jwi";
                case "kaamba":
                    return "xku";
                case "kaan":
                    return "ldl";
                case "kaansa":
                    return "gna";
                case "kaapor":
                    return "urb";
                case "kaba":
                    return "ksp";
                case "kabalai":
                    return "kvf";
                case "kabardian":
                    return "kbd";
                case "kabatei":
                    return "xkp";
                case "kabixí":
                    return "xbx";
                case "kabiyé":
                    return "kbp";
                case "kabola":
                    return "klz";
                case "kabore one":
                    return "onk";
                case "kabras":
                    return "lkb";
                case "kaburi":
                    return "uka";
                case "kabutra":
                    return "kbu";
                case "kabuverdianu":
                    return "kea";
                case "kabwa":
                    return "cwa";
                case "kabwari":
                    return "kcw";
                case "kabyle":
                    return "kab";
                case "kachama-ganjule":
                    return "kcx";
                case "kachari":
                    return "xac";
                case "kachchi":
                    return "kfr";
                case "kachi koli":
                    return "gjk";
                case "kacipo-balesi":
                    return "koe";
                case "kaco'":
                    return "xkk";
                case "kadai":
                    return "kzd";
                case "kadar":
                    return "kej";
                case "kadara":
                    return "kad";
                case "kadaru":
                    return "kdu";
                case "kadiwéu":
                    return "kbc";
                case "kado":
                    return "kdv";
                case "kaduo":
                    return "ktp";
                case "kafa":
                    return "kbr";
                case "kafoa":
                    return "kpu";
                case "kagan kalagan":
                    return "kll";
                case "kagate":
                    return "syw";
                case "kagayanen":
                    return "cgc";
                case "kag-fer-jiir-koor-ror-us-zuksun":
                    return "gel";
                case "kagoma":
                    return "kdm";
                case "kagoro":
                    return "xkg";
                case "kagulu":
                    return "kki";
                case "kahe":
                    return "hka";
                case "kahua":
                    return "agw";
                case "kaian":
                    return "kct";
                case "kaibobo":
                    return "kzb";
                case "kaidipang":
                    return "kzp";
                case "kaiep":
                    return "kbw";
                case "kaikadi":
                    return "kep";
                case "kaike":
                    return "kzq";
                case "kaiku":
                    return "kkq";
                case "kaimbé":
                    return "xai";
                case "kaimbulawa":
                    return "zka";
                case "kaingang":
                    return "kgp";
                case "kairak":
                    return "ckr";
                case "kairiru":
                    return "kxa";
                case "kairui-midiki":
                    return "krd";
                case "kais":
                    return "kzm";
                case "kaivi":
                    return "kce";
                case "kaiwá":
                    return "kgk";
                case "kaiy":
                    return "tcq";
                case "kajakse":
                    return "ckq";
                case "kajali":
                    return "xkj";
                case "kajaman":
                    return "kag";
                case "kakabai":
                    return "kqf";
                case "kakabe":
                    return "kke";
                case "kakanda":
                    return "kka";
                case "kakauhua":
                    return "kbf";
                case "kaki ae":
                    return "tbd";
                case "kakihum":
                    return "kxe";
                case "kako":
                    return "kkj";
                case "kakwa":
                    return "keo";
                case "kala lagaw ya":
                    return "mwp";
                case "kalabakan":
                    return "kve";
                case "kalabari":
                    return "ijn";
                case "kalabra":
                    return "kzz";
                case "kalagan":
                    return "kqe";
                case "kalaktang monpa":
                    return "kkf";
                case "kalam":
                    return "kmh";
                case "kalami":
                    return "gwc";
                case "kalamsé":
                    return "knz";
                case "kalanadi":
                    return "wkl";
                case "kalanga":
                    return "kck";
                case "kalao":
                    return "kly";
                case "kalapuya":
                    return "kyl";
                case "kalarko":
                    return "kba";
                case "kalasha":
                    return "kls";
                case "kalenjin":
                    return "kln";
                case "kalispel-pend d'oreille":
                    return "fla";
                case "kalkoti":
                    return "xka";
                case "kalkutung":
                    return "ktg";
                case "kalmyk":
                    return "xal";
                case "kalo finnish romani":
                    return "rmf";
                case "kalou":
                    return "ywa";
                case "kaluli":
                    return "bco";
                case "kalumpang":
                    return "kli";
                case "kam":
                    return "kdx";
                case "kamakan":
                    return "vkm";
                case "kamang":
                    return "woi";
                case "kamano":
                    return "kbq";
                case "kamantan":
                    return "kci";
                case "kamar":
                    return "keq";
                case "kamara":
                    return "jmr";
                case "kamarian":
                    return "kzx";
                case "kamaru":
                    return "kgx";
                case "kamas":
                    return "xas";
                case "kamasa":
                    return "klp";
                case "kamasau":
                    return "kms";
                case "kamayo":
                    return "kyk";
                case "kamayurá":
                    return "kay";
                case "kamba":
                    return "kam";
                case "kambaata":
                    return "ktb";
                case "kambaira":
                    return "kyy";
                case "kambera":
                    return "xbr";
                case "kamberau":
                    return "irx";
                case "kambiwá":
                    return "xbw";
                case "kami":
                    return "kmi";
                case "kamo":
                    return "kcq";
                case "kamoro":
                    return "kgq";
                case "kamta":
                    return "rkt";
                case "kamu":
                    return "xmu";
                case "kamula":
                    return "xla";
                case "kamviri":
                    return "xvi";
                case "kamwe":
                    return "hig";
                case "kanakanabu":
                    return "xnb";
                case "kanamarí":
                    return "knm";
                case "kanashi":
                    return "xns";
                case "kanasi":
                    return "soq";
                case "kanauji":
                    return "bjj";
                case "kandas":
                    return "kqw";
                case "kandawo":
                    return "gam";
                case "kande":
                    return "kbs";
                case "kanembu":
                    return "kbl";
                case "kang":
                    return "kyp";
                case "kanga":
                    return "kcp";
                case "kangean":
                    return "kkv";
                case "kanggape":
                    return "igm";
                case "kangjia":
                    return "kxs";
                case "kango":
                    return "kty";
                case "kangri":
                    return "xnr";
                case "kaniet":
                    return "ktk";
                case "kanikkaran":
                    return "kev";
                case "kaningdon-nindem":
                    return "kdp";
                case "kaningi":
                    return "kzo";
                case "kaningra":
                    return "knr";
                case "kaninuwa":
                    return "wat";
                case "kanite":
                    return "kmu";
                case "kanjari":
                    return "kft";
                case "kanju":
                    return "kbe";
                case "kankanaey":
                    return "kne";
                case "kannada":
                    return "kan";
                case "kannada kurumba":
                    return "kfi";
                case "kanoé":
                    return "kxo";
                case "kanowit-tanjong melanau":
                    return "kxn";
                case "kansa":
                    return "ksk";
                case "kantosi":
                    return "xkt";
                case "kanu":
                    return "khx";
                case "kanufi":
                    return "kni";
                case "kanuri":
                    return "kau";
                case "kanyok":
                    return "kny";
                case "kao":
                    return "kax";
                case "kaonde":
                    return "kqn";
                case "kapampangan":
                    return "pam";
                case "kapauri":
                    return "khp";
                case "kapin":
                    return "tbx";
                case "kapinawá":
                    return "xpn";
                case "kapingamarangi":
                    return "kpg";
                case "kapriman":
                    return "dju";
                case "kaptiau":
                    return "kbi";
                case "kapya":
                    return "klo";
                case "kara":
                    return "kah";
                case "karachay-balkar":
                    return "krc";
                case "karadjeri":
                    return "gbd";
                case "karaga mandaya":
                    return "mry";
                case "karagas":
                    return "kim";
                case "karahawyana":
                    return "xkh";
                case "karaim":
                    return "kdr";
                case "karajá":
                    return "kpj";
                case "kara-kalpak":
                    return "kaa";
                case "karakhanid":
                    return "xqa";
                case "karami":
                    return "xar";
                case "karamojong":
                    return "kdj";
                case "karang":
                    return "kzr";
                case "karanga":
                    return "kth";
                case "karankawa":
                    return "zkk";
                case "karao":
                    return "kyj";
                case "karas":
                    return "kgv";
                case "karata":
                    return "kpt";
                case "karawa":
                    return "xrw";
                case "karbi":
                    return "mjw";
                case "kare":
                    return "kbn";
                case "karekare":
                    return "kai";
                case "karelian":
                    return "krl";
                case "karey":
                    return "kyd";
                case "kari":
                    return "kbj";
                case "karingani":
                    return "kgn";
                case "karipuna":
                    return "kuq";
                case "karipúna":
                    return "kgm";
                case "karipúna creole french":
                    return "kmv";
                case "karirí-xocó":
                    return "kzw";
                case "karitiâna":
                    return "ktn";
                case "kariya":
                    return "kil";
                case "kariyarra":
                    return "vka";
                case "karkar-yuri":
                    return "yuj";
                case "karkin":
                    return "krb";
                case "karko":
                    return "kko";
                case "karnai":
                    return "bbv";
                case "karo":
                    return "arr";
                case "karok":
                    return "kyh";
                case "karolanos":
                    return "kyn";
                case "karon":
                    return "krx";
                case "karon dori":
                    return "kgw";
                case "karore":
                    return "xkx";
                case "kasanga":
                    return "ccj";
                case "kasem":
                    return "xsm";
                case "kashaya":
                    return "kju";
                case "kashmiri":
                    return "kas";
                case "kashubian":
                    return "csb";
                case "kasiguranin":
                    return "ksn";
                case "kaska":
                    return "kkz";
                case "kaskean":
                    return "zsk";
                case "kasseng":
                    return "kgc";
                case "kasua":
                    return "khs";
                case "kataang":
                    return "kgd";
                case "katabaga":
                    return "ktq";
                case "katawixi":
                    return "xat";
                case "katbol":
                    return "tmb";
                case "katcha-kadugli-miri":
                    return "xtc";
                case "kâte":
                    return "kmg";
                case "kathoriya tharu":
                    return "tkt";
                case "kathu":
                    return "ykt";
                case "kati":
                    return "bsh";
                case "katkari":
                    return "kfu";
                case "katla":
                    return "kcr";
                case "kato":
                    return "ktw";
                case "katso":
                    return "kaf";
                case "katua":
                    return "kta";
                case "katukína":
                    return "kav";
                case "kaulong":
                    return "pss";
                case "kaur":
                    return "vkk";
                case "kaure":
                    return "bpp";
                case "kaurna":
                    return "zku";
                case "kauwera":
                    return "xau";
                case "kavalan":
                    return "ckv";
                case "kavet":
                    return "krv";
                case "kawacha":
                    return "kcb";
                case "kawaiisu":
                    return "xaw";
                case "kawe":
                    return "kgb";
                case "kawi":
                    return "kaw";
                case "kaxararí":
                    return "ktx";
                case "kaxuiâna":
                    return "kbb";
                case "kayabí":
                    return "kyz";
                case "kayagar":
                    return "kyt";
                case "kayan":
                    return "pdu";
                case "kayan mahakam":
                    return "xay";
                case "kayan river kayan":
                    return "xkn";
                case "kayapa kallahan":
                    return "kak";
                case "kayapó":
                    return "txu";
                case "kayardild":
                    return "gyd";
                case "kayeli":
                    return "kzl";
                case "kayong":
                    return "kxy";
                case "kayort":
                    return "kyv";
                case "kaytetye":
                    return "gbb";
                case "kayupulau":
                    return "kzu";
                case "kazakh":
                    return "kaz";
                case "kazukuru":
                    return "kzk";
                case "keapara":
                    return "khz";
                case "kedah malay":
                    return "meo";
                case "kedang":
                    return "ksx";
                case "keder":
                    return "kdy";
                case "kehu":
                    return "khh";
                case "kei":
                    return "kei";
                case "keiga":
                    return "kec";
                case "kein":
                    return "bmh";
                case "keiyo":
                    return "eyo";
                case "kekchí":
                    return "kek";
                case "kela":
                    return "kel";
                case "kelabit":
                    return "kzi";
                case "kele":
                    return "khy";
                case "kélé":
                    return "keb";
                case "keley-i kallahan":
                    return "ify";
                case "keliko":
                    return "kbo";
                case "kelo":
                    return "xel";
                case "kelon":
                    return "kyo";
                case "kemak":
                    return "kem";
                case "kembayan":
                    return "xem";
                case "kemberano":
                    return "bzp";
                case "kembra":
                    return "xkw";
                case "kemezung":
                    return "dmo";
                case "kemi sami":
                    return "sjk";
                case "kemiehua":
                    return "kfj";
                case "kemtuik":
                    return "kmt";
                case "kenati":
                    return "gat";
                case "kendayan":
                    return "knx";
                case "kendeje":
                    return "klf";
                case "kendem":
                    return "kvm";
                case "kenga":
                    return "kyq";
                case "keningau murut":
                    return "kxi";
                case "keninjal":
                    return "knl";
                case "kensiu":
                    return "kns";
                case "kenswei nsei":
                    return "ndb";
                case "kenuzi-dongola":
                    return "kzh";
                case "kenyang":
                    return "ken";
                case "kenyi":
                    return "lke";
                case "ke'o":
                    return "xxk";
                case "keoru-ahia":
                    return "xeu";
                case "kepkiriwát":
                    return "kpn";
                case "kepo'":
                    return "kuk";
                case "kera":
                    return "ker";
                case "kerak":
                    return "hhr";
                case "kereho":
                    return "xke";
                case "kerek":
                    return "krk";
                case "kerewe":
                    return "ked";
                case "kerewo":
                    return "kxz";
                case "kerinci":
                    return "kvr";
                case "kesawai":
                    return "xes";
                case "ket":
                    return "ket";
                case "ketangalan":
                    return "kae";
                case "kete":
                    return "kcv";
                case "ketengban":
                    return "xte";
                case "ketum":
                    return "ktt";
                case "keyagana":
                    return "kyg";
                case "kgalagadi":
                    return "xkv";
                case "khakas":
                    return "kjh";
                case "khalaj":
                    return "kjf";
                case "khaling":
                    return "klr";
                case "khamba":
                    return "kbg";
                case "khams tibetan":
                    return "khg";
                case "khamti":
                    return "kht";
                case "khamyang":
                    return "ksu";
                case "khana":
                    return "ogo";
                case "khandesi":
                    return "khn";
                case "kháng":
                    return "kjm";
                case "khanty":
                    return "kca";
                case "khao":
                    return "xao";
                case "kharam naga":
                    return "kfw";
                case "kharia":
                    return "khr";
                case "kharia thar":
                    return "ksy";
                case "khasi":
                    return "kha";
                case "khayo":
                    return "lko";
                case "khazar":
                    return "zkz";
                case "khe":
                    return "kqg";
                case "khehek":
                    return "tlx";
                case "khengkha":
                    return "xkf";
                case "khetrani":
                    return "xhe";
                case "khezha naga":
                    return "nkh";
                case "khiamniungan naga":
                    return "kix";
                case "khinalugh":
                    return "kjj";
                case "khirwar":
                    return "kwx";
                case "khisa":
                    return "kqm";
                case "khlor":
                    return "llo";
                case "khlula":
                    return "ykl";
                case "khmu":
                    return "kjg";
                case "khoibu naga":
                    return "nkb";
                case "kho'ini":
                    return "xkc";
                case "kholok":
                    return "ktc";
                case "khonso":
                    return "kxc";
                case "khorasani turkish":
                    return "kmz";
                case "khorezmian":
                    return "zkh";
                case "khotanese":
                    return "kho";
                case "khowar":
                    return "khw";
                case "khua":
                    return "xhv";
                case "khuen":
                    return "khf";
                case "khumi awa chin":
                    return "cka";
                case "khumi chin":
                    return "cnk";
                case "khün":
                    return "kkh";
                case "khunsari":
                    return "kfm";
                case "khvarshi":
                    return "khv";
                case "kibet":
                    return "kie";
                case "kibiri":
                    return "prm";
                case "kickapoo":
                    return "kic";
                case "kikai":
                    return "kzg";
                case "kildin sami":
                    return "sjd";
                case "kilivila":
                    return "kij";
                case "kiliwa":
                    return "klb";
                case "kilmeri":
                    return "kih";
                case "kim":
                    return "kia";
                case "kim mun":
                    return "mji";
                case "kimaama":
                    return "kig";
                case "kimaragang":
                    return "kqr";
                case "kimbu":
                    return "kiv";
                case "kimbundu":
                    return "kmb";
                case "kimki":
                    return "sbt";
                case "kimré":
                    return "kqp";
                case "kinalakna":
                    return "kco";
                case "kinaray-a":
                    return "krj";
                case "kinga":
                    return "zga";
                case "kinnauri":
                    return "kfk";
                case "kintaq":
                    return "knq";
                case "kinuku":
                    return "kkd";
                case "kinyarwanda":
                    return "kin";
                case "kioko":
                    return "ues";
                case "kiong":
                    return "kkm";
                case "kiorr":
                    return "xko";
                case "kiowa":
                    return "kio";
                case "kiowa apache":
                    return "apk";
                case "kipfokomo":
                    return "pkb";
                case "kipsigis":
                    return "sgc";
                case "kiput":
                    return "kyi";
                case "kir-balar":
                    return "kkr";
                case "kire":
                    return "geb";
                case "kirghiz":
                    return "kir";
                case "kirike":
                    return "okr";
                case "kirikiri":
                    return "kiy";
                case "kirmanjki":
                    return "kiu";
                case "kis":
                    return "kis";
                case "kisa":
                    return "lks";
                case "kisankasa":
                    return "kqh";
                case "kisar":
                    return "kje";
                case "kisi":
                    return "kiz";
                case "kistane":
                    return "gru";
                case "kiswahili":
                    return "swh";
                case "kita maninkakan":
                    return "mwk";
                case "kitan":
                    return "zkt";
                case "kitharaka":
                    return "thk";
                case "kitja":
                    return "gia";
                case "kitsai":
                    return "kii";
                case "kituba":
                    return "ktu";
                case "klamath-modoc":
                    return "kla";
                case "klao":
                    return "klu";
                case "klias river kadazan":
                    return "kqt";
                case "klingon":
                    return "tlh";
                case "knaanic":
                    return "czk";
                case "ko":
                    return "fuj";
                case "koalib":
                    return "kib";
                case "koasati":
                    return "cku";
                case "koba":
                    return "kpd";
                case "kobiana":
                    return "kcj";
                case "kobol":
                    return "kgu";
                case "kobon":
                    return "kpw";
                case "koch":
                    return "kdq";
                case "kochila tharu":
                    return "thq";
                case "koda":
                    return "cdz";
                case "kodaku":
                    return "ksz";
                case "kodava":
                    return "kfa";
                case "kodeoha":
                    return "vko";
                case "kodi":
                    return "kod";
                case "kodia":
                    return "kwp";
                case "koenoem":
                    return "kcs";
                case "kofa":
                    return "kso";
                case "kofei":
                    return "kpi";
                case "kofyar":
                    return "kwl";
                case "koguryo":
                    return "zkg";
                case "kohin":
                    return "kkx";
                case "kohistani shina":
                    return "plk";
                case "koho":
                    return "kpm";
                case "kohumono":
                    return "bcs";
                case "koi":
                    return "kkt";
                case "koibal":
                    return "zkb";
                case "koireng":
                    return "nkd";
                case "koitabu":
                    return "kqi";
                case "koiwat":
                    return "kxt";
                case "kok borok":
                    return "trp";
                case "kokata":
                    return "ktd";
                case "koke":
                    return "kou";
                case "kokoda":
                    return "xod";
                case "kokola":
                    return "kzn";
                case "kokota":
                    return "kkk";
                case "kol":
                    return "kol";
                case "kola":
                    return "kvv";
                case "kolbila":
                    return "klc";
                case "kolibugan subanon":
                    return "skn";
                case "kolom":
                    return "klm";
                case "kölsch":
                    return "ksh";
                case "kolum so dogon":
                    return "dkl";
                case "koluwawa":
                    return "klx";
                case "kom":
                    return "kmm";
                case "koma":
                    return "kmy";
                case "komba":
                    return "kpf";
                case "kombai":
                    return "tyn";
                case "kombio":
                    return "xbi";
                case "komering":
                    return "kge";
                case "komi":
                    return "kom";
                case "kominimung":
                    return "xoi";
                case "komi-permyak":
                    return "koi";
                case "komi-zyrian":
                    return "kpv";
                case "komo":
                    return "kmw";
                case "komodo":
                    return "kvh";
                case "kompane":
                    return "kvp";
                case "komyandaret":
                    return "kzv";
                case "kon keu":
                    return "kkn";
                case "konabéré/northern bobo madaré":
                    return "bbo";
                case "konai":
                    return "kxw";
                case "konda":
                    return "knd";
                case "konda-dora":
                    return "kfc";
                case "koneraw":
                    return "kdw";
                case "kongo":
                    return "kon";
                case "konkani":
                    return "knn";
                case "konkomba":
                    return "xon";
                case "konni":
                    return "kma";
                case "kono":
                    return "klk";
                case "konomala":
                    return "koa";
                case "konongo":
                    return "kcz";
                case "konyak naga":
                    return "nbe";
                case "konyanka maninka":
                    return "mku";
                case "konzo":
                    return "koo";
                case "koongo":
                    return "kng";
                case "koonzime":
                    return "ozm";
                case "koorete":
                    return "kqy";
                case "kopar":
                    return "xop";
                case "kopkaka":
                    return "opk";
                case "korafe-yegha":
                    return "kpr";
                case "korak":
                    return "koz";
                case "korana":
                    return "kqz";
                case "korandje":
                    return "kcy";
                case "korean":
                    return "kor";
                case "koreguaje":
                    return "coe";
                case "koresh-e rostam":
                    return "okh";
                case "korku":
                    return "kfq";
                case "korlai creole portuguese":
                    return "vkp";
                case "koro":
                    return "kfo";
                case "koromfé":
                    return "kfz";
                case "koromira":
                    return "kqj";
                case "koronadal blaan":
                    return "bpr";
                case "koroni":
                    return "xkq";
                case "korop":
                    return "krp";
                case "koroshi":
                    return "ktl";
                case "korowai":
                    return "khe";
                case "korra koraga":
                    return "kfd";
                case "korubo":
                    return "xor";
                case "korupun-sela":
                    return "kpq";
                case "korwa":
                    return "kfp";
                case "koryak":
                    return "kpy";
                case "kosadle":
                    return "kiq";
                case "kosarek yale":
                    return "kkl";
                case "kosena":
                    return "kze";
                case "koshin":
                    return "kid";
                case "kosraean":
                    return "kos";
                case "kota":
                    return "kfe";
                case "kota bangun kutai malay":
                    return "mqg";
                case "kota marudu talantang":
                    return "grm";
                case "kota marudu tinagas":
                    return "ktr";
                case "kotafon gbe":
                    return "kqk";
                case "kotava":
                    return "avk";
                case "koti":
                    return "eko";
                case "kott":
                    return "zko";
                case "kouya":
                    return "kyf";
                case "kovai":
                    return "kqb";
                case "kove":
                    return "kvc";
                case "kowaki":
                    return "xow";
                case "kowiai":
                    return "kwh";
                case "koy sanjaq surat":
                    return "kqd";
                case "koya":
                    return "kff";
                case "koyaga":
                    return "kga";
                case "koyo":
                    return "koh";
                case "koyra chiini songhay":
                    return "khq";
                case "koyraboro senni songhai":
                    return "ses";
                case "koyukon":
                    return "koy";
                case "kpagua":
                    return "kuw";
                case "kpala":
                    return "kpl";
                case "kpan":
                    return "kpk";
                case "kpasam":
                    return "pbn";
                case "kpati":
                    return "koc";
                case "kpatili":
                    return "kym";
                case "kpelle":
                    return "kpe";
                case "kpessi":
                    return "kef";
                case "kplang":
                    return "kph";
                case "krache":
                    return "kye";
                case "krahô":
                    return "xra";
                case "kraol":
                    return "rka";
                case "krenak":
                    return "kqq";
                case "krevinian":
                    return "zkv";
                case "kreye":
                    return "xre";
                case "krikati-timbira":
                    return "xri";
                case "krim":
                    return "krm";
                case "krio":
                    return "kri";
                case "kriol":
                    return "rop";
                case "krisa":
                    return "ksi";
                case "krobu":
                    return "kxb";
                case "krongo":
                    return "kgo";
                case "kru'ng 2":
                    return "krr";
                case "krymchak":
                    return "jct";
                case "kryts":
                    return "kry";
                case "kua":
                    return "tyu";
                case "kuan":
                    return "uan";
                case "kuanhua":
                    return "xnh";
                case "kuanua":
                    return "ksd";
                case "kuanyama":
                    return "kua";
                case "kube":
                    return "kgf";
                case "kubi":
                    return "kof";
                case "kubo":
                    return "jko";
                case "kubu":
                    return "kvb";
                case "kucong":
                    return "lkc";
                case "kudiya":
                    return "kfg";
                case "kudmali":
                    return "kyw";
                case "kudu-camo":
                    return "kov";
                case "kugama":
                    return "kow";
                case "kugbo":
                    return "kes";
                case "kui":
                    return "kvd";
                case "kuijau":
                    return "dkr";
                case "kuikúro-kalapálo":
                    return "kui";
                case "kujarge":
                    return "vkj";
                case "kuk":
                    return "kfn";
                case "kukatja":
                    return "kux";
                case "kukele":
                    return "kez";
                case "kukna":
                    return "kex";
                case "kuku-mangk":
                    return "xmq";
                case "kuku-mu'inh":
                    return "xmp";
                case "kuku-muminh":
                    return "xmh";
                case "kuku-ugbanh":
                    return "ugb";
                case "kuku-uwanh":
                    return "uwa";
                case "kuku-yalanji":
                    return "gvn";
                case "kula":
                    return "tpg";
                case "kulere":
                    return "kul";
                case "kulfa":
                    return "kxj";
                case "kulina pano":
                    return "xpk";
                case "kulisusu":
                    return "vkl";
                case "kullu pahari":
                    return "kfx";
                case "kulon-pazeh":
                    return "uun";
                case "kulung":
                    return "kle";
                case "kumak":
                    return "nee";
                case "kumalu":
                    return "ksl";
                case "kumam":
                    return "kdi";
                case "kuman":
                    return "kue";
                case "kumaoni":
                    return "kfy";
                case "kumarbhag paharia":
                    return "kmj";
                case "kumba":
                    return "ksm";
                case "kumbainggar":
                    return "kgs";
                case "kumbaran":
                    return "wkb";
                case "kumbewaha":
                    return "xks";
                case "kumhali":
                    return "kra";
                case "kumiai":
                    return "dih";
                case "kumukio":
                    return "kuo";
                case "kumyk":
                    return "kum";
                case "kumzari":
                    return "zum";
                case "kunama":
                    return "kun";
                case "kunbarlang":
                    return "wlg";
                case "kunda":
                    return "kdn";
                case "kunduvadi":
                    return "wku";
                case "kung":
                    return "kfl";
                case "kungarakany":
                    return "ggk";
                case "kung-ekoka":
                    return "knw";
                case "kunggara":
                    return "kvs";
                case "kunggari":
                    return "kgl";
                case "kuni":
                    return "kse";
                case "kuni-boazi":
                    return "kvg";
                case "kunigami":
                    return "xug";
                case "kunimaipa":
                    return "kup";
                case "kunja":
                    return "pep";
                case "kunjen":
                    return "kjn";
                case "kunyi":
                    return "njx";
                case "kunza":
                    return "kuz";
                case "kuo":
                    return "xuo";
                case "kuot":
                    return "kto";
                case "kupa":
                    return "kug";
                case "kupang malay":
                    return "mkn";
                case "kupia":
                    return "key";
                case "kupsabiny":
                    return "kpz";
                case "kur":
                    return "kuv";
                case "kura ede nago":
                    return "nqk";
                case "kurama":
                    return "krh";
                case "kuranko":
                    return "knk";
                case "kurdish":
                    return "kur";
                case "kuri":
                    return "nbn";
                case "kuria":
                    return "kuj";
                case "kurichiya":
                    return "kfh";
                case "kurmukar":
                    return "kfv";
                case "kurrama":
                    return "vku";
                case "kurti":
                    return "ktm";
                case "kurtokha":
                    return "xkz";
                case "kuruáya":
                    return "kyr";
                case "kurudu":
                    return "kjr";
                case "kurukh":
                    return "kru";
                case "kusaal":
                    return "kus";
                case "kusaghe":
                    return "ksg";
                case "kushi":
                    return "kuh";
                case "kusu":
                    return "ksv";
                case "kusunda":
                    return "kgg";
                case "kutang ghale":
                    return "ght";
                case "kutenai":
                    return "kut";
                case "kutep":
                    return "kub";
                case "kuthant":
                    return "xut";
                case "kutto":
                    return "kpa";
                case "kutu":
                    return "kdc";
                case "kuturmi":
                    return "khj";
                case "kuuku-ya'u":
                    return "kuy";
                case "kuvi":
                    return "kxv";
                case "kuwaa":
                    return "blh";
                case "kuwaataay":
                    return "cwt";
                case "kuy":
                    return "kdt";
                case "kven finnish":
                    return "fkv";
                case "kwa":
                    return "kwb";
                case "kwa'":
                    return "bko";
                case "kwaami":
                    return "ksq";
                case "kwadi":
                    return "kwz";
                case "kw'adza":
                    return "wka";
                case "kwaio":
                    return "kwd";
                case "kwaja":
                    return "kdz";
                case "kwak":
                    return "kwq";
                case "kwakiutl":
                    return "kwk";
                case "kwakum":
                    return "kwu";
                case "kwalhioqua-tlatskanai":
                    return "qwt";
                case "kwama":
                    return "kmq";
                case "kwambi":
                    return "kwm";
                case "kwamera":
                    return "tnk";
                case "kwami":
                    return "ktf";
                case "kwamtim one":
                    return "okk";
                case "kwang":
                    return "kvi";
                case "kwanga":
                    return "kwj";
                case "kwangali":
                    return "kwn";
                case "kwanja":
                    return "knp";
                case "kwara'ae":
                    return "kwf";
                case "kwasio":
                    return "nmg";
                case "kwato":
                    return "kop";
                case "kwaya":
                    return "kya";
                case "kwaza":
                    return "xwa";
                case "kwegu":
                    return "xwg";
                case "kwer":
                    return "kwr";
                case "kwerba":
                    return "kwe";
                case "kwerba mamberamo":
                    return "xwr";
                case "kwere":
                    return "cwe";
                case "kwerisa":
                    return "kkb";
                case "kwese":
                    return "kws";
                case "kwesten":
                    return "kwt";
                case "kwini":
                    return "gww";
                case "kwinsu":
                    return "kuc";
                case "kwinti":
                    return "kww";
                case "kwoma":
                    return "kmo";
                case "kwomtari":
                    return "kwo";
                case "kx'au":
                    return "aue";
                case "kxoe":
                    return "xuu";
                case "kyak":
                    return "bka";
                case "kyaka":
                    return "kyc";
                case "kyenele":
                    return "kql";
                case "kyenga":
                    return "tye";
                case "kyerung":
                    return "kgy";
                case "láá láá bwamu":
                    return "bwj";
                case "láadan":
                    return "ldn";
                case "laal":
                    return "gdm";
                case "laalaa":
                    return "cae";
                case "laari":
                    return "ldi";
                case "laba":
                    return "lau";
                case "label":
                    return "lbb";
                case "la'bi":
                    return "lbi";
                case "labir":
                    return "jku";
                case "labo":
                    return "mwi";
                case "labo phowa":
                    return "ypb";
                case "labu":
                    return "lbu";
                case "labuk-kinabatangan kadazan":
                    return "dtb";
                case "lacandon":
                    return "lac";
                case "lachi":
                    return "lbt";
                case "lachiguiri zapotec":
                    return "zpa";
                case "lachixío zapotec":
                    return "zpl";
                case "ladakhi":
                    return "lbj";
                case "ladin":
                    return "lld";
                case "ladino":
                    return "lad";
                case "laeko-libuat":
                    return "lkl";
                case "lafofa":
                    return "laf";
                case "laghu":
                    return "lgb";
                case "laghuu":
                    return "lgh";
                case "lagwan":
                    return "kot";
                case "laha":
                    return "lha";
                case "lahanan":
                    return "lhn";
                case "lahnda":
                    return "lah";
                case "lahta karen":
                    return "kvt";
                case "lahu":
                    return "lhu";
                case "lahu shi":
                    return "lhi";
                case "lahul lohar":
                    return "lhl";
                case "laimbue":
                    return "lmx";
                case "laiyolo":
                    return "lji";
                case "lak":
                    return "lbe";
                case "laka":
                    return "lak";
                case "lakalei":
                    return "lka";
                case "lake miwok":
                    return "lmw";
                case "lakha":
                    return "lkh";
                case "laki":
                    return "lki";
                case "lakkia":
                    return "lbc";
                case "lakona":
                    return "lkn";
                case "lakondê":
                    return "lkd";
                case "lakota":
                    return "lkt";
                case "lakota dida":
                    return "dic";
                case "lala":
                    return "nrz";
                case "lala-bisa":
                    return "leb";
                case "lalana chinantec":
                    return "cnl";
                case "lala-roba":
                    return "lla";
                case "lalia":
                    return "lal";
                case "lama":
                    return "las";
                case "lamaholot":
                    return "slp";
                case "lamalera":
                    return "lmr";
                case "lamam":
                    return "lmm";
                case "lamang":
                    return "hia";
                case "lamatuka":
                    return "lmq";
                case "lamba":
                    return "lam";
                case "lambadi":
                    return "lmn";
                case "lambayeque quechua":
                    return "quf";
                case "lambichhong":
                    return "lmh";
                case "lamboya":
                    return "lmy";
                case "lambya":
                    return "lai";
                case "lame":
                    return "bma";
                case "lamenu":
                    return "lmu";
                case "lamet":
                    return "lbn";
                case "lamja-dengsa-tola":
                    return "ldh";
                case "lamkang":
                    return "lmk";
                case "lamma":
                    return "lev";
                case "lamnso'":
                    return "lns";
                case "lamogai":
                    return "lmg";
                case "lampung api":
                    return "ljp";
                case "lampung nyo":
                    return "abl";
                case "lamu":
                    return "llh";
                case "lamu-lamu":
                    return "lby";
                case "lanas lobu":
                    return "ruu";
                case "landoma":
                    return "ldm";
                case "langam":
                    return "lnm";
                case "langbashe":
                    return "lna";
                case "lang'e":
                    return "yne";
                case "langi":
                    return "lag";
                case "langnian buyang":
                    return "yln";
                case "lango":
                    return "laj";
                case "langobardic":
                    return "lng";
                case "lanoh":
                    return "lnh";
                case "lantanai":
                    return "lni";
                case "lao":
                    return "lao";
                case "laomian":
                    return "lwm";
                case "laopang":
                    return "lbg";
                case "lapaguía-guivini zapotec":
                    return "ztl";
                case "lapuyan subanun":
                    return "laa";
                case "laragia":
                    return "lrg";
                case "larantuka malay":
                    return "lrt";
                case "lardil":
                    return "lbz";
                case "larevat":
                    return "lrv";
                case "lari":
                    return "lrl";
                case "larike-wakasihu":
                    return "alo";
                case "laro":
                    return "lro";
                case "larteh":
                    return "lar";
                case "laru":
                    return "lan";
                case "lasalimu":
                    return "llm";
                case "lasgerdi":
                    return "lsa";
                case "lashi":
                    return "lsi";
                case "lasi":
                    return "lss";
                case "late middle chinese":
                    return "ltc";
                case "latin":
                    return "lat";
                case "latu":
                    return "ltu";
                case "latundê":
                    return "ltn";
                case "latvian":
                    return "lav";
                case "lau":
                    return "llu";
                case "laua":
                    return "luf";
                case "lauan":
                    return "llx";
                case "lauje":
                    return "law";
                case "laura":
                    return "lur";
                case "laurentian":
                    return "lre";
                case "lavatbura-lamusong":
                    return "lbv";
                case "lave":
                    return "brb";
                case "laven":
                    return "lbo";
                case "lavukaleve":
                    return "lvk";
                case "lawangan":
                    return "lbx";
                case "lawunuia":
                    return "tgi";
                case "layakha":
                    return "lya";
                case "laz":
                    return "lzz";
                case "lealao chinantec":
                    return "cle";
                case "leco":
                    return "lec";
                case "ledo kaili":
                    return "lew";
                case "leelau":
                    return "ldk";
                case "lefa":
                    return "lfa";
                case "lega-mwenga":
                    return "lgm";
                case "lega-shabunda":
                    return "lea";
                case "legbo":
                    return "agb";
                case "legenyem":
                    return "lcc";
                case "lehali":
                    return "tql";
                case "lehalurup":
                    return "urr";
                case "leinong naga":
                    return "lzn";
                case "leipon":
                    return "lek";
                case "lelak":
                    return "llk";
                case "lele":
                    return "lel";
                case "lelemi":
                    return "lef";
                case "lelepa":
                    return "lpa";
                case "lembena":
                    return "leq";
                case "lemio":
                    return "lei";
                case "lemnian":
                    return "xle";
                case "lemolang":
                    return "ley";
                case "lemoro":
                    return "ldj";
                case "lenakel":
                    return "tnl";
                case "lenca":
                    return "len";
                case "lendu":
                    return "led";
                case "lengilu":
                    return "lgi";
                case "lengo":
                    return "lgr";
                case "lengola":
                    return "lej";
                case "lengua":
                    return "leg";
                case "leningitij":
                    return "lnj";
                case "lenje":
                    return "leh";
                case "lenkau":
                    return "ler";
                case "lenyima":
                    return "ldg";
                case "lepcha":
                    return "lep";
                case "lepki":
                    return "lpe";
                case "lepontic":
                    return "xlp";
                case "lere":
                    return "gnh";
                case "lese":
                    return "les";
                case "lesing-gelimi":
                    return "let";
                case "letemboi":
                    return "nms";
                case "leti":
                    return "lti";
                case "letzeburgesch":
                    return "ltz";
                case "levuka":
                    return "lvu";
                case "lewo":
                    return "lww";
                case "lewo eleng":
                    return "lwe";
                case "lewotobi":
                    return "lwt";
                case "leyigha":
                    return "ayi";
                case "lezghian":
                    return "lez";
                case "lhaovo":
                    return "mhx";
                case "lhokpu":
                    return "lhp";
                case "lhomi":
                    return "lhm";
                case "liabuku":
                    return "lix";
                case "liana-seti":
                    return "ste";
                case "liangmai naga":
                    return "njn";
                case "lianshan zhuang":
                    return "zln";
                case "liberia kpelle":
                    return "xpe";
                case "liberian english":
                    return "lir";
                case "libido":
                    return "liq";
                case "libinza":
                    return "liz";
                case "liburnian":
                    return "xli";
                case "libyan arabic":
                    return "ayl";
                case "ligbi":
                    return "lig";
                case "ligenza":
                    return "lgz";
                case "ligurian":
                    return "lij";
                case "lihir":
                    return "lih";
                case "lijili":
                    return "mgi";
                case "lika":
                    return "lik";
                case "liki":
                    return "lio";
                case "likila":
                    return "lie";
                case "likuba":
                    return "kxx";
                case "likum":
                    return "lib";
                case "likwala":
                    return "kwc";
                case "lilau":
                    return "lll";
                case "lillooet":
                    return "lil";
                case "limassa":
                    return "bme";
                case "limbu":
                    return "lif";
                case "limbum":
                    return "lmp";
                case "limburgan":
                    return "lim";
                case "limi":
                    return "ylm";
                case "limilngan":
                    return "lmc";
                case "limos kalinga":
                    return "kmk";
                case "lindu":
                    return "klw";
                case "linear a":
                    return "lab";
                case "lingala":
                    return "lin";
                case "lingao":
                    return "onb";
                case "lingarak":
                    return "lgk";
                case "lingkhim":
                    return "lii";
                case "lingua franca":
                    return "pml";
                case "lingua franca nova":
                    return "lfn";
                case "li'o":
                    return "ljl";
                case "lipan apache":
                    return "apl";
                case "lipo":
                    return "lpo";
                case "lisabata-nuniali":
                    return "lcs";
                case "lisela":
                    return "lcl";
                case "lish":
                    return "lsh";
                case "lishán didán":
                    return "trg";
                case "lishana deni":
                    return "lsd";
                case "lishanid noshan":
                    return "aij";
                case "lisu":
                    return "lis";
                case "lithuanian":
                    return "lit";
                case "litzlitz":
                    return "lzl";
                case "liujiang zhuang":
                    return "zlj";
                case "liuqian zhuang":
                    return "zlq";
                case "liv":
                    return "liv";
                case "livvi":
                    return "olo";
                case "loarki":
                    return "lrk";
                case "lobala":
                    return "loq";
                case "lobi":
                    return "lob";
                case "lodhi":
                    return "lbm";
                case "logba":
                    return "lgq";
                case "logo":
                    return "log";
                case "logol":
                    return "lof";
                case "logooli":
                    return "rag";
                case "logorik":
                    return "liu";
                case "logudorese sardinian":
                    return "src";
                case "loja highland quichua":
                    return "qvj";
                case "lojban":
                    return "jbo";
                case "lokaa":
                    return "yaz";
                case "loko":
                    return "lok";
                case "lokoya":
                    return "lky";
                case "lola":
                    return "lcd";
                case "lolak":
                    return "llq";
                case "lole":
                    return "llg";
                case "lolo":
                    return "llb";
                case "loloda":
                    return "loa";
                case "lolopo":
                    return "ycl";
                case "loma":
                    return "lom";
                case "lomaiviti":
                    return "lmv";
                case "lomavren":
                    return "rmi";
                case "lombard":
                    return "lmo";
                case "lombi":
                    return "lmi";
                case "lombo":
                    return "loo";
                case "lomwe":
                    return "ngl";
                case "loncong":
                    return "lce";
                case "long phuri naga":
                    return "lpn";
                case "long wat":
                    return "ttw";
                case "longgu":
                    return "lgu";
                case "longto":
                    return "wok";
                case "longuda":
                    return "lnu";
                case "loniu":
                    return "los";
                case "lonwolwol":
                    return "crc";
                case "lonzo":
                    return "lnz";
                case "loo":
                    return "ldo";
                case "lopa":
                    return "lop";
                case "lopi":
                    return "lov";
                case "lopit":
                    return "lpx";
                case "lorang":
                    return "lrn";
                case "lorediakarkar":
                    return "lnn";
                case "loreto-ucayali spanish":
                    return "spq";
                case "lote":
                    return "uvl";
                case "lotha naga":
                    return "njh";
                case "lotud":
                    return "dtr";
                case "lou":
                    return "loj";
                case "louisiana creole french":
                    return "lou";
                case "loun":
                    return "lox";
                case "loup a":
                    return "xlo";
                case "loup b":
                    return "xlb";
                case "low german":
                    return "nds";
                case "lowa":
                    return "loy";
                case "lower chehalis":
                    return "cea";
                case "lower grand valley dani":
                    return "dni";
                case "lower silesian":
                    return "sli";
                case "lower sorbian":
                    return "dsb";
                case "lower tanana":
                    return "taa";
                case "lower tanudan kalinga":
                    return "kml";
                case "lower ta'oih":
                    return "tto";
                case "lowland oaxaca chontal":
                    return "clo";
                case "lowland tarahumara":
                    return "tac";
                case "loxicha zapotec":
                    return "ztp";
                case "lozi":
                    return "loz";
                case "lü":
                    return "khb";
                case "lua'":
                    return "prb";
                case "luang":
                    return "lex";
                case "luba-katanga":
                    return "lub";
                case "luba-lulua":
                    return "lua";
                case "lubila":
                    return "kcc";
                case "lubu":
                    return "lcf";
                case "lubuagan kalinga":
                    return "knb";
                case "luchazi":
                    return "lch";
                case "lucumi":
                    return "luq";
                case "ludian":
                    return "lud";
                case "lufu":
                    return "ldq";
                case "lugbara":
                    return "lgg";
                case "luguru":
                    return "ruf";
                case "luhu":
                    return "lcq";
                case "lui":
                    return "lba";
                case "luimbi":
                    return "lum";
                case "luiseno":
                    return "lui";
                case "lukpa":
                    return "dop";
                case "lule sami":
                    return "smj";
                case "lumba-yakkha":
                    return "luu";
                case "lumbee":
                    return "lmz";
                case "lumbu":
                    return "lup";
                case "lumun":
                    return "lmd";
                case "lun bawang":
                    return "lnd";
                case "luna":
                    return "luj";
                case "lunanakha":
                    return "luk";
                case "lunda":
                    return "lun";
                case "lungga":
                    return "lga";
                case "luo":
                    return "luw";
                case "luopohe hmong":
                    return "hml";
                case "luri":
                    return "ldd";
                case "lusengo":
                    return "lse";
                case "lushai":
                    return "lus";
                case "lushootseed":
                    return "lut";
                case "lusi":
                    return "khl";
                case "lusitanian":
                    return "xls";
                case "lutachoni":
                    return "lts";
                case "lutos":
                    return "ndy";
                case "luvale":
                    return "lue";
                case "luwati":
                    return "luv";
                case "luwo":
                    return "lwo";
                case "luyana":
                    return "lyn";
                case "luyia":
                    return "luy";
                case "lwalu":
                    return "lwa";
                case "lycian":
                    return "xlc";
                case "lydian":
                    return "xld";
                case "lyélé":
                    return "lee";
                case "lyngngam":
                    return "lyg";
                case "ma":
                    return "mjn";
                case "maa":
                    return "cma";
                case "maaka":
                    return "mew";
                case "ma'anyan":
                    return "mhy";
                case "maasina fulfulde":
                    return "ffm";
                case "maay":
                    return "ymm";
                case "maba":
                    return "mde";
                case "mabaale":
                    return "mmz";
                case "mabaan":
                    return "mfz";
                case "mabaka valley kalinga":
                    return "kkg";
                case "mabire":
                    return "muj";
                case "maca":
                    return "mca";
                case "macaguaje":
                    return "mcl";
                case "macaguán":
                    return "mbn";
                case "macanese":
                    return "mzs";
                case "macedonian":
                    return "mkd";
                case "machame":
                    return "jmc";
                case "machiguenga":
                    return "mcb";
                case "machinere":
                    return "mpd";
                case "machinga":
                    return "mvw";
                case "maco":
                    return "wpc";
                case "macuna":
                    return "myy";
                case "macushi":
                    return "mbc";
                case "mada":
                    return "mda";
                case "madak":
                    return "mmx";
                case "maden":
                    return "xmx";
                case "madi":
                    return "grg";
                case "ma'di":
                    return "mhi";
                case "madngele":
                    return "zml";
                case "madukayang kalinga":
                    return "kmd";
                case "madurese":
                    return "mad";
                case "mae":
                    return "mme";
                case "maek":
                    return "hmk";
                case "maeng itneg":
                    return "itt";
                case "mafa":
                    return "maf";
                case "mafea":
                    return "mkv";
                case "magahat":
                    return "mtw";
                case "magahi":
                    return "mag";
                case "mag-anchi ayta":
                    return "sgb";
                case "magdalena peñasco mixtec":
                    return "xtm";
                case "mághdì":
                    return "gmd";
                case "mag-indi ayta":
                    return "blx";
                case "magoma":
                    return "gmx";
                case "magori":
                    return "zgr";
                case "maguindanao":
                    return "mdh";
                case "mahali":
                    return "mjx";
                case "māhārāṣṭri prākrit":
                    return "pmh";
                case "mahasu pahari":
                    return "bfz";
                case "mahei":
                    return "mja";
                case "mahican":
                    return "mjy";
                case "mahongwe":
                    return "mhb";
                case "mahou":
                    return "mxx";
                case "mai brat":
                    return "ayz";
                case "maia":
                    return "sks";
                case "maiadomu":
                    return "mzz";
                case "maiani":
                    return "tnh";
                case "maii":
                    return "mmm";
                case "mailu":
                    return "mgu";
                case "maindo":
                    return "cwb";
                case "mainfränkisch":
                    return "vmf";
                case "mainstream kenyah":
                    return "xkl";
                case "mairasi":
                    return "zrs";
                case "maisin":
                    return "mbq";
                case "maithili":
                    return "mai";
                case "maiwa":
                    return "mti";
                case "maiwala":
                    return "mum";
                case "majang":
                    return "mpe";
                case "majera":
                    return "xmj";
                case "majhi":
                    return "mjz";
                case "majhwar":
                    return "mmj";
                case "mak":
                    return "mkg";
                case "makaa":
                    return "mcp";
                case "makah":
                    return "myh";
                case "makasae":
                    return "mkz";
                case "makasar":
                    return "mak";
                case "makassar malay":
                    return "mfp";
                case "makayam":
                    return "aup";
                case "makhuwa":
                    return "vmw";
                case "makhuwa-marrevone":
                    return "xmc";
                case "makhuwa-meetto":
                    return "mgh";
                case "makhuwa-moniga":
                    return "mhm";
                case "makhuwa-saka":
                    return "xsq";
                case "makhuwa-shirima":
                    return "vmk";
                case "maklew":
                    return "mgf";
                case "makolkol":
                    return "zmh";
                case "makonde":
                    return "kde";
                case "maku'a":
                    return "lva";
                case "makuráp":
                    return "mpu";
                case "makuri naga":
                    return "jmn";
                case "makwe":
                    return "ymk";
                case "makyan naga":
                    return "umn";
                case "mal":
                    return "mlf";
                case "mal paharia":
                    return "mkb";
                case "mala":
                    return "ped";
                case "mala malasar":
                    return "ima";
                case "malaccan creole malay":
                    return "ccm";
                case "malaccan creole portuguese":
                    return "mcm";
                case "malagasy":
                    return "mlg";
                case "malakhel":
                    return "mld";
                case "malalamai":
                    return "mmt";
                case "malango":
                    return "mln";
                case "malankuravan":
                    return "mjo";
                case "malapandaram":
                    return "mjp";
                case "malaryan":
                    return "mjq";
                case "malas":
                    return "mkr";
                case "malasanga":
                    return "mqz";
                case "malasar":
                    return "ymr";
                case "malavedan":
                    return "mjr";
                case "malawi lomwe":
                    return "lon";
                case "malawi sena":
                    return "swk";
                case "malay":
                    return "zlm";
                case "malayalam":
                    return "mal";
                case "malayic dayak":
                    return "xdy";
                case "malaynon":
                    return "mlz";
                case "malayo":
                    return "mbp";
                case "malba birifor":
                    return "bfo";
                case "male":
                    return "mdc";
                case "malecite-passamaquoddy":
                    return "pqm";
                case "maléku jaíka":
                    return "gut";
                case "maleng":
                    return "pkt";
                case "maleu-kilenge":
                    return "mgl";
                case "malfaxal":
                    return "mlx";
                case "malgana":
                    return "vml";
                case "malgbe":
                    return "mxf";
                case "mali":
                    return "gcc";
                case "maligo":
                    return "mwj";
                case "malila":
                    return "mgq";
                case "malimba":
                    return "mzd";
                case "malimpung":
                    return "mli";
                case "malinaltepec tlapanec":
                    return "tcf";
                case "malinguat":
                    return "sic";
                case "malo":
                    return "mla";
                case "malol":
                    return "mbk";
                case "maltese":
                    return "mlt";
                case "malua bay":
                    return "mll";
                case "malvi":
                    return "mup";
                case "mama":
                    return "mma";
                case "mamaa":
                    return "mhf";
                case "mamaindé":
                    return "wmd";
                case "mamanwa":
                    return "mmn";
                case "mamara senoufo":
                    return "myk";
                case "mamasa":
                    return "mqj";
                case "mambae":
                    return "mgm";
                case "mambai":
                    return "mcs";
                case "mamboru":
                    return "mvd";
                case "mambwe-lungu":
                    return "mgr";
                case "mampruli":
                    return "maw";
                case "mamuju":
                    return "mqx";
                case "mamulique":
                    return "emm";
                case "mamusi":
                    return "kdf";
                case "mamvu":
                    return "mdi";
                case "man met":
                    return "mml";
                case "manado malay":
                    return "xmm";
                case "manam":
                    return "mva";
                case "manambu":
                    return "mle";
                case "manangba":
                    return "nmm";
                case "manangkari":
                    return "znk";
                case "manchu":
                    return "mnc";
                case "manda":
                    return "mgs";
                case "mandahuaca":
                    return "mht";
                case "mandaic":
                    return "mid";
                case "mandan":
                    return "mhq";
                case "mandandanyi":
                    return "zmk";
                case "mandar":
                    return "mdr";
                case "mandara":
                    return "tbf";
                case "mandari":
                    return "mqu";
                case "mandarin chinese":
                    return "cmn";
                case "mandeali":
                    return "mjl";
                case "mander":
                    return "mqr";
                case "mandingo":
                    return "man";
                case "mandinka":
                    return "mnk";
                case "mandjak":
                    return "mfv";
                case "mandobo atas":
                    return "aax";
                case "mandobo bawah":
                    return "bwp";
                case "manem":
                    return "jet";
                case "mang":
                    return "zng";
                case "manga kanuri":
                    return "kby";
                case "mangala":
                    return "mem";
                case "mangarayi":
                    return "mpc";
                case "mangareva":
                    return "mrv";
                case "mangas":
                    return "zns";
                case "mangayat":
                    return "myj";
                case "mangbetu":
                    return "mdj";
                case "mangbutu":
                    return "mdk";
                case "mangerr":
                    return "zme";
                case "mangga buang":
                    return "mmo";
                case "manggarai":
                    return "mqy";
                case "mango":
                    return "mge";
                case "mangole":
                    return "mqc";
                case "mangseng":
                    return "mbh";
                case "manichaean middle persian":
                    return "xmn";
                case "manigri-kambolé ede nago":
                    return "xkb";
                case "manikion":
                    return "mnx";
                case "manipa":
                    return "mqp";
                case "manipuri":
                    return "mni";
                case "mankanya":
                    return "knf";
                case "mann":
                    return "mev";
                case "manna-dora":
                    return "mju";
                case "mannan":
                    return "mjv";
                case "manombai":
                    return "woo";
                case "mansaka":
                    return "msk";
                case "mansi":
                    return "mns";
                case "mansoanka":
                    return "msw";
                case "manta":
                    return "myg";
                case "mantsi":
                    return "nty";
                case "manumanaw karen":
                    return "kxf";
                case "manusela":
                    return "wha";
                case "manx":
                    return "glv";
                case "manya":
                    return "mzj";
                case "manyawa":
                    return "mny";
                case "manyika":
                    return "mxc";
                case "manza":
                    return "mzv";
                case "mao naga":
                    return "nbi";
                case "maonan":
                    return "mmd";
                case "maori":
                    return "mri";
                case "mape":
                    return "mlh";
                case "mapena":
                    return "mnm";
                case "mapia":
                    return "mpy";
                case "mapidian":
                    return "mpw";
                case "mapos buang":
                    return "bzh";
                case "mapoyo":
                    return "mcg";
                case "mapuche":
                    return "arn";
                case "mapun":
                    return "sjm";
                case "maquiritari":
                    return "mch";
                case "mara":
                    return "mec";
                case "mara chin":
                    return "mrh";
                case "marachi":
                    return "lri";
                case "maraghei":
                    return "vmh";
                case "maragus":
                    return "mrs";
                case "maram naga":
                    return "nma";
                case "marama":
                    return "lrm";
                case "maramba":
                    return "myd";
                case "maranao":
                    return "mrw";
                case "maranunggu":
                    return "zmr";
                case "mararit":
                    return "mgb";
                case "marathi":
                    return "mar";
                case "marau":
                    return "mvr";
                case "marba":
                    return "mpg";
                case "marenje":
                    return "vmr";
                case "marfa":
                    return "mvu";
                case "margany":
                    return "zmc";
                case "marghi central":
                    return "mrt";
                case "marghi south":
                    return "mfm";
                case "margos-yarowilca-lauricocha quechua":
                    return "qvm";
                case "margu":
                    return "mhg";
                case "mari":
                    return "chm";
                case "maricopa":
                    return "mrc";
                case "maridan":
                    return "zmd";
                case "maridjabin":
                    return "zmj";
                case "marik":
                    return "dad";
                case "marimanindji":
                    return "zmm";
                case "marind":
                    return "mrz";
                case "maring":
                    return "mbw";
                case "maring naga":
                    return "nng";
                case "maringarr":
                    return "zmt";
                case "marino":
                    return "mrb";
                case "mariri":
                    return "mqi";
                case "marithiel":
                    return "mfr";
                case "maritsauá":
                    return "msp";
                case "mariyedi":
                    return "zmy";
                case "marka":
                    return "rkm";
                case "markweeta":
                    return "enb";
                case "marma":
                    return "rmz";
                case "marovo":
                    return "mvo";
                case "marriammu":
                    return "xru";
                case "marrucinian":
                    return "umc";
                case "marshallese":
                    return "mah";
                case "marsian":
                    return "ims";
                case "marti ke":
                    return "zmg";
                case "martu wangka":
                    return "mpj";
                case "martuyhunira":
                    return "vma";
                case "marúbo":
                    return "mzr";
                case "marwari":
                    return "mwr";
                case "masaaba":
                    return "myx";
                case "masadiit itneg":
                    return "tis";
                case "masai":
                    return "mas";
                case "masalit":
                    return "mls";
                case "masana":
                    return "mcn";
                case "masbate sorsogon":
                    return "bks";
                case "masbatenyo":
                    return "msb";
                case "mashco piro":
                    return "cuj";
                case "mashi":
                    return "jms";
                case "masikoro malagasy":
                    return "msh";
                case "masimasi":
                    return "ism";
                case "masiwang":
                    return "bnf";
                case "maskelynes":
                    return "klv";
                case "maskoy pidgin":
                    return "mhh";
                case "maslam":
                    return "msv";
                case "masmaje":
                    return "mes";
                case "massalat":
                    return "mdg";
                case "massep":
                    return "mvs";
                case "matagalpa":
                    return "mtn";
                case "matal":
                    return "mfh";
                case "matbat":
                    return "xmt";
                case "matengo":
                    return "mgv";
                case "matepi":
                    return "mqe";
                case "matigsalug manobo":
                    return "mbt";
                case "matipuhy":
                    return "mzo";
                case "matís":
                    return "mpq";
                case "mato":
                    return "met";
                case "mato grosso arára":
                    return "axg";
                case "mator":
                    return "mtm";
                case "mator-taygi-karagas":
                    return "ymt";
                case "matsés":
                    return "mcf";
                case "mattole":
                    return "mvb";
                case "matukar":
                    return "mjk";
                case "matumbi":
                    return "mgw";
                case "matya samo":
                    return "stj";
                case "maung":
                    return "mph";
                case "mauwake":
                    return "mhl";
                case "mawa":
                    return "mcw";
                case "mawak":
                    return "mjj";
                case "mawan":
                    return "mcz";
                case "mawayana":
                    return "mzx";
                case "mawchi":
                    return "mke";
                case "mawes":
                    return "mgk";
                case "maxakalí":
                    return "mbl";
                case "maxi gbe":
                    return "mxl";
                case "ma'ya":
                    return "slz";
                case "maya samo":
                    return "sym";
                case "mayaguduna":
                    return "xmy";
                case "mayeka":
                    return "myc";
                case "maykulan":
                    return "mnt";
                case "mayo":
                    return "mfy";
                case "mayogo":
                    return "mdm";
                case "mayoyao ifugao":
                    return "ifu";
                case "mazagway":
                    return "dkx";
                case "mazaltepec zapotec":
                    return "zpy";
                case "mazanderani":
                    return "mzn";
                case "mazatlán mazatec":
                    return "vmz";
                case "mazatlán mixe":
                    return "mzl";
                case "mba":
                    return "mfc";
                case "mbabaram":
                    return "vmb";
                case "mbala":
                    return "mdp";
                case "mbalanhu":
                    return "lnb";
                case "mbandja":
                    return "zmz";
                case "mbangala":
                    return "mxg";
                case "mbangi":
                    return "mgn";
                case "mbangwe":
                    return "zmn";
                case "mbara":
                    return "mpk";
                case "mbariman-gudhinma":
                    return "zmv";
                case "mbati":
                    return "mdn";
                case "mbato":
                    return "gwa";
                case "mbay":
                    return "myb";
                case "mbe":
                    return "mfo";
                case "mbe'":
                    return "mtk";
                case "mbedam":
                    return "xmd";
                case "mbelime":
                    return "mql";
                case "mbere":
                    return "mdt";
                case "mbesa":
                    return "zms";
                case "mbo":
                    return "mbo";
                case "mboi":
                    return "moi";
                case "mboko":
                    return "mdu";
                case "mbole":
                    return "mdq";
                case "mbonga":
                    return "xmb";
                case "mbongno":
                    return "bgu";
                case "mbosi":
                    return "mdw";
                case "mbowe":
                    return "mxo";
                case "mbre":
                    return "mka";
                case "mbu'":
                    return "muc";
                case "mbugu":
                    return "mhd";
                case "mbugwe":
                    return "mgz";
                case "mbuko":
                    return "mqb";
                case "mbukushu":
                    return "mhw";
                case "mbula":
                    return "mna";
                case "mbula-bwazza":
                    return "mbu";
                case "mbule":
                    return "mlb";
                case "mbulungish":
                    return "mbv";
                case "mbum":
                    return "mdd";
                case "mbunda":
                    return "mck";
                case "mbunga":
                    return "mgy";
                case "mburku":
                    return "bbt";
                case "mbwela":
                    return "mfu";
                case "mbyá guaraní":
                    return "gun";
                case "mea":
                    return "meg";
                case "medebur":
                    return "mjm";
                case "media lengua":
                    return "mue";
                case "mediak":
                    return "mwx";
                case "median":
                    return "xme";
                case "mednyj aleut":
                    return "mud";
                case "medumba":
                    return "byv";
                case "me'en":
                    return "mym";
                case "mefele":
                    return "mfj";
                case "megam":
                    return "mef";
                case "megleno romanian":
                    return "ruq";
                case "mehek":
                    return "nux";
                case "mehináku":
                    return "mmh";
                case "mehri":
                    return "gdq";
                case "mekeo":
                    return "mek";
                case "mekmek":
                    return "mvk";
                case "mekwei":
                    return "msf";
                case "mele-fila":
                    return "mxe";
                case "melo":
                    return "mfx";
                case "melpa":
                    return "med";
                case "memoni":
                    return "mby";
                case "mendalam kayan":
                    return "xkd";
                case "mendankwe-nkwen":
                    return "mfd";
                case "mende":
                    return "men";
                case "mengaka":
                    return "xmg";
                case "mengen":
                    return "mee";
                case "mengisa":
                    return "mct";
                case "menka":
                    return "mea";
                case "menominee":
                    return "mez";
                case "mentawai":
                    return "mwv";
                case "menya":
                    return "mcr";
                case "meoswar":
                    return "mvx";
                case "mer":
                    return "mnu";
                case "meramera":
                    return "mxm";
                case "merei":
                    return "lmb";
                case "merey":
                    return "meq";
                case "meriam":
                    return "ulk";
                case "merlav":
                    return "mrm";
                case "meroitic":
                    return "xmr";
                case "meru":
                    return "mer";
                case "merwari":
                    return "wry";
                case "mesaka":
                    return "iyo";
                case "mescalero-chiricahua apache":
                    return "apm";
                case "mese":
                    return "mci";
                case "meskwaki":
                    return "sac";
                case "mesme":
                    return "zim";
                case "mesmes":
                    return "mys";
                case "mesopotamian arabic":
                    return "acm";
                case "mesqan":
                    return "mvz";
                case "messapic":
                    return "cms";
                case "meta'":
                    return "mgo";
                case "metlatónoc mixtec":
                    return "mxv";
                case "mewari":
                    return "mtr";
                case "mewati":
                    return "wtm";
                case "meyah":
                    return "mej";
                case "mezontla popoloca":
                    return "pbe";
                case "mezquital otomi":
                    return "ote";
                case "mfinu":
                    return "zmf";
                case "mfumte":
                    return "nfu";
                case "miahuatlán zapotec":
                    return "zam";
                case "miami":
                    return "mia";
                case "mian":
                    return "mpt";
                case "miani":
                    return "pla";
                case "michif":
                    return "crg";
                case "michigamea":
                    return "cmm";
                case "michoacán mazahua":
                    return "mmc";
                case "michoacán nahuatl":
                    return "ncl";
                case "micmac":
                    return "mic";
                case "mid grand valley dani":
                    return "dnt";
                case "middle armenian":
                    return "axm";
                case "middle breton":
                    return "xbm";
                case "middle cornish":
                    return "cnx";
                case "middle dutch":
                    return "dum";
                case "middle english":
                    return "enm";
                case "middle french":
                    return "frm";
                case "middle high german":
                    return "gmh";
                case "middle hittite":
                    return "htx";
                case "middle irish":
                    return "mga";
                case "middle korean":
                    return "okm";
                case "middle low german":
                    return "gml";
                case "middle mongolian":
                    return "xng";
                case "middle newar":
                    return "nwx";
                case "middle watut":
                    return "mpl";
                case "middle welsh":
                    return "wlm";
                case "midob":
                    return "mei";
                case "mid-southern banda":
                    return "bjo";
                case "migaama":
                    return "mmy";
                case "migabac":
                    return "mpp";
                case "miji":
                    return "sjl";
                case "mikasuki":
                    return "mik";
                case "mili":
                    return "ymh";
                case "miltu":
                    return "mlj";
                case "miluk":
                    return "iml";
                case "milyan":
                    return "imy";
                case "min bei chinese":
                    return "mnp";
                case "min dong chinese":
                    return "cdo";
                case "min nan chinese":
                    return "nan";
                case "min zhong chinese":
                    return "czo";
                case "mina":
                    return "hna";
                case "minaean":
                    return "inm";
                case "minangkabau":
                    return "min";
                case "minanibai":
                    return "mcv";
                case "minaveha":
                    return "mvn";
                case "mindiri":
                    return "mpn";
                case "mingang doso":
                    return "mko";
                case "mingrelian":
                    return "xmf";
                case "minica huitoto":
                    return "hto";
                case "minidien":
                    return "wii";
                case "minigir":
                    return "vmg";
                case "minoan":
                    return "omn";
                case "minokok":
                    return "mqq";
                case "minriq":
                    return "mnq";
                case "mintil":
                    return "mzt";
                case "minz zhuang":
                    return "zgm";
                case "miqie":
                    return "yiq";
                case "mirandese":
                    return "mwl";
                case "mire":
                    return "mvh";
                case "mirgan":
                    return "zrg";
                case "miri":
                    return "mrg";
                case "miriti":
                    return "mmv";
                case "miriwung":
                    return "mep";
                case "mirpur panjabi":
                    return "pmu";
                case "miship":
                    return "mjs";
                case "misima-paneati":
                    return "mpx";
                case "mískito":
                    return "miq";
                case "mitla zapotec":
                    return "zaw";
                case "mitlatongo mixtec":
                    return "vmm";
                case "mittu":
                    return "mwu";
                case "mituku":
                    return "zmq";
                case "miu":
                    return "mpo";
                case "miwa":
                    return "vmi";
                case "mixifore":
                    return "mfg";
                case "mixtepec mixtec":
                    return "mix";
                case "mixtepec zapotec":
                    return "zpm";
                case "miya":
                    return "mkf";
                case "miyako":
                    return "mvi";
                case "miyobe":
                    return "soy";
                case "mlabri":
                    return "mra";
                case "mlahsö":
                    return "lhs";
                case "mlap":
                    return "kja";
                case "mlomp":
                    return "mlo";
                case "mmaala":
                    return "mmu";
                case "mmen":
                    return "bfm";
                case "mo":
                    return "wkd";
                case "moabite":
                    return "obm";
                case "moba":
                    return "mfq";
                case "mobilian":
                    return "mod";
                case "mobumrin aizi":
                    return "ahm";
                case "mócheno":
                    return "mhn";
                case "mochi":
                    return "old";
                case "mochica":
                    return "omc";
                case "mocho":
                    return "mhc";
                case "mocoví":
                    return "moc";
                case "mo'da":
                    return "gbn";
                case "modang":
                    return "mxd";
                case "modern greek":
                    return "ell";
                case "modole":
                    return "mqo";
                case "moere":
                    return "mvq";
                case "mofu-gudur":
                    return "mif";
                case "mogholi":
                    return "mhj";
                case "mogum":
                    return "mou";
                case "mohave":
                    return "mov";
                case "mohawk":
                    return "moh";
                case "mohegan-montauk-narragansett":
                    return "mof";
                case "moi":
                    return "mow";
                case "moikodi":
                    return "mkp";
                case "moingi":
                    return "mwz";
                case "moji":
                    return "ymi";
                case "mok":
                    return "mqt";
                case "moken":
                    return "mwt";
                case "mokerang":
                    return "mft";
                case "mokilese":
                    return "mkj";
                case "moklen":
                    return "mkm";
                case "mokole":
                    return "mkl";
                case "mokpwe":
                    return "bri";
                case "moksela":
                    return "vms";
                case "moksha":
                    return "mdf";
                case "molale":
                    return "mbe";
                case "molbog":
                    return "pwm";
                case "moldavian":
                    return "mol";
                case "molengue":
                    return "bxc";
                case "molima":
                    return "mox";
                case "molmo one":
                    return "aun";
                case "molo":
                    return "zmo";
                case "molof":
                    return "msl";
                case "moloko":
                    return "mlw";
                case "mom jango":
                    return "ver";
                case "moma":
                    return "myl";
                case "momare":
                    return "msz";
                case "mombum":
                    return "mso";
                case "momina":
                    return "mmb";
                case "momuna":
                    return "mqf";
                case "mon":
                    return "mnw";
                case "mondé":
                    return "mnd";
                case "mondropolon":
                    return "npn";
                case "mongo":
                    return "lol";
                case "mongol":
                    return "mgt";
                case "mongolia buriat":
                    return "bxm";
                case "mongolian":
                    return "mon";
                case "mongondow":
                    return "mog";
                case "moni":
                    return "mnz";
                case "monimbo":
                    return "mom";
                case "mono":
                    return "mnh";
                case "monom":
                    return "moo";
                case "monsang naga":
                    return "nmh";
                case "montagnais":
                    return "moe";
                case "montol":
                    return "mtl";
                case "monumbo":
                    return "mxk";
                case "monzombo":
                    return "moj";
                case "moo":
                    return "gwg";
                case "moose cree":
                    return "crm";
                case "mopán maya":
                    return "mop";
                case "mor":
                    return "mhz";
                case "moraid":
                    return "msg";
                case "morawa":
                    return "mze";
                case "morelos nahuatl":
                    return "nhm";
                case "morerebi":
                    return "xmo";
                case "moresada":
                    return "msx";
                case "mori atas":
                    return "mzq";
                case "mori bawah":
                    return "xmz";
                case "morigi":
                    return "mdb";
                case "morisyen":
                    return "mfe";
                case "moro":
                    return "mor";
                case "moroccan arabic":
                    return "ary";
                case "morokodo":
                    return "mgc";
                case "morom":
                    return "bdo";
                case "moronene":
                    return "mqn";
                case "morori":
                    return "mok";
                case "morouas":
                    return "mrp";
                case "mortlockese":
                    return "mrl";
                case "moru":
                    return "mgd";
                case "mosimo":
                    return "mqv";
                case "mosina":
                    return "msn";
                case "mosiro":
                    return "mwy";
                case "moskona":
                    return "mtj";
                case "mossi":
                    return "mos";
                case "mota":
                    return "mtt";
                case "motlav":
                    return "mlv";
                case "motu":
                    return "meu";
                case "mouk-aria":
                    return "mwh";
                case "mountain koiali":
                    return "kpx";
                case "movima":
                    return "mzp";
                case "moyadan itneg":
                    return "ity";
                case "moyon naga":
                    return "nmo";
                case "mozarabic":
                    return "mxi";
                case "mpade":
                    return "mpi";
                case "mpi":
                    return "mpz";
                case "mpiemo":
                    return "mcx";
                case "mpongmpong":
                    return "mgg";
                case "mpoto":
                    return "mpa";
                case "mpotovoro":
                    return "mvt";
                case "mpuono":
                    return "zmp";
                case "mpur":
                    return "akc";
                case "mro chin":
                    return "cmr";
                case "mru":
                    return "mro";
                case "mser":
                    return "kqx";
                case "mt. iraya agta":
                    return "atl";
                case "mt. iriga agta":
                    return "agz";
                case "mualang":
                    return "mtd";
                case "mubami":
                    return "tsx";
                case "mubi":
                    return "mub";
                case "muda":
                    return "ymd";
                case "mudbura":
                    return "mwd";
                case "mudhili gadaba":
                    return "gau";
                case "mudu koraga":
                    return "vmd";
                case "muduapa":
                    return "wiv";
                case "muduga":
                    return "udg";
                case "mufian":
                    return "aoj";
                case "mugom":
                    return "muk";
                case "muinane":
                    return "bmr";
                case "mukha-dora":
                    return "mmk";
                case "mukulu":
                    return "moz";
                case "mulaha":
                    return "mfw";
                case "mulam":
                    return "mlm";
                case "mullu kurumba":
                    return "kpb";
                case "mullukmulluk":
                    return "mpb";
                case "multiple languages":
                    return "mul";
                case "muluridyi":
                    return "vmu";
                case "mum":
                    return "kqa";
                case "mumuye":
                    return "mzm";
                case "mün chin":
                    return "mwq";
                case "muna":
                    return "mnb";
                case "munda":
                    return "unx";
                case "mundabli":
                    return "boe";
                case "mundang":
                    return "mua";
                case "mundani":
                    return "mnf";
                case "mundari":
                    return "unr";
                case "mundat":
                    return "mmf";
                case "mündü":
                    return "muh";
                case "mundurukú":
                    return "myu";
                case "mungaka":
                    return "mhk";
                case "munggui":
                    return "mth";
                case "mungkip":
                    return "mpv";
                case "muniche":
                    return "myr";
                case "munit":
                    return "mtc";
                case "munji":
                    return "mnj";
                case "munsee":
                    return "umu";
                case "muong":
                    return "mtq";
                case "muratayak":
                    return "asx";
                case "murik":
                    return "mtf";
                case "murkim":
                    return "rmh";
                case "murle":
                    return "mur";
                case "murrinh-patha":
                    return "mwf";
                case "mursi":
                    return "muz";
                case "murui huitoto":
                    return "huu";
                case "murupi":
                    return "mqw";
                case "muruwari":
                    return "zmu";
                case "musak":
                    return "mmq";
                case "musar":
                    return "mmi";
                case "musasa":
                    return "smm";
                case "musey":
                    return "mse";
                case "musgu":
                    return "mug";
                case "mushungulu":
                    return "xma";
                case "musi":
                    return "mui";
                case "muskum":
                    return "mje";
                case "muslim tat":
                    return "ttt";
                case "musom":
                    return "msu";
                case "mussau-emira":
                    return "emi";
                case "muthuvan":
                    return "muv";
                case "mutu":
                    return "tuc";
                case "muya":
                    return "mvm";
                case "muyang":
                    return "muy";
                case "muyuw":
                    return "myw";
                case "muzi":
                    return "ymz";
                case "mvanip":
                    return "mcj";
                case "mvuba":
                    return "mxh";
                case "mwaghavul":
                    return "sur";
                case "mwali comorian":
                    return "wlc";
                case "mwan":
                    return "moa";
                case "mwani":
                    return "wmw";
                case "mwatebu":
                    return "mwa";
                case "mwera":
                    return "mwe";
                case "mwimbi-muthambi":
                    return "mws";
                case "mycenaean greek":
                    return "gmy";
                case "myene":
                    return "mye";
                case "mysian":
                    return "yms";
                case "mzieme naga":
                    return "nme";
                case "na":
                    return "nbt";
                case "naaba":
                    return "nao";
                case "naasioi":
                    return "nas";
                case "naba":
                    return "mne";
                case "nabak":
                    return "naf";
                case "nabi":
                    return "mty";
                case "nachering":
                    return "ncd";
                case "nadëb":
                    return "mbj";
                case "nadruvian":
                    return "ndf";
                case "nafaanra":
                    return "nfr";
                case "nafi":
                    return "srf";
                case "nafri":
                    return "nxx";
                case "nafusi":
                    return "jbn";
                case "naga pidgin":
                    return "nag";
                case "nagarchal":
                    return "nbg";
                case "nage":
                    return "nxe";
                case "nagumi":
                    return "ngv";
                case "nahali":
                    return "nlx";
                case "nahari":
                    return "nhh";
                case "nai":
                    return "bio";
                case "najdi arabic":
                    return "ars";
                case "naka'ela":
                    return "nae";
                case "nakai":
                    return "nkj";
                case "nakama":
                    return "nib";
                case "nakanai":
                    return "nak";
                case "nakara":
                    return "nck";
                case "nake":
                    return "nbk";
                case "naki":
                    return "mff";
                case "nakwi":
                    return "nax";
                case "nalca":
                    return "nlc";
                case "nali":
                    return "nss";
                case "nalik":
                    return "nal";
                case "nalu":
                    return "naj";
                case "naluo yi":
                    return "ylo";
                case "nama":
                    return "naq";
                case "namakura":
                    return "nmk";
                case "namat":
                    return "nkm";
                case "nambo":
                    return "ncm";
                case "nambya":
                    return "nmq";
                case "ná-meo":
                    return "neo";
                case "namia":
                    return "nnm";
                case "namiae":
                    return "nvm";
                case "namla":
                    return "naa";
                case "namo":
                    return "mxw";
                case "namonuito":
                    return "nmt";
                case "namosi-naitasiri-serua":
                    return "bwb";
                case "namuyi":
                    return "nmy";
                case "nanai":
                    return "gld";
                case "nancere":
                    return "nnc";
                case "nande":
                    return "nnb";
                case "nandi":
                    return "niq";
                case "nanerigé sénoufo":
                    return "sen";
                case "nanggu":
                    return "ngr";
                case "nangikurrunggurr":
                    return "nam";
                case "nankina":
                    return "nnk";
                case "nanti":
                    return "cox";
                case "nanticoke":
                    return "nnt";
                case "nanubae":
                    return "afk";
                case "napo lowland quechua":
                    return "qvo";
                case "napu":
                    return "npy";
                case "nar phu":
                    return "npa";
                case "nara":
                    return "nrb";
                case "narak":
                    return "nac";
                case "narango":
                    return "nrg";
                case "narau":
                    return "nxu";
                case "narim":
                    return "loh";
                case "naro":
                    return "nhr";
                case "narom":
                    return "nrm";
                case "narrinyeri":
                    return "nay";
                case "narungga":
                    return "nnr";
                case "nasal":
                    return "nsy";
                case "nasarian":
                    return "nvh";
                case "naskapi":
                    return "nsk";
                case "natagaimas":
                    return "nts";
                case "natanzi":
                    return "ntz";
                case "nataoran amis":
                    return "ais";
                case "natchez":
                    return "ncz";
                case "nateni":
                    return "ntm";
                case "nathembo":
                    return "nte";
                case "natioro":
                    return "nti";
                case "nauete":
                    return "nxa";
                case "naukan yupik":
                    return "ynk";
                case "nauna":
                    return "ncn";
                case "nauru":
                    return "nau";
                case "navaho":
                    return "nav";
                case "navut":
                    return "nsw";
                case "nawaru":
                    return "nwr";
                case "nawathinehena":
                    return "nwa";
                case "nawdm":
                    return "nmz";
                case "nawuri":
                    return "naw";
                case "naxi":
                    return "nbf";
                case "nayi":
                    return "noz";
                case "nayini":
                    return "nyq";
                case "ncane":
                    return "ncr";
                case "nchumbulu":
                    return "nlu";
                case "ndai":
                    return "gke";
                case "ndaka":
                    return "ndk";
                case "ndaktup":
                    return "ncp";
                case "ndali":
                    return "ndh";
                case "ndam":
                    return "ndm";
                case "ndamba":
                    return "ndj";
                case "nda'nda'":
                    return "nnz";
                case "ndasa":
                    return "nda";
                case "ndau":
                    return "ndc";
                case "nde-gbite":
                    return "ned";
                case "ndemli":
                    return "nml";
                case "ndendeule":
                    return "dne";
                case "ndengereko":
                    return "ndg";
                case "nde-nsele-nta":
                    return "ndd";
                case "nding":
                    return "eli";
                case "ndo":
                    return "ndp";
                case "ndobo":
                    return "ndw";
                case "ndoe":
                    return "nbb";
                case "ndogo":
                    return "ndz";
                case "ndolo":
                    return "ndl";
                case "ndom":
                    return "nqm";
                case "ndombe":
                    return "ndq";
                case "ndonde hamba":
                    return "njd";
                case "ndonga":
                    return "ndo";
                case "ndoola":
                    return "ndr";
                case "nduga":
                    return "ndx";
                case "ndumu":
                    return "nmd";
                case "ndun":
                    return "nfd";
                case "ndunda":
                    return "nuh";
                case "ndunga":
                    return "ndt";
                case "ndut":
                    return "ndv";
                case "ndyuka-trio pidgin":
                    return "njt";
                case "ndzwani comorian":
                    return "wni";
                case "neapolitan":
                    return "nap";
                case "nebaj ixil":
                    return "ixi";
                case "nedebang":
                    return "nec";
                case "nefamese":
                    return "nef";
                case "negerhollands":
                    return "dcr";
                case "negeri sembilan malay":
                    return "zmi";
                case "negidal":
                    return "neg";
                case "nehan":
                    return "nsn";
                case "nek":
                    return "nif";
                case "nekgini":
                    return "nkg";
                case "neko":
                    return "nej";
                case "neku":
                    return "nek";
                case "neme":
                    return "nex";
                case "nemi":
                    return "nem";
                case "nen":
                    return "nqn";
                case "nend":
                    return "anh";
                case "nenets":
                    return "yrk";
                case "nengone":
                    return "nen";
                case "neo-hittite":
                    return "nei";
                case "nepal bhasa":
                    return "new";
                case "nepali":
                    return "nep";
                case "nepali kurux":
                    return "kxl";
                case "nete":
                    return "net";
                case "new caledonian javanese":
                    return "jas";
                case "neyo":
                    return "ney";
                case "nez perce":
                    return "nez";
                case "nga la":
                    return "hlt";
                case "ngaanyatjarra":
                    return "ntj";
                case "ngäbere":
                    return "gym";
                case "ngad'a":
                    return "nxg";
                case "ngadjunmaya":
                    return "nju";
                case "ngaing":
                    return "nnf";
                case "ngaju":
                    return "nij";
                case "ngala":
                    return "nud";
                case "ngalakan":
                    return "nig";
                case "ngalkbun":
                    return "ngk";
                case "ngalum":
                    return "szb";
                case "ngam":
                    return "nmc";
                case "ngamambo":
                    return "nbv";
                case "ngambay":
                    return "sba";
                case "ngamini":
                    return "nmv";
                case "ngamo":
                    return "nbh";
                case "nganasan":
                    return "nio";
                case "ngandi":
                    return "nid";
                case "ngando":
                    return "ngd";
                case "ngandyera":
                    return "nne";
                case "ngangam":
                    return "gng";
                case "nganyaywana":
                    return "nyx";
                case "ngarinman":
                    return "nbj";
                case "ngarinyin":
                    return "ung";
                case "ngarla":
                    return "nlr";
                case "ngarluma":
                    return "nrl";
                case "ngas":
                    return "anc";
                case "ngasa":
                    return "nsg";
                case "ngatik men's creole":
                    return "ngm";
                case "ngawn chin":
                    return "cnw";
                case "ngawun":
                    return "nxn";
                case "ngazidja comorian":
                    return "zdj";
                case "ngbaka":
                    return "nga";
                case "ngbaka ma'bo":
                    return "nbm";
                case "ngbaka manza":
                    return "ngg";
                case "ngbee":
                    return "jgb";
                case "ngbinda":
                    return "nbd";
                case "ngbundu":
                    return "nuu";
                case "ngelima":
                    return "agh";
                case "ngemba":
                    return "nge";
                case "ngeq":
                    return "ngt";
                case "ngete":
                    return "nnn";
                case "nggem":
                    return "nbq";
                case "nggwahyi":
                    return "ngx";
                case "ngie":
                    return "ngj";
                case "ngiemboon":
                    return "nnh";
                case "ngile":
                    return "jle";
                case "ngindo":
                    return "nnq";
                case "ngiti":
                    return "niy";
                case "ngizim":
                    return "ngi";
                case "ngkâlmpw kanum":
                    return "kcd";
                case "ngom":
                    return "nra";
                case "ngomba":
                    return "jgo";
                case "ngombale":
                    return "nla";
                case "ngombe":
                    return "ngc";
                case "ngong":
                    return "nnx";
                case "ngongo":
                    return "noq";
                case "ngoni":
                    return "ngo";
                case "ngoreme":
                    return "ngq";
                case "ngoshie":
                    return "nsh";
                case "ngul":
                    return "nlo";
                case "ngulu":
                    return "ngp";
                case "nguluwan":
                    return "nuw";
                case "ngumbi":
                    return "nui";
                case "ngundi":
                    return "ndn";
                case "ngundu":
                    return "nue";
                case "ngungwel":
                    return "ngz";
                case "nguôn":
                    return "nuo";
                case "ngura":
                    return "nbx";
                case "ngurmbur":
                    return "nrx";
                case "ngwaba":
                    return "ngw";
                case "ngwe":
                    return "nwe";
                case "ngwo":
                    return "ngn";
                case "nhanda":
                    return "nha";
                case "nhengatu":
                    return "yrl";
                case "nhuwala":
                    return "nhf";
                case "nias":
                    return "nia";
                case "nicaragua creole english":
                    return "bzk";
                case "niellim":
                    return "nie";
                case "nigeria mambila":
                    return "mzk";
                case "nigerian fulfulde":
                    return "fuv";
                case "nigerian pidgin":
                    return "pcm";
                case "nihali":
                    return "nll";
                case "nii":
                    return "nii";
                case "nijadali":
                    return "nad";
                case "niksek":
                    return "gbe";
                case "nila":
                    return "nil";
                case "nilamba":
                    return "nim";
                case "nimadi":
                    return "noe";
                case "nimanbur":
                    return "nmp";
                case "nimbari":
                    return "nmr";
                case "nimboran":
                    return "nir";
                case "nimi":
                    return "nis";
                case "nimo":
                    return "niw";
                case "nimoa":
                    return "nmw";
                case "ninam":
                    return "shb";
                case "nindi":
                    return "nxi";
                case "ningera":
                    return "nby";
                case "ninggerum":
                    return "nxr";
                case "ningil":
                    return "niz";
                case "ningye":
                    return "nns";
                case "ninia yali":
                    return "nlk";
                case "ninzo":
                    return "nin";
                case "nipsan":
                    return "nps";
                case "nisa":
                    return "njs";
                case "nisenan":
                    return "nsz";
                case "nisga'a":
                    return "ncg";
                case "nisi":
                    return "dap";
                case "niuafo'ou":
                    return "num";
                case "niuatoputapu":
                    return "nkp";
                case "niuean":
                    return "niu";
                case "nivaclé":
                    return "cag";
                case "njalgulgule":
                    return "njl";
                case "njebi":
                    return "nzb";
                case "njen":
                    return "njj";
                case "njerep":
                    return "njr";
                case "njyem":
                    return "njy";
                case "nkangala":
                    return "nkn";
                case "nkari":
                    return "nkz";
                case "nkem-nkum":
                    return "isi";
                case "nkhumbi":
                    return "khu";
                case "n'ko":
                    return "nqo";
                case "nkongho":
                    return "nkc";
                case "nkonya":
                    return "nko";
                case "nkoroo":
                    return "nkx";
                case "nkoya":
                    return "nka";
                case "nkukoli":
                    return "nbo";
                case "nkutu":
                    return "nkw";
                case "nnam":
                    return "nbp";
                case "nobiin":
                    return "fia";
                case "nobonob":
                    return "gaw";
                case "nocamán":
                    return "nom";
                case "nocte naga":
                    return "njb";
                case "nogai":
                    return "nog";
                case "noiri":
                    return "noi";
                case "nokuku":
                    return "nkk";
                case "nomaande":
                    return "lem";
                case "nomane":
                    return "nof";
                case "nomatsiguenga":
                    return "not";
                case "nomu":
                    return "noh";
                case "nong zhuang":
                    return "zhn";
                case "nooksack":
                    return "nok";
                case "noon":
                    return "snf";
                case "noone":
                    return "nhu";
                case "nootka":
                    return "noo";
                case "nopala chatino":
                    return "cya";
                case "noric":
                    return "nrc";
                case "norn":
                    return "nrn";
                case "norra":
                    return "nrr";
                case "north alaskan inupiatun":
                    return "esi";
                case "north ambrym":
                    return "mmg";
                case "north asmat":
                    return "nks";
                case "north awyu":
                    return "yir";
                case "north azerbaijani":
                    return "azj";
                case "north babar":
                    return "bcd";
                case "north bolivian quechua":
                    return "qul";
                case "north central mixe":
                    return "neq";
                case "north efate":
                    return "llp";
                case "north fali":
                    return "fll";
                case "north giziga":
                    return "gis";
                case "north junín quechua":
                    return "qvn";
                case "north levantine arabic":
                    return "apc";
                case "north marquesan":
                    return "mrq";
                case "north mesopotamian arabic":
                    return "ayp";
                case "north mofu":
                    return "mfk";
                case "north moluccan malay":
                    return "max";
                case "north muyu":
                    return "kti";
                case "north ndebele":
                    return "nde";
                case "north nuaulu":
                    return "nni";
                case "north picene":
                    return "nrp";
                case "north slavey":
                    return "scs";
                case "north tairora":
                    return "tbg";
                case "north tanna":
                    return "tnn";
                case "north wahgi":
                    return "whg";
                case "north watut":
                    return "una";
                case "north wemale":
                    return "weo";
                case "northeast kiwai":
                    return "kiw";
                case "northeast maidu":
                    return "nmu";
                case "northeast pashayi":
                    return "aee";
                case "northeastern dinka":
                    return "dip";
                case "northeastern pomo":
                    return "pef";
                case "northeastern thai":
                    return "tts";
                case "northern alta":
                    return "aqn";
                case "northern altai":
                    return "atv";
                case "northern amami-oshima":
                    return "ryn";
                case "northern bai":
                    return "bfc";
                case "northern betsimisaraka malagasy":
                    return "bmm";
                case "northern cakchiquel":
                    return "ckc";
                case "northern catanduanes bicolano":
                    return "cts";
                case "northern conchucos ancash quechua":
                    return "qxn";
                case "northern dagara":
                    return "dgi";
                case "northern dong":
                    return "doc";
                case "northern east cree":
                    return "crl";
                case "northern emberá":
                    return "emp";
                case "northern frisian":
                    return "frr";
                case "northern ghale":
                    return "ghh";
                case "northern gondi":
                    return "gno";
                case "northern grebo":
                    return "gbo";
                case "northern guiyang hmong":
                    return "huj";
                case "northern haida":
                    return "hdn";
                case "northern hindko":
                    return "hno";
                case "northern huishui hmong":
                    return "hmi";
                case "northern kalapuya":
                    return "nrt";
                case "northern kankanay":
                    return "xnn";
                case "northern khmer":
                    return "kxm";
                case "northern kissi":
                    return "kqs";
                case "northern kurdish":
                    return "kmr";
                case "northern lorung":
                    return "lbr";
                case "northern luri":
                    return "lrc";
                case "northern mam":
                    return "mam";
                case "northern mashan hmong":
                    return "hmp";
                case "northern muji":
                    return "ymx";
                case "northern ngbandi":
                    return "ngb";
                case "northern nisu":
                    return "yiv";
                case "northern nuni":
                    return "nuv";
                case "northern oaxaca nahuatl":
                    return "nhy";
                case "northern ohlone":
                    return "cst";
                case "northern one":
                    return "onr";
                case "northern paiute":
                    return "pao";
                case "northern pame":
                    return "pmq";
                case "northern pashto":
                    return "pbu";
                case "northern pastaza quichua":
                    return "qvz";
                case "northern pomo":
                    return "pej";
                case "northern puebla nahuatl":
                    return "ncj";
                case "northern pumi":
                    return "pmi";
                case "northern qiandong miao":
                    return "hea";
                case "northern qiang":
                    return "cng";
                case "northern rengma naga":
                    return "nnl";
                case "northern roglai":
                    return "rog";
                case "northern sami":
                    return "sme";
                case "northern sierra miwok":
                    return "nsq";
                case "northern subanen":
                    return "stb";
                case "northern tarahumara":
                    return "thh";
                case "northern tepehuan":
                    return "ntp";
                case "northern thai":
                    return "nod";
                case "northern tiwa":
                    return "twf";
                case "northern tlaxiaco mixtec":
                    return "xtn";
                case "northern toussian":
                    return "tsp";
                case "northern tujia":
                    return "tji";
                case "northern tutchone":
                    return "ttm";
                case "northern uzbek":
                    return "uzn";
                case "northern yukaghir":
                    return "ykg";
                case "northwest alaska inupiatun":
                    return "esk";
                case "northwest gbaya":
                    return "gya";
                case "northwest maidu":
                    return "mjd";
                case "northwest oaxaca mixtec":
                    return "mxa";
                case "northwest pashayi":
                    return "glh";
                case "northwestern dinka":
                    return "diw";
                case "northwestern fars":
                    return "faz";
                case "northwestern kolami":
                    return "kfb";
                case "northwestern ojibwa":
                    return "ojb";
                case "northwestern tamang":
                    return "tmk";
                case "norwegian":
                    return "nor";
                case "norwegian bokmål":
                    return "nob";
                case "norwegian nynorsk":
                    return "nno";
                case "notre":
                    return "bly";
                case "notsi":
                    return "ncf";
                case "nottoway":
                    return "ntw";
                case "nottoway-meherrin":
                    return "nwy";
                case "novial":
                    return "nov";
                case "noy":
                    return "noy";
                case "nsari":
                    return "asj";
                case "nsenga":
                    return "nse";
                case "nshi":
                    return "nsc";
                case "nsongo":
                    return "nsx";
                case "ntcham":
                    return "bud";
                case "ntomba":
                    return "nto";
                case "nubaca":
                    return "baf";
                case "nubi":
                    return "kcn";
                case "nubri":
                    return "kte";
                case "nuer":
                    return "nus";
                case "nugunu":
                    return "nnv";
                case "nuk":
                    return "noc";
                case "nukak makú":
                    return "mbr";
                case "nukna":
                    return "klt";
                case "nukuini":
                    return "nuc";
                case "nukumanu":
                    return "nuq";
                case "nukuoro":
                    return "nkr";
                case "nukuria":
                    return "nur";
                case "numana-nunku-gbantu-numbu":
                    return "nbr";
                case "numanggang":
                    return "nop";
                case "numbami":
                    return "sij";
                case "nume":
                    return "tgs";
                case "numee":
                    return "kdk";
                case "numidian":
                    return "nxm";
                case "nung":
                    return "nun";
                case "nungali":
                    return "nug";
                case "nunggubuyu":
                    return "nuy";
                case "nungu":
                    return "rin";
                case "nuosu":
                    return "iii";
                case "nupbikha":
                    return "npb";
                case "nupe-nupe-tako":
                    return "nup";
                case "nüpode huitoto":
                    return "hux";
                case "nusa laut":
                    return "nul";
                case "nusu":
                    return "nuf";
                case "nyabwa":
                    return "nwb";
                case "nyaheun":
                    return "nev";
                case "nyahkur":
                    return "cbn";
                case "nyakyusa-ngonde":
                    return "nyy";
                case "nyâlayu":
                    return "yly";
                case "nyali":
                    return "nlj";
                case "nyam":
                    return "nmi";
                case "nyamal":
                    return "nly";
                case "nyambo":
                    return "now";
                case "nyamusa-molo":
                    return "nwm";
                case "nyamwanga":
                    return "mwn";
                case "nyamwezi":
                    return "nym";
                case "nyaneka":
                    return "nyk";
                case "nyanga":
                    return "nyj";
                case "nyanga-li":
                    return "nyc";
                case "nyangatom":
                    return "nnj";
                case "nyangbo":
                    return "nyb";
                case "nyangga":
                    return "nny";
                case "nyang'i":
                    return "nyp";
                case "nyangumarta":
                    return "nna";
                case "nyankole":
                    return "nyn";
                case "nyarafolo senoufo":
                    return "sev";
                case "nyaturu":
                    return "rim";
                case "nyaw":
                    return "nyw";
                case "nyawaygi":
                    return "nyt";
                case "nyemba":
                    return "nba";
                case "nyeng":
                    return "nfg";
                case "nyengo":
                    return "nye";
                case "nyenkha":
                    return "neh";
                case "nyeu":
                    return "nyl";
                case "nyigina":
                    return "nyh";
                case "nyiha":
                    return "nih";
                case "nyindrou":
                    return "lid";
                case "nyindu":
                    return "nyg";
                case "nyole":
                    return "nuj";
                case "nyong":
                    return "muo";
                case "nyore":
                    return "nyd";
                case "nyoro":
                    return "nyo";
                case "nyulnyul":
                    return "nyv";
                case "nyunga":
                    return "nys";
                case "nyungwe":
                    return "nyu";
                case "nzakambay":
                    return "nzy";
                case "nzakara":
                    return "nzk";
                case "nzanyi":
                    return "nja";
                case "nzima":
                    return "nzi";
                case "obanliku":
                    return "bzy";
                case "obispeño":
                    return "obi";
                case "oblo":
                    return "obl";
                case "obo manobo":
                    return "obo";
                case "obokuitai":
                    return "afz";
                case "obolo":
                    return "ann";
                case "obulom":
                    return "obu";
                case "ocaina":
                    return "oca";
                case "occitan":
                    return "oci";
                case "o'chi'chi'":
                    return "xoc";
                case "ocotepec mixtec":
                    return "mie";
                case "ocotlán zapotec":
                    return "zac";
                case "od":
                    return "odk";
                case "odiai":
                    return "bhf";
                case "odoodee":
                    return "kkc";
                case "o'du":
                    return "tyh";
                case "odual":
                    return "odu";
                case "odut":
                    return "oda";
                case "ofayé":
                    return "opy";
                case "ofo":
                    return "ofo";
                case "ogbah":
                    return "ogc";
                case "ogbia":
                    return "ogb";
                case "ogbogolo":
                    return "ogg";
                case "ogbronuagum":
                    return "ogu";
                case "ogea":
                    return "eri";
                case "oirata":
                    return "oia";
                case "ojibwa":
                    return "oji";
                case "ojitlán chinantec":
                    return "chj";
                case "okanagan":
                    return "oka";
                case "okiek":
                    return "oki";
                case "oki-no-erabu":
                    return "okn";
                case "okobo":
                    return "okb";
                case "okodia":
                    return "okd";
                case "oko-eni-osayen":
                    return "oks";
                case "oko-juwoi":
                    return "okj";
                case "okolod":
                    return "kqv";
                case "okpamheri":
                    return "opa";
                case "okpe":
                    return "oke";
                case "oksapmin":
                    return "opm";
                case "oku":
                    return "oku";
                case "old aramaic":
                    return "oar";
                case "old avar":
                    return "oav";
                case "old breton":
                    return "obt";
                case "old burmese":
                    return "obr";
                case "old chinese":
                    return "och";
                case "old cornish":
                    return "oco";
                case "old dutch":
                    return "odt";
                case "old english":
                    return "ang";
                case "old french":
                    return "fro";
                case "old frisian":
                    return "ofs";
                case "old georgian":
                    return "oge";
                case "old high german":
                    return "goh";
                case "old hittite":
                    return "oht";
                case "old hungarian":
                    return "ohu";
                case "old irish":
                    return "sga";
                case "old japanese":
                    return "ojp";
                case "old korean":
                    return "oko";
                case "old manipuri":
                    return "omp";
                case "old marathi":
                    return "omr";
                case "old mon":
                    return "omx";
                case "old norse":
                    return "non";
                case "old nubian":
                    return "onw";
                case "old ossetic":
                    return "oos";
                case "old persian":
                    return "peo";
                case "old provençal":
                    return "pro";
                case "old russian":
                    return "orv";
                case "old saxon":
                    return "osx";
                case "old spanish":
                    return "osp";
                case "old tamil":
                    return "oty";
                case "old tibetan":
                    return "otb";
                case "old turkish":
                    return "otk";
                case "old uighur":
                    return "oui";
                case "old welsh":
                    return "owl";
                case "olekha":
                    return "ole";
                case "olo":
                    return "ong";
                case "oloma":
                    return "olm";
                case "olu'bo":
                    return "lul";
                case "olulumo-ikom":
                    return "iko";
                case "olusamia":
                    return "lsm";
                case "oluta popoluca":
                    return "plo";
                case "olutsotso":
                    return "lto";
                case "oluwanga":
                    return "lwg";
                case "omagua":
                    return "omg";
                case "omaha-ponca":
                    return "oma";
                case "omani arabic":
                    return "acx";
                case "omati":
                    return "mgx";
                case "ombamba":
                    return "mbm";
                case "ombo":
                    return "oml";
                case "omejes":
                    return "ome";
                case "ometepec nahuatl":
                    return "nht";
                case "omi":
                    return "omi";
                case "ömie":
                    return "aom";
                case "omok":
                    return "omk";
                case "omotik":
                    return "omt";
                case "omurano":
                    return "omu";
                case "ona":
                    return "ona";
                case "oneida":
                    return "one";
                case "ong":
                    return "oog";
                case "önge":
                    return "oon";
                case "onin":
                    return "oni";
                case "onin based pidgin":
                    return "onx";
                case "onjob":
                    return "onj";
                case "ono":
                    return "ons";
                case "onobasulu":
                    return "onn";
                case "onondaga":
                    return "ono";
                case "ontenu":
                    return "ont";
                case "ontong java":
                    return "ojv";
                case "oorlams":
                    return "oor";
                case "opao":
                    return "opo";
                case "opata":
                    return "opt";
                case "opuuo":
                    return "lgn";
                case "orang kanaq":
                    return "orn";
                case "orang seletar":
                    return "ors";
                case "oraon sadri":
                    return "sdr";
                case "orejón":
                    return "ore";
                case "oring":
                    return "org";
                case "oriya":
                    return "ori";
                case "orizaba nahuatl":
                    return "nlv";
                case "orma":
                    return "orc";
                case "ormu":
                    return "orz";
                case "ormuri":
                    return "oru";
                case "oro":
                    return "orx";
                case "oro win":
                    return "orw";
                case "oroch":
                    return "oac";
                case "oroha":
                    return "ora";
                case "orok":
                    return "oaa";
                case "orokaiva":
                    return "okv";
                case "oroko":
                    return "bdu";
                case "orokolo":
                    return "oro";
                case "oromo":
                    return "orm";
                case "oroqen":
                    return "orh";
                case "orowe":
                    return "bpk";
                case "oruma":
                    return "orr";
                case "orya":
                    return "ury";
                case "osage":
                    return "osa";
                case "osatu":
                    return "ost";
                case "oscan":
                    return "osc";
                case "osing":
                    return "osi";
                case "ososo":
                    return "oso";
                case "ossetian":
                    return "oss";
                case "ot danum":
                    return "otd";
                case "otank":
                    return "uta";
                case "oti":
                    return "oti";
                case "otoro":
                    return "otr";
                case "ottawa":
                    return "otw";
                case "ottoman turkish":
                    return "ota";
                case "otuho":
                    return "lot";
                case "otuke":
                    return "otu";
                case "ouma":
                    return "oum";
                case "oune":
                    return "oue";
                case "owa":
                    return "stn";
                case "owenia":
                    return "wsr";
                case "owiniga":
                    return "owi";
                case "oxchuc tzeltal":
                    return "tzh";
                case "oy":
                    return "oyb";
                case "oya'oya":
                    return "oyy";
                case "oyda":
                    return "oyd";
                case "ozolotepec zapotec":
                    return "zao";
                case "ozumacín chinantec":
                    return "chz";
                case "pa di":
                    return "pdi";
                case "pa'a":
                    return "pqa";
                case "pááfang":
                    return "pfa";
                case "paama":
                    return "pma";
                case "paasaal":
                    return "sig";
                case "pacahuara":
                    return "pcp";
                case "pacaraos quechua":
                    return "qvp";
                case "pacific gulf yupik":
                    return "ems";
                case "pacoh":
                    return "pac";
                case "padoe":
                    return "pdo";
                case "paekche":
                    return "pkc";
                case "paelignian":
                    return "pgn";
                case "páez":
                    return "pbb";
                case "pagi":
                    return "pgi";
                case "pagibete":
                    return "pae";
                case "pagu":
                    return "pgu";
                case "pahari-potwari":
                    return "phr";
                case "pahi":
                    return "lgt";
                case "pahlavani":
                    return "phv";
                case "pahlavi":
                    return "pal";
                case "pa-hng":
                    return "pha";
                case "pai tavytera":
                    return "pta";
                case "paicî":
                    return "pri";
                case "paipai":
                    return "ppi";
                case "paite chin":
                    return "pck";
                case "paiwan":
                    return "pwn";
                case "pakaásnovos":
                    return "pav";
                case "pakanha":
                    return "pkn";
                case "pak-tong":
                    return "pkg";
                case "paku":
                    return "pku";
                case "paku karen":
                    return "kpp";
                case "pal":
                    return "abw";
                case "palaic":
                    return "plq";
                case "palaka senoufo":
                    return "plr";
                case "palantla chinantec":
                    return "cpa";
                case "palauan":
                    return "pau";
                case "pale palaung":
                    return "pce";
                case "palenquero":
                    return "pln";
                case "pali":
                    return "pli";
                case "palikúr":
                    return "plu";
                case "paliyan":
                    return "pcf";
                case "palor":
                    return "fap";
                case "palpa":
                    return "plp";
                case "palu":
                    return "pbz";
                case "paluan":
                    return "plz";
                case "palu'e":
                    return "ple";
                case "palumata":
                    return "pmc";
                case "palya bareli":
                    return "bpx";
                case "pam":
                    return "pmn";
                case "pambia":
                    return "pmb";
                case "pamlico":
                    return "pmk";
                case "pamona":
                    return "pmf";
                case "pamosu":
                    return "hih";
                case "pamplona atta":
                    return "att";
                case "pana":
                    return "pnq";
                case "panamint":
                    return "par";
                case "panang":
                    return "pcr";
                case "panao huánuco quechua":
                    return "qxh";
                case "panará":
                    return "kre";
                case "panasuan":
                    return "psn";
                case "panawa":
                    return "pwb";
                case "pancana":
                    return "pnp";
                case "panchpargania":
                    return "tdb";
                case "pande":
                    return "bkj";
                case "pangasinan":
                    return "pag";
                case "pangseng":
                    return "pgs";
                case "pangutaran sama":
                    return "slm";
                case "pangwa":
                    return "pbr";
                case "pangwali":
                    return "pgg";
                case "panim":
                    return "pnr";
                case "paniya":
                    return "pcg";
                case "panjabi":
                    return "pan";
                case "pankararé":
                    return "pax";
                case "pankararú":
                    return "paz";
                case "pankhu":
                    return "pkh";
                case "pannei":
                    return "pnc";
                case "panoan katukína":
                    return "knt";
                case "panobo":
                    return "pno";
                case "panytyima":
                    return "pnw";
                case "pao":
                    return "ppa";
                case "pa'o karen":
                    return "blk";
                case "papantla totonac":
                    return "top";
                case "papapana":
                    return "ppn";
                case "papar":
                    return "dpp";
                case "papasena":
                    return "pas";
                case "papavô":
                    return "ppv";
                case "papel":
                    return "pbo";
                case "papi":
                    return "ppe";
                case "papiamento":
                    return "pap";
                case "papitalai":
                    return "pat";
                case "papora":
                    return "ppu";
                case "papuan malay":
                    return "pmy";
                case "papuma":
                    return "ppm";
                case "pará arára":
                    return "aap";
                case "pará gavião":
                    return "gvp";
                case "para naga":
                    return "pzn";
                case "parachi":
                    return "prc";
                case "paraguayan guaraní":
                    return "gug";
                case "parakanã":
                    return "pak";
                case "paranan":
                    return "agp";
                case "paranawát":
                    return "paf";
                case "paraujano":
                    return "pbg";
                case "parauk":
                    return "prk";
                case "parawen":
                    return "prw";
                case "pardhan":
                    return "pch";
                case "pardhi":
                    return "pcl";
                case "pare":
                    return "ppt";
                case "parecís":
                    return "pab";
                case "parenga":
                    return "pcj";
                case "päri":
                    return "lkr";
                case "parkari koli":
                    return "kvx";
                case "parkwa":
                    return "pbi";
                case "parsi":
                    return "prp";
                case "parsi-dari":
                    return "prd";
                case "parthian":
                    return "xpr";
                case "parya":
                    return "paq";
                case "pashto":
                    return "pus";
                case "pasi":
                    return "psq";
                case "pass valley yali":
                    return "yac";
                case "patamona":
                    return "pbc";
                case "patani":
                    return "ptn";
                case "pataxó hã-ha-hãe":
                    return "pth";
                case "patep":
                    return "ptp";
                case "pathiya":
                    return "pty";
                case "patpatar":
                    return "gfk";
                case "pattani":
                    return "lae";
                case "pattani malay":
                    return "mfa";
                case "paulohi":
                    return "plh";
                case "paumarí":
                    return "pad";
                case "pauri bareli":
                    return "bfb";
                case "pauserna":
                    return "psm";
                case "pawaia":
                    return "pwa";
                case "pawnee":
                    return "paw";
                case "paynamar":
                    return "pmr";
                case "pe":
                    return "pai";
                case "pear":
                    return "pcb";
                case "pech":
                    return "pay";
                case "pecheneg":
                    return "xpc";
                case "peere":
                    return "pfe";
                case "pei":
                    return "ppq";
                case "pekal":
                    return "pel";
                case "pela":
                    return "bxd";
                case "pele-ata":
                    return "ata";
                case "pelende":
                    return "ppp";
                case "pemon":
                    return "aoc";
                case "pémono":
                    return "pev";
                case "penchal":
                    return "pek";
                case "pendau":
                    return "ums";
                case "pengo":
                    return "peg";
                case "pennsylvania german":
                    return "pdc";
                case "peñoles mixtec":
                    return "mil";
                case "penrhyn":
                    return "pnh";
                case "pentlatch":
                    return "ptw";
                case "perai":
                    return "wet";
                case "peranakan indonesian":
                    return "pea";
                case "peripheral mongolian":
                    return "mvf";
                case "pero":
                    return "pip";
                case "persian":
                    return "fas";
                case "petapa zapotec":
                    return "zpe";
                case "petats":
                    return "pex";
                case "petjo":
                    return "pey";
                case "pévé":
                    return "lme";
                case "pfaelzisch":
                    return "pfl";
                case "phai":
                    return "prt";
                case "phake":
                    return "phk";
                case "phala":
                    return "ypa";
                case "phalura":
                    return "phl";
                case "phana'":
                    return "phq";
                case "phangduwali":
                    return "phw";
                case "phende":
                    return "pem";
                case "phimbi":
                    return "phm";
                case "phoenician":
                    return "phn";
                case "phola":
                    return "ypg";
                case "pholo":
                    return "yip";
                case "phom naga":
                    return "nph";
                case "phong-kniang":
                    return "pnx";
                case "phrae pwo karen":
                    return "kjt";
                case "phrygian":
                    return "xpg";
                case "phu thai":
                    return "pht";
                case "phuan":
                    return "phu";
                case "phudagi":
                    return "phd";
                case "phuie":
                    return "pug";
                case "phukha":
                    return "phh";
                case "phuma":
                    return "ypm";
                case "phunoi":
                    return "pho";
                case "phuong":
                    return "phg";
                case "phupa":
                    return "ypp";
                case "phupha":
                    return "yph";
                case "phuza":
                    return "ypz";
                case "piamatsina":
                    return "ptr";
                case "piame":
                    return "pin";
                case "piapoco":
                    return "pio";
                case "piaroa":
                    return "pid";
                case "picard":
                    return "pcd";
                case "pichis ashéninka":
                    return "cpu";
                case "pictish":
                    return "xpi";
                case "pidgin delaware":
                    return "dep";
                case "piemontese":
                    return "pms";
                case "pijao":
                    return "pij";
                case "pije":
                    return "piz";
                case "pijin":
                    return "pis";
                case "pilagá":
                    return "plg";
                case "pileni":
                    return "piv";
                case "pima bajo":
                    return "pia";
                case "pimbwe":
                    return "piw";
                case "pinai-hagahai":
                    return "pnn";
                case "pingelapese":
                    return "pif";
                case "pini":
                    return "pii";
                case "pinigura":
                    return "pnv";
                case "pinji":
                    return "pic";
                case "pinotepa nacional mixtec":
                    return "mio";
                case "pintiini":
                    return "pti";
                case "pintupi-luritja":
                    return "piu";
                case "pinyin":
                    return "pny";
                case "pipil":
                    return "ppl";
                case "pirahã":
                    return "myp";
                case "piratapuyo":
                    return "pir";
                case "pirlatapa":
                    return "bxi";
                case "piro":
                    return "pie";
                case "piru":
                    return "ppr";
                case "pisabo":
                    return "pig";
                case "pisaflores tepehua":
                    return "tpp";
                case "piscataway":
                    return "psy";
                case "pisidian":
                    return "xps";
                case "pitcairn-norfolk":
                    return "pih";
                case "pite sami":
                    return "sje";
                case "piti":
                    return "pcn";
                case "pitjantjatjara":
                    return "pjt";
                case "pitta pitta":
                    return "pit";
                case "piu":
                    return "pix";
                case "piya-kwonci":
                    return "piy";
                case "plains cree":
                    return "crk";
                case "plains miwok":
                    return "pmw";
                case "plapo krumen":
                    return "ktj";
                case "plateau malagasy":
                    return "plt";
                case "plautdietsch":
                    return "pdt";
                case "playero":
                    return "gob";
                case "pnar":
                    return "pbv";
                case "pochuri naga":
                    return "npo";
                case "pochutec":
                    return "xpo";
                case "pogolo":
                    return "poy";
                case "pohnpeian":
                    return "pon";
                case "pokangá":
                    return "pok";
                case "poke":
                    return "pof";
                case "pökoot":
                    return "pko";
                case "polabian":
                    return "pox";
                case "polari":
                    return "pld";
                case "polci":
                    return "plj";
                case "polish":
                    return "pol";
                case "polonombauk":
                    return "plb";
                case "pom":
                    return "pmo";
                case "pomo":
                    return "pmm";
                case "ponam":
                    return "ncc";
                case "ponares":
                    return "pod";
                case "pongu":
                    return "png";
                case "pongyong":
                    return "pgy";
                case "ponosakan":
                    return "pns";
                case "pontic":
                    return "pnt";
                case "porohanon":
                    return "prh";
                case "port sandwich":
                    return "psw";
                case "port vato":
                    return "ptv";
                case "portuguese":
                    return "por";
                case "potawatomi":
                    return "pot";
                case "potiguára":
                    return "pog";
                case "pottangi ollar gadaba":
                    return "gdb";
                case "poumei naga":
                    return "pmx";
                case "pouye":
                    return "bye";
                case "powari":
                    return "pwr";
                case "powhatan":
                    return "pim";
                case "poyanáwa":
                    return "pyn";
                case "prasuni":
                    return "prn";
                case "pray 3":
                    return "pry";
                case "principense":
                    return "pre";
                case "prussian":
                    return "prg";
                case "psikye":
                    return "kvj";
                case "pu ko":
                    return "puk";
                case "puari":
                    return "pux";
                case "pudtol atta":
                    return "atp";
                case "puelche":
                    return "pue";
                case "puimei naga":
                    return "npu";
                case "puinave":
                    return "pui";
                case "pukapuka":
                    return "pkp";
                case "pulaar":
                    return "fuc";
                case "pulabu":
                    return "pup";
                case "pular":
                    return "fuf";
                case "puluwatese":
                    return "puw";
                case "puma":
                    return "pum";
                case "pumé":
                    return "yae";
                case "pumpokol":
                    return "xpm";
                case "punan aput":
                    return "pud";
                case "punan bah-biau":
                    return "pna";
                case "punan batu 1":
                    return "pnm";
                case "punan merah":
                    return "puf";
                case "punan merap":
                    return "puc";
                case "punan tubu":
                    return "puj";
                case "punic":
                    return "xpu";
                case "puno quechua":
                    return "qxp";
                case "punu":
                    return "puu";
                case "puoc":
                    return "puo";
                case "puquina":
                    return "puq";
                case "puragi":
                    return "pru";
                case "purari":
                    return "iar";
                case "purepecha":
                    return "tsz";
                case "puri":
                    return "prr";
                case "purik":
                    return "prx";
                case "purisimeño":
                    return "puy";
                case "puruborá":
                    return "pur";
                case "purum":
                    return "pub";
                case "purum naga":
                    return "puz";
                case "putai":
                    return "mfl";
                case "putoh":
                    return "put";
                case "putukwam":
                    return "afe";
                case "pu-xian chinese":
                    return "cpx";
                case "puyo":
                    return "xpy";
                case "puyo-paekche":
                    return "xpp";
                case "puyuma":
                    return "pyu";
                case "pwaamei":
                    return "pme";
                case "pwapwa":
                    return "pop";
                case "pwo eastern karen":
                    return "kjp";
                case "pwo northern karen":
                    return "pww";
                case "pwo western karen":
                    return "pwo";
                case "pyapun":
                    return "pcw";
                case "pye krumen":
                    return "pye";
                case "pyen":
                    return "pyy";
                case "pyu":
                    return "pby";
                case "qabiao":
                    return "laq";
                case "qaqet":
                    return "byx";
                case "qashqa'i":
                    return "qxq";
                case "qatabanian":
                    return "xqt";
                case "qawasqar":
                    return "alc";
                case "qila muji":
                    return "ymq";
                case "qimant":
                    return "ahg";
                case "qiubei zhuang":
                    return "zqe";
                case "quapaw":
                    return "qua";
                case "quechan":
                    return "yum";
                case "quechua":
                    return "que";
                case "quenya":
                    return "qya";
                case "querétaro otomi":
                    return "otq";
                case "quetzaltepec mixe":
                    return "pxm";
                case "queyu":
                    return "qvy";
                case "quiavicuzas zapotec":
                    return "zpj";
                case "quileute":
                    return "qui";
                case "quinault":
                    return "qun";
                case "quinqui":
                    return "quq";
                case "quioquitani-quierí zapotec":
                    return "ztq";
                case "quiotepec chinantec":
                    return "chq";
                case "rabha":
                    return "rah";
                case "rabinal achí":
                    return "acr";
                case "rade":
                    return "rad";
                case "raetic":
                    return "xrr";
                case "rahambuu":
                    return "raz";
                case "rajah kabunsuwan manobo":
                    return "mqk";
                case "rajasthani":
                    return "raj";
                case "rajbanshi":
                    return "rjs";
                case "raji":
                    return "rji";
                case "rajong":
                    return "rjg";
                case "rajput garasia":
                    return "gra";
                case "rakahanga-manihiki":
                    return "rkh";
                case "rakhine":
                    return "rki";
                case "ralte":
                    return "ral";
                case "rama":
                    return "rma";
                case "ramoaaina":
                    return "rai";
                case "ramopa":
                    return "kjx";
                case "rampi":
                    return "lje";
                case "rana tharu":
                    return "thr";
                case "rang":
                    return "rax";
                case "rangkas":
                    return "rgk";
                case "ranglong":
                    return "rnl";
                case "rao":
                    return "rao";
                case "rapa":
                    return "ray";
                case "rapanui":
                    return "rap";
                case "rapoisi":
                    return "kyx";
                case "rapting":
                    return "rpt";
                case "rara bakati'":
                    return "lra";
                case "rasawa":
                    return "rac";
                case "ratagnon":
                    return "btn";
                case "ratahan":
                    return "rth";
                case "rathawi":
                    return "rtw";
                case "rathwi bareli":
                    return "bgd";
                case "raute":
                    return "rau";
                case "ravula":
                    return "yea";
                case "rawa":
                    return "rwo";
                case "rawang":
                    return "raw";
                case "rawat":
                    return "jnl";
                case "rawo":
                    return "rwa";
                case "rayón zoque":
                    return "zor";
                case "razajerdi":
                    return "rat";
                case "red gelao":
                    return "gir";
                case "reel":
                    return "atu";
                case "rejang":
                    return "rej";
                case "rejang kayan":
                    return "ree";
                case "reli":
                    return "rei";
                case "rema":
                    return "bow";
                case "rembarunga":
                    return "rmb";
                case "rembong":
                    return "reb";
                case "remo":
                    return "rem";
                case "remontado agta":
                    return "agv";
                case "rempi":
                    return "rmp";
                case "remun":
                    return "lkj";
                case "rendille":
                    return "rel";
                case "rengao":
                    return "ren";
                case "rennell-belona":
                    return "mnv";
                case "repanbitip":
                    return "rpn";
                case "rer bare":
                    return "rer";
                case "rerau":
                    return "rea";
                case "rerep":
                    return "pgk";
                case "reshe":
                    return "res";
                case "resígaro":
                    return "rgr";
                case "retta":
                    return "ret";
                case "réunion creole french":
                    return "rcf";
                case "reyesano":
                    return "rey";
                case "riang":
                    return "ria";
                case "riantana":
                    return "ran";
                case "ribun":
                    return "rir";
                case "rien":
                    return "rie";
                case "rikbaktsa":
                    return "rkb";
                case "rincón zapotec":
                    return "zar";
                case "ringgou":
                    return "rgu";
                case "ririo":
                    return "rri";
                case "ritarungo":
                    return "rit";
                case "riung":
                    return "riu";
                case "riverain sango":
                    return "snj";
                case "rogo":
                    return "rod";
                case "rohingya":
                    return "rhg";
                case "roma":
                    return "rmm";
                case "romam":
                    return "rmx";
                case "romanian":
                    return "ron";
                case "romano-greek":
                    return "rge";
                case "romano-serbian":
                    return "rsb";
                case "romanova":
                    return "rmv";
                case "romansh":
                    return "roh";
                case "romany":
                    return "rom";
                case "romblomanon":
                    return "rol";
                case "rombo":
                    return "rof";
                case "romkun":
                    return "rmk";
                case "ron":
                    return "cla";
                case "ronga":
                    return "rng";
                case "rongga":
                    return "ror";
                case "rongmei naga":
                    return "nbu";
                case "rongpo":
                    return "rnp";
                case "ronji":
                    return "roe";
                case "roon":
                    return "rnn";
                case "roria":
                    return "rga";
                case "rotokas":
                    return "roo";
                case "rotuman":
                    return "rtm";
                case "roviana":
                    return "rug";
                case "rudbari":
                    return "rdb";
                case "rufiji":
                    return "rui";
                case "ruga":
                    return "ruh";
                case "rukai":
                    return "dru";
                case "ruma":
                    return "ruz";
                case "rumai palaung":
                    return "rbb";
                case "rumu":
                    return "klq";
                case "runa":
                    return "rna";
                case "rundi":
                    return "run";
                case "runga":
                    return "rou";
                case "rungus":
                    return "drg";
                case "rungwa":
                    return "rnw";
                case "russia buriat":
                    return "bxr";
                case "russian":
                    return "rus";
                case "rusyn":
                    return "rue";
                case "rutul":
                    return "rut";
                case "ruuli":
                    return "ruc";
                case "ruund":
                    return "rnd";
                case "rwa":
                    return "rwk";
                case "sa":
                    return "sax";
                case "sa'a":
                    return "apb";
                case "saafi-saafi":
                    return "sav";
                case "saam":
                    return "raq";
                case "saaroa":
                    return "sxr";
                case "saba":
                    return "saa";
                case "sabaean":
                    return "xsa";
                case "sabah bisaya":
                    return "bsy";
                case "sabah malay":
                    return "msi";
                case "sa'ban":
                    return "snv";
                case "sabanês":
                    return "sae";
                case "sabaot":
                    return "spy";
                case "sabine":
                    return "sbv";
                case "sabu":
                    return "hvn";
                case "sabüm":
                    return "sbo";
                case "sacapulteco":
                    return "quv";
                case "sadri":
                    return "sck";
                case "saek":
                    return "skb";
                case "saep":
                    return "spd";
                case "safaliba":
                    return "saf";
                case "safeyoka":
                    return "apz";
                case "safwa":
                    return "sbk";
                case "sagala":
                    return "sbm";
                case "sagalla":
                    return "tga";
                case "saho":
                    return "ssy";
                case "sahu":
                    return "saj";
                case "saidi arabic":
                    return "aec";
                case "saint lucian creole french":
                    return "acf";
                case "saisiyat":
                    return "xsy";
                case "sajau basap":
                    return "sjb";
                case "sakachep":
                    return "sch";
                case "sakalava malagasy":
                    return "skg";
                case "sakam":
                    return "skm";
                case "sakan":
                    return "xsk";
                case "sakao":
                    return "sku";
                case "sakata":
                    return "skt";
                case "sake":
                    return "sak";
                case "sakirabiá":
                    return "skf";
                case "sala":
                    return "shq";
                case "salampasu":
                    return "slx";
                case "salar":
                    return "slr";
                case "salas":
                    return "sgu";
                case "salasaca highland quichua":
                    return "qxl";
                case "salchuq":
                    return "slq";
                case "saleman":
                    return "sau";
                case "saliba":
                    return "sbe";
                case "sáliba":
                    return "slc";
                case "salinan":
                    return "sln";
                case "sallands":
                    return "sdz";
                case "salt-yui":
                    return "sll";
                case "saluan":
                    return "loe";
                case "salumá":
                    return "slj";
                case "sam":
                    return "snx";
                case "sama":
                    return "smd";
                case "samaritan":
                    return "smp";
                case "samaritan aramaic":
                    return "sam";
                case "samarokena":
                    return "tmj";
                case "samatao":
                    return "ysd";
                case "samba":
                    return "smx";
                case "samba daka":
                    return "ccg";
                case "samba leko":
                    return "ndi";
                case "sambe":
                    return "xab";
                case "samberigi":
                    return "ssx";
                case "samburu":
                    return "saq";
                case "samei":
                    return "smh";
                case "samo":
                    return "smq";
                case "samoan":
                    return "smo";
                case "samosa":
                    return "swm";
                case "sampang":
                    return "rav";
                case "samre":
                    return "sxm";
                case "samtao":
                    return "stu";
                case "samvedi":
                    return "smv";
                case "san agustín mixtepec zapotec":
                    return "ztm";
                case "san andrés larrainzar tzotzil":
                    return "tzs";
                case "san andrés quiché":
                    return "qxi";
                case "san baltazar loxicha zapotec":
                    return "zpx";
                case "san blas kuna":
                    return "cuk";
                case "san dionisio del mar huave":
                    return "hve";
                case "san felipe otlaltepec popoloca":
                    return "pow";
                case "san francisco del mar huave":
                    return "hue";
                case "san francisco matlatzinca":
                    return "mat";
                case "san jerónimo tecóatl mazatec":
                    return "maa";
                case "san juan atzingo popoloca":
                    return "poe";
                case "san juan colorado mixtec":
                    return "mjc";
                case "san juan cotzal ixil":
                    return "ixl";
                case "san juan guelavía zapotec":
                    return "zab";
                case "san juan teita mixtec":
                    return "xtj";
                case "san luís potosí huastec":
                    return "hva";
                case "san luís temalacayuca popoloca":
                    return "pps";
                case "san marcos tlalcoyalco popoloca":
                    return "pls";
                case "san martín itunyoso triqui":
                    return "trq";
                case "san martín quechua":
                    return "qvs";
                case "san mateo del mar huave":
                    return "huv";
                case "san miguel creole french":
                    return "scf";
                case "san miguel el grande mixtec":
                    return "mig";
                case "san miguel piedras mixtec":
                    return "xtp";
                case "san pedro amuzgos amuzgo":
                    return "azg";
                case "san pedro quiatoni zapotec":
                    return "zpf";
                case "san salvador kongo":
                    return "kwy";
                case "san sebastián coatán chuj":
                    return "cac";
                case "san vicente coatlán zapotec":
                    return "zpt";
                case "sanaani arabic":
                    return "ayn";
                case "sanapaná":
                    return "sap";
                case "sandawe":
                    return "sad";
                case "sanga":
                    return "sng";
                case "sangab mandaya":
                    return "myt";
                case "sanggau":
                    return "scg";
                case "sangil":
                    return "snl";
                case "sangir":
                    return "sxn";
                case "sangisari":
                    return "sgr";
                case "sangkong":
                    return "sgk";
                case "sanglechi-ishkashimi":
                    return "sgl";
                case "sango":
                    return "sag";
                case "sangtam naga":
                    return "nsa";
                case "sangu":
                    return "sbp";
                case "sani":
                    return "ysn";
                case "sanie":
                    return "ysy";
                case "saniyo-hiyewe":
                    return "sny";
                case "sankaran maninka":
                    return "msc";
                case "sansi":
                    return "ssi";
                case "sanskrit":
                    return "san";
                case "sansu":
                    return "sca";
                case "santa ana de tusi pasco quechua":
                    return "qxt";
                case "santa catarina albarradas zapotec":
                    return "ztn";
                case "santa cruz":
                    return "stc";
                case "santa inés ahuatempan popoloca":
                    return "pca";
                case "santa inés yatzechi zapotec":
                    return "zpn";
                case "santa lucía monteverde mixtec":
                    return "mdv";
                case "santa maría de jesús cakchiquel":
                    return "cki";
                case "santa maría del mar huave":
                    return "hvv";
                case "santa maría la alta nahuatl":
                    return "nhz";
                case "santa maría quiegolani zapotec":
                    return "zpi";
                case "santa maría zacatepec mixtec":
                    return "mza";
                case "santa teresa cora":
                    return "cok";
                case "santali":
                    return "sat";
                case "santiago del estero quichua":
                    return "qus";
                case "santiago xanica zapotec":
                    return "zpr";
                case "santo domingo albarradas zapotec":
                    return "zas";
                case "santo domingo xenacoj cakchiquel":
                    return "ckj";
                case "sanumá":
                    return "xsu";
                case "são paulo kaingáng":
                    return "zkp";
                case "sa'och":
                    return "scq";
                case "sãotomense":
                    return "cri";
                case "saparua":
                    return "spr";
                case "sapé":
                    return "spc";
                case "sapo":
                    return "krn";
                case "saponi":
                    return "spi";
                case "saposa":
                    return "sps";
                case "sapuan":
                    return "spu";
                case "sar":
                    return "mwm";
                case "sara":
                    return "sre";
                case "sara dunjo":
                    return "koj";
                case "sara kaba":
                    return "sbz";
                case "sara kaba deme":
                    return "kwg";
                case "sara kaba náà":
                    return "kwv";
                case "saramaccan":
                    return "srm";
                case "sarangani blaan":
                    return "bps";
                case "sarangani manobo":
                    return "mbs";
                case "sarasira":
                    return "zsa";
                case "saraveca":
                    return "sar";
                case "sardinian":
                    return "srd";
                case "sarikoli":
                    return "srh";
                case "sarli":
                    return "sdf";
                case "sarsi":
                    return "srs";
                case "sartang":
                    return "onp";
                case "sarua":
                    return "swy";
                case "sarudu":
                    return "sdu";
                case "saruga":
                    return "sra";
                case "sasak":
                    return "sas";
                case "sasaru":
                    return "sxs";
                case "sassarese sardinian":
                    return "sdc";
                case "satawalese":
                    return "stw";
                case "sateré-mawé":
                    return "mav";
                case "saterfriesisch":
                    return "stq";
                case "sauk":
                    return "skc";
                case "sauraseni prākrit":
                    return "psu";
                case "saurashtra":
                    return "saz";
                case "sauri":
                    return "srt";
                case "sauria paharia":
                    return "mjt";
                case "sause":
                    return "sao";
                case "sausi":
                    return "ssj";
                case "savara":
                    return "svr";
                case "savi":
                    return "sdg";
                case "savosavo":
                    return "svs";
                case "sawai":
                    return "szw";
                case "saweru":
                    return "swr";
                case "sawi":
                    return "saw";
                case "sawila":
                    return "swt";
                case "sawknah":
                    return "swn";
                case "saxwe gbe":
                    return "sxw";
                case "saya":
                    return "say";
                case "sayula popoluca":
                    return "pos";
                case "scots":
                    return "sco";
                case "scythian":
                    return "xsc";
                case "sea island creole english":
                    return "gul";
                case "seba":
                    return "kdg";
                case "sebat bet gurage":
                    return "sgw";
                case "seberuang":
                    return "sbx";
                case "sebop":
                    return "sib";
                case "sebuyau":
                    return "snb";
                case "sechelt":
                    return "sec";
                case "secoya":
                    return "sey";
                case "sedang":
                    return "sed";
                case "sedoa":
                    return "tvw";
                case "seeku":
                    return "sos";
                case "segai":
                    return "sge";
                case "segeju":
                    return "seg";
                case "seget":
                    return "sbg";
                case "sehwi":
                    return "sfw";
                case "seimat":
                    return "ssg";
                case "seit-kaitetu":
                    return "hik";
                case "sekani":
                    return "sek";
                case "sekapan":
                    return "skp";
                case "sekar":
                    return "skz";
                case "seke":
                    return "ske";
                case "seki":
                    return "syi";
                case "seko padang":
                    return "skx";
                case "seko tengah":
                    return "sko";
                case "sekpele":
                    return "lip";
                case "selaru":
                    return "slu";
                case "selayar":
                    return "sly";
                case "selee":
                    return "snw";
                case "selepet":
                    return "spl";
                case "selian":
                    return "sxl";
                case "selkup":
                    return "sel";
                case "selungai murut":
                    return "slg";
                case "seluwasan":
                    return "sws";
                case "semai":
                    return "sea";
                case "semandang":
                    return "sdm";
                case "semaq beri":
                    return "szc";
                case "sembakung murut":
                    return "sbr";
                case "semelai":
                    return "sza";
                case "semimi":
                    return "etz";
                case "semnam":
                    return "ssm";
                case "semnani":
                    return "smy";
                case "sempan":
                    return "xse";
                case "sena":
                    return "seh";
                case "senara sénoufo":
                    return "seq";
                case "senaya":
                    return "syn";
                case "sene":
                    return "sej";
                case "seneca":
                    return "see";
                case "sened":
                    return "sds";
                case "sengele":
                    return "szg";
                case "senggi":
                    return "snu";
                case "sengo":
                    return "spk";
                case "sengseng":
                    return "ssz";
                case "senhaja de srair":
                    return "sjs";
                case "sensi":
                    return "sni";
                case "sentani":
                    return "set";
                case "senthang chin":
                    return "sez";
                case "sentinel":
                    return "std";
                case "sepa":
                    return "spb";
                case "sepedi":
                    return "nso";
                case "sepen":
                    return "spm";
                case "sepik iwam":
                    return "iws";
                case "sera":
                    return "sry";
                case "seraiki":
                    return "skr";
                case "serbian":
                    return "srp";
                case "serbo-croatian":
                    return "hbs";
                case "sere":
                    return "swf";
                case "serer":
                    return "srr";
                case "seri":
                    return "sei";
                case "serili":
                    return "sve";
                case "seroa":
                    return "kqu";
                case "serrano":
                    return "ser";
                case "seru":
                    return "szd";
                case "serua":
                    return "srw";
                case "serudung murut":
                    return "srk";
                case "serui-laut":
                    return "seu";
                case "seselwa creole french":
                    return "crs";
                case "seta":
                    return "stf";
                case "setaman":
                    return "stm";
                case "seti":
                    return "sbi";
                case "settla":
                    return "sta";
                case "severn ojibwa":
                    return "ojs";
                case "sewa bay":
                    return "sew";
                case "seze":
                    return "sze";
                case "s'gaw karen":
                    return "ksw";
                case "sha":
                    return "scw";
                case "shabak":
                    return "sdb";
                case "shabo":
                    return "sbf";
                case "shahmirzadi":
                    return "srz";
                case "shahrudi":
                    return "shm";
                case "shakara":
                    return "nfk";
                case "shall-zwall":
                    return "sha";
                case "shamang":
                    return "xsh";
                case "shama-sambuga":
                    return "sqa";
                case "shambala":
                    return "ksb";
                case "shan":
                    return "shn";
                case "shanenawa":
                    return "swo";
                case "shanga":
                    return "sho";
                case "shangzhai":
                    return "jih";
                case "sharanahua":
                    return "mcd";
                case "shark bay":
                    return "ssv";
                case "sharwa":
                    return "swq";
                case "shasta":
                    return "sht";
                case "shatt":
                    return "shj";
                case "shau":
                    return "sqh";
                case "shawnee":
                    return "sjw";
                case "she":
                    return "shx";
                case "shehri":
                    return "shv";
                case "shekhawati":
                    return "swv";
                case "shekkacho":
                    return "moy";
                case "sheko":
                    return "she";
                case "shelta":
                    return "sth";
                case "shempire senoufo":
                    return "seb";
                case "shendu":
                    return "shl";
                case "sheni":
                    return "scv";
                case "sherbro":
                    return "bun";
                case "sherdukpen":
                    return "sdp";
                case "sherpa":
                    return "xsr";
                case "sheshi kham":
                    return "kip";
                case "shi":
                    return "shr";
                case "shihhi arabic":
                    return "ssh";
                case "shiki":
                    return "gua";
                case "shilluk":
                    return "shk";
                case "shina":
                    return "scl";
                case "shinabo":
                    return "snh";
                case "shipibo-conibo":
                    return "shp";
                case "shixing":
                    return "sxg";
                case "sholaga":
                    return "sle";
                case "shom peng":
                    return "sii";
                case "shona":
                    return "sna";
                case "shoo-minda-nye":
                    return "bcv";
                case "shor":
                    return "cjs";
                case "shoshoni":
                    return "shh";
                case "shua":
                    return "shg";
                case "shuadit":
                    return "sdt";
                case "shuar":
                    return "jiv";
                case "shubi":
                    return "suj";
                case "shughni":
                    return "sgh";
                case "shumashti":
                    return "sts";
                case "shumcho":
                    return "scu";
                case "shuswap":
                    return "shs";
                case "shuwa-zamani":
                    return "ksa";
                case "shwai":
                    return "shw";
                case "shwe palaung":
                    return "pll";
                case "sialum":
                    return "slw";
                case "siamou":
                    return "sif";
                case "sian":
                    return "spg";
                case "siane":
                    return "snp";
                case "siang":
                    return "sya";
                case "siar-lak":
                    return "sjr";
                case "siawi":
                    return "mmp";
                case "sibe":
                    return "nco";
                case "sibu melanau":
                    return "sdx";
                case "sicanian":
                    return "sxc";
                case "sicel":
                    return "scx";
                case "sicilian":
                    return "scn";
                case "sìcìté sénoufo":
                    return "sep";
                case "sidamo":
                    return "sid";
                case "sidetic":
                    return "xsd";
                case "sie":
                    return "erg";
                case "sierra de juárez zapotec":
                    return "zaa";
                case "sierra negra nahuatl":
                    return "nsu";
                case "sighu":
                    return "sxe";
                case "sihan":
                    return "snr";
                case "sihuas ancash quechua":
                    return "qws";
                case "sika":
                    return "ski";
                case "sikaiana":
                    return "sky";
                case "sikaritai":
                    return "tty";
                case "sikiana":
                    return "sik";
                case "sikkimese":
                    return "sip";
                case "siksika":
                    return "bla";
                case "sikule":
                    return "skh";
                case "sila":
                    return "slt";
                case "silacayoapan mixtec":
                    return "mks";
                case "sileibi":
                    return "sbq";
                case "silesian":
                    return "szl";
                case "silimo":
                    return "wul";
                case "siliput":
                    return "mkc";
                case "silopi":
                    return "xsp";
                case "silt'e":
                    return "stv";
                case "simaa":
                    return "sie";
                case "simba":
                    return "sbw";
                case "simbali":
                    return "smg";
                case "simbari":
                    return "smb";
                case "simbo":
                    return "sbb";
                case "simeku":
                    return "smz";
                case "simeulue":
                    return "smr";
                case "simte":
                    return "smt";
                case "sinagen":
                    return "siu";
                case "sinasina":
                    return "sst";
                case "sinaugoro":
                    return "snc";
                case "sindarin":
                    return "sjn";
                case "sindhi":
                    return "snd";
                case "sindhi bhil":
                    return "sbn";
                case "sindihui mixtec":
                    return "xts";
                case "singa":
                    return "sgm";
                case "singpho":
                    return "sgp";
                case "sinhala":
                    return "sin";
                case "sinicahua mixtec":
                    return "xti";
                case "sininkere":
                    return "skq";
                case "sinsauru":
                    return "snz";
                case "sinte romani":
                    return "rmo";
                case "sinyar":
                    return "sys";
                case "sio":
                    return "xsi";
                case "siona":
                    return "snn";
                case "sipacapense":
                    return "qum";
                case "sira":
                    return "swj";
                case "siraya":
                    return "fos";
                case "sirenik yupik":
                    return "ysr";
                case "siri":
                    return "sir";
                case "siriano":
                    return "sri";
                case "sirionó":
                    return "srq";
                case "sirmauri":
                    return "srx";
                case "siroi":
                    return "ssd";
                case "sissala":
                    return "sld";
                case "sissano":
                    return "sso";
                case "siuslaw":
                    return "sis";
                case "sivandi":
                    return "siy";
                case "siwai":
                    return "siw";
                case "siwi":
                    return "siz";
                case "siwu":
                    return "akp";
                case "siyin chin":
                    return "csy";
                case "skagit":
                    return "ska";
                case "skalvian":
                    return "svx";
                case "skepi creole dutch":
                    return "skw";
                case "skolt sami":
                    return "sms";
                case "skou":
                    return "skv";
                case "slave":
                    return "den";
                case "slovak":
                    return "slk";
                case "slovenian":
                    return "slv";
                case "small flowery miao":
                    return "sfm";
                case "smärky kanum":
                    return "kxq";
                case "snohomish":
                    return "sno";
                case "so":
                    return "soc";
                case "sô":
                    return "sss";
                case "so'a":
                    return "ssq";
                case "sobei":
                    return "sob";
                case "sochiapam chinantec":
                    return "cso";
                case "soga":
                    return "xog";
                case "sogdian":
                    return "sog";
                case "soi":
                    return "soj";
                case "sok":
                    return "skk";
                case "sokoro":
                    return "sok";
                case "solano":
                    return "xso";
                case "soli":
                    return "sby";
                case "solong":
                    return "aaw";
                case "solos":
                    return "sol";
                case "som":
                    return "smc";
                case "somali":
                    return "som";
                case "somrai":
                    return "sor";
                case "somray":
                    return "smu";
                case "somyev":
                    return "kgt";
                case "sonde":
                    return "shc";
                case "songa":
                    return "sgo";
                case "songe":
                    return "sop";
                case "songo":
                    return "soo";
                case "songomeno":
                    return "soe";
                case "songoora":
                    return "sod";
                case "sonha":
                    return "soi";
                case "sonia":
                    return "siq";
                case "soninke":
                    return "snk";
                case "sonsorol":
                    return "sov";
                case "soo":
                    return "teu";
                case "sop":
                    return "urw";
                case "soqotri":
                    return "sqt";
                case "sora":
                    return "srb";
                case "sori-harengan":
                    return "sbh";
                case "sorkhei":
                    return "sqo";
                case "sorothaptic":
                    return "sxo";
                case "sorsogon ayta":
                    return "ays";
                case "sota kanum":
                    return "krz";
                case "sou":
                    return "sqq";
                case "south awyu":
                    return "aws";
                case "south azerbaijani":
                    return "azb";
                case "south bolivian quechua":
                    return "quh";
                case "south central banda":
                    return "lnl";
                case "south central cakchiquel":
                    return "ckd";
                case "south central dinka":
                    return "dib";
                case "south efate":
                    return "erk";
                case "south fali":
                    return "fal";
                case "south giziga":
                    return "giz";
                case "south lembata":
                    return "lmf";
                case "south levantine arabic":
                    return "ajp";
                case "south marquesan":
                    return "mqm";
                case "south muyu":
                    return "kts";
                case "south ndebele":
                    return "nbl";
                case "south nuaulu":
                    return "nxl";
                case "south picene":
                    return "spx";
                case "south slavey":
                    return "xsl";
                case "south tairora":
                    return "omw";
                case "south ucayali ashéninka":
                    return "cpy";
                case "south watut":
                    return "mcy";
                case "south wemale":
                    return "tlw";
                case "south west bay":
                    return "sns";
                case "southeast ambrym":
                    return "tvk";
                case "southeast babar":
                    return "vbb";
                case "southeast ijo":
                    return "ijs";
                case "southeast pashayi":
                    return "psi";
                case "southeastern dinka":
                    return "dks";
                case "southeastern huastec":
                    return "hsf";
                case "southeastern ixtlán zapotec":
                    return "zpd";
                case "southeastern kolami":
                    return "nit";
                case "southeastern nochixtlán mixtec":
                    return "mxy";
                case "southeastern pomo":
                    return "pom";
                case "southeastern puebla nahuatl":
                    return "npl";
                case "southeastern tarahumara":
                    return "tcu";
                case "southeastern tepehuan":
                    return "stp";
                case "southern alta":
                    return "agy";
                case "southern altai":
                    return "alt";
                case "southern amami-oshima":
                    return "ams";
                case "southern aymara":
                    return "ayc";
                case "southern bai":
                    return "bfs";
                case "southern balochi":
                    return "bcc";
                case "southern betsimisaraka malagasy":
                    return "bjq";
                case "southern birifor":
                    return "biv";
                case "southern bobo madaré":
                    return "bwq";
                case "southern cakchiquel":
                    return "ckf";
                case "southern carrier":
                    return "caf";
                case "southern catanduanes bicolano":
                    return "bln";
                case "southern conchucos ancash quechua":
                    return "qxo";
                case "southern dagaare":
                    return "dga";
                case "southern dong":
                    return "kmc";
                case "southern east cree":
                    return "crj";
                case "southern ghale":
                    return "ghe";
                case "southern gondi":
                    return "ggo";
                case "southern grebo":
                    return "grj";
                case "southern guiyang hmong":
                    return "hmy";
                case "southern haida":
                    return "hax";
                case "southern hindko":
                    return "hnd";
                case "southern kalapuya":
                    return "sxk";
                case "southern kalinga":
                    return "ksc";
                case "southern kisi":
                    return "kss";
                case "southern kiwai":
                    return "kjd";
                case "southern kurdish":
                    return "sdh";
                case "southern lolopo":
                    return "ysp";
                case "southern lorung":
                    return "lrr";
                case "southern luri":
                    return "luz";
                case "southern ma'di":
                    return "snm";
                case "southern mam":
                    return "mms";
                case "southern mashan hmong":
                    return "hma";
                case "southern mnong":
                    return "mnn";
                case "southern muji":
                    return "ymc";
                case "southern nambikuára":
                    return "nab";
                case "southern ngbandi":
                    return "nbw";
                case "southern nicobarese":
                    return "nik";
                case "southern nisu":
                    return "nsd";
                case "southern nuni":
                    return "nnw";
                case "southern ohlone":
                    return "css";
                case "southern one":
                    return "osu";
                case "southern pame":
                    return "pmz";
                case "southern pashto":
                    return "pbt";
                case "southern pastaza quechua":
                    return "qup";
                case "southern pokomam":
                    return "pou";
                case "southern pomo":
                    return "peq";
                case "southern puebla mixtec":
                    return "mit";
                case "southern puget sound salish":
                    return "slh";
                case "southern pumi":
                    return "pmj";
                case "southern qiandong miao":
                    return "hms";
                case "southern qiang":
                    return "qxs";
                case "southern rengma naga":
                    return "nre";
                case "southern rincon zapotec":
                    return "zsr";
                case "southern roglai":
                    return "rgs";
                case "southern sama":
                    return "ssb";
                case "southern sami":
                    return "sma";
                case "southern samo":
                    return "sbd";
                case "southern sierra miwok":
                    return "skd";
                case "southern sotho":
                    return "sot";
                case "southern thai":
                    return "sou";
                case "southern tiwa":
                    return "tix";
                case "southern toussian":
                    return "wib";
                case "southern tujia":
                    return "tjs";
                case "southern tutchone":
                    return "tce";
                case "southern uzbek":
                    return "uzs";
                case "southern yukaghir":
                    return "yux";
                case "southwest gbaya":
                    return "gso";
                case "southwest palawano":
                    return "plv";
                case "southwest pashayi":
                    return "psh";
                case "southwest tanna":
                    return "nwi";
                case "southwestern dinka":
                    return "dik";
                case "southwestern fars":
                    return "fay";
                case "southwestern guiyang hmong":
                    return "hmg";
                case "southwestern huishui hmong":
                    return "hmh";
                case "southwestern nisu":
                    return "nsv";
                case "southwestern tamang":
                    return "tsf";
                case "southwestern tarahumara":
                    return "twr";
                case "southwestern tepehuan":
                    return "tla";
                case "southwestern tlaxiaco mixtec":
                    return "meh";
                case "sowa":
                    return "sww";
                case "sowanda":
                    return "sow";
                case "soyaltepec mazatec":
                    return "vmp";
                case "soyaltepec mixtec":
                    return "vmq";
                case "spanish":
                    return "spa";
                case "spiti bhoti":
                    return "spt";
                case "spokane":
                    return "spo";
                case "squamish":
                    return "squ";
                case "sranan tongo":
                    return "srn";
                case "sri lankan creole malay":
                    return "sci";
                case "standard arabic":
                    return "arb";
                case "standard malay":
                    return "zsm";
                case "stellingwerfs":
                    return "stl";
                case "stod bhoti":
                    return "sbu";
                case "stoney":
                    return "sto";
                case "straits salish":
                    return "str";
                case "suabo":
                    return "szp";
                case "suarmin":
                    return "seo";
                case "suau":
                    return "swp";
                case "suba":
                    return "sxb";
                case "suba-simbiti":
                    return "ssc";
                case "subi":
                    return "xsj";
                case "subiya":
                    return "sbs";
                case "subtiaba":
                    return "sut";
                case "sudanese arabic":
                    return "apd";
                case "sudanese creole arabic":
                    return "pga";
                case "sudest":
                    return "tgo";
                case "sudovian":
                    return "xsv";
                case "suena":
                    return "sue";
                case "suga":
                    return "sgi";
                case "suganga":
                    return "sug";
                case "sugut dusun":
                    return "kzs";
                case "sui":
                    return "swi";
                case "suki":
                    return "sui";
                case "suku":
                    return "sub";
                case "sukuma":
                    return "suk";
                case "sukur":
                    return "syk";
                case "sukurum":
                    return "zsu";
                case "sula":
                    return "szn";
                case "sulka":
                    return "sua";
                case "sulod":
                    return "srg";
                case "sulung":
                    return "suv";
                case "suma":
                    return "sqm";
                case "sumariup":
                    return "siv";
                case "sumau":
                    return "six";
                case "sumbawa":
                    return "smw";
                case "sumbwa":
                    return "suw";
                case "sumerian":
                    return "sux";
                case "sumi naga":
                    return "nsm";
                case "sumo-mayangna":
                    return "sum";
                case "sunam":
                    return "ssk";
                case "sundanese":
                    return "sun";
                case "sunum":
                    return "ymn";
                case "sunwar":
                    return "suz";
                case "suoy":
                    return "syo";
                case "supyire senoufo":
                    return "spp";
                case "sur":
                    return "tdl";
                case "surbakhal":
                    return "sbj";
                case "suri":
                    return "suq";
                case "surigaonon":
                    return "sul";
                case "surjapuri":
                    return "sjp";
                case "sursurunga":
                    return "sgz";
                case "suruahá":
                    return "swx";
                case "surubu":
                    return "sde";
                case "suruí":
                    return "sru";
                case "suruí do pará":
                    return "mdz";
                case "susquehannock":
                    return "sqn";
                case "susu":
                    return "sus";
                case "susuami":
                    return "ssu";
                case "suundi":
                    return "sdj";
                case "suwawa":
                    return "swu";
                case "suyá":
                    return "suy";
                case "svan":
                    return "sva";
                case "swabian":
                    return "swg";
                case "swahili":
                    return "swa";
                case "swampy cree":
                    return "csw";
                case "swati":
                    return "ssw";
                case "swedish":
                    return "swe";
                case "swiss german":
                    return "gsw";
                case "syenara senoufo":
                    return "shz";
                case "sylheti":
                    return "syl";
                case "syriac":
                    return "syr";
                case "taabwa":
                    return "tap";
                case "tabaa zapotec":
                    return "zat";
                case "tabaru":
                    return "tby";
                case "tabasco chontal":
                    return "chf";
                case "tabasco nahuatl":
                    return "nhc";
                case "tabasco zoque":
                    return "zoq";
                case "tabassaran":
                    return "tab";
                case "tabla":
                    return "tnm";
                case "tabo":
                    return "knv";
                case "tabriak":
                    return "tzx";
                case "tacahua mixtec":
                    return "xtt";
                case "tacana":
                    return "tna";
                case "tacanec":
                    return "mtz";
                case "tachawit":
                    return "shy";
                case "tachelhit":
                    return "shi";
                case "tadaksahak":
                    return "dsq";
                case "tadyawan":
                    return "tdy";
                case "tae'":
                    return "rob";
                case "tafi":
                    return "tcd";
                case "tagabawa":
                    return "bgs";
                case "tagakaulu kalagan":
                    return "klg";
                case "tagal murut":
                    return "mvv";
                case "tagalog":
                    return "tgl";
                case "tagargrent":
                    return "oua";
                case "tagbanwa":
                    return "tbw";
                case "tagbu":
                    return "tbm";
                case "tagdal":
                    return "tda";
                case "tagish":
                    return "tgx";
                case "tagoi":
                    return "tag";
                case "tagwana senoufo":
                    return "tgw";
                case "tahaggart tamahaq":
                    return "thv";
                case "tahitian":
                    return "tah";
                case "tahltan":
                    return "tht";
                case "tai":
                    return "taw";
                case "tai daeng":
                    return "tyr";
                case "tai dam":
                    return "blt";
                case "tai do":
                    return "tyj";
                case "tai dón":
                    return "twh";
                case "tai hang tong":
                    return "thc";
                case "tai hongjin":
                    return "tiz";
                case "tai loi":
                    return "tlq";
                case "tai long":
                    return "thi";
                case "tai mène":
                    return "tmp";
                case "tai nüa":
                    return "tdd";
                case "tai pao":
                    return "tpo";
                case "tai thanh":
                    return "tmm";
                case "tai ya":
                    return "cuu";
                case "taiap":
                    return "gpn";
                case "taikat":
                    return "aos";
                case "tainae":
                    return "ago";
                case "taino":
                    return "tnq";
                case "tairuma":
                    return "uar";
                case "ta'izzi-adeni arabic":
                    return "acq";
                case "taje":
                    return "pee";
                case "tajik":
                    return "tgk";
                case "tajiki arabic":
                    return "abh";
                case "tajio":
                    return "tdj";
                case "tajuasohn":
                    return "tja";
                case "tajumulco mam":
                    return "mpf";
                case "takelma":
                    return "tkm";
                case "takestani":
                    return "tks";
                case "takia":
                    return "tbc";
                case "takpa":
                    return "tkk";
                case "takua":
                    return "tkz";
                case "takuu":
                    return "nho";
                case "takwane":
                    return "tke";
                case "tal":
                    return "tal";
                case "tala":
                    return "tak";
                case "talaud":
                    return "tld";
                case "taliabu":
                    return "tlv";
                case "talieng":
                    return "tdf";
                case "talinga-bwisi":
                    return "tlj";
                case "talise":
                    return "tlr";
                case "talodi":
                    return "tlo";
                case "taloki":
                    return "tlk";
                case "talondo'":
                    return "tln";
                case "talu":
                    return "yta";
                case "talur":
                    return "ilw";
                case "talysh":
                    return "tly";
                case "tama":
                    return "ten";
                case "tamagario":
                    return "tcg";
                case "taman":
                    return "tmn";
                case "tamanaku":
                    return "tmz";
                case "tamashek":
                    return "tmh";
                case "tamasheq":
                    return "taq";
                case "tamazola mixtec":
                    return "vmx";
                case "tambas":
                    return "tdk";
                case "tambotalo":
                    return "tls";
                case "tambunan dusun":
                    return "kzt";
                case "tami":
                    return "tmy";
                case "tamil":
                    return "tam";
                case "tamki":
                    return "tax";
                case "tamnim citak":
                    return "tml";
                case "tampias lobu":
                    return "low";
                case "tampuan":
                    return "tpu";
                case "tampulma":
                    return "tpm";
                case "tanacross":
                    return "tcb";
                case "tanahmerah":
                    return "tcm";
                case "tanaina":
                    return "tfn";
                case "tanapag":
                    return "tpv";
                case "tandia":
                    return "tni";
                case "tandroy-mahafaly malagasy":
                    return "tdx";
                case "tanema":
                    return "tnx";
                case "tangale":
                    return "tan";
                case "tangchangya":
                    return "tnv";
                case "tangga":
                    return "tgg";
                case "tanggu":
                    return "tgu";
                case "tangkhul naga":
                    return "nmf";
                case "tangko":
                    return "tkx";
                case "tanglang":
                    return "ytl";
                case "tangoa":
                    return "tgp";
                case "tangshewi":
                    return "tnf";
                case "tanguat":
                    return "tbs";
                case "tangut":
                    return "txg";
                case "tanimbili":
                    return "tbe";
                case "tanimuca-retuarã":
                    return "tnc";
                case "tanjijili":
                    return "uji";
                case "tanosy malagasy":
                    return "txy";
                case "tapeba":
                    return "tbb";
                case "tapei":
                    return "afp";
                case "tapieté":
                    return "tpj";
                case "tapirapé":
                    return "taf";
                case "tarao naga":
                    return "tro";
                case "tareng":
                    return "tgr";
                case "tariana":
                    return "tae";
                case "tarifit":
                    return "rif";
                case "tarok":
                    return "yer";
                case "taroko":
                    return "trv";
                case "tarpia":
                    return "tpf";
                case "tartessian":
                    return "txr";
                case "tasawaq":
                    return "twq";
                case "tase naga":
                    return "nst";
                case "tasmanian":
                    return "xtz";
                case "tasmate":
                    return "tmt";
                case "tataltepec chatino":
                    return "cta";
                case "tatana":
                    return "txx";
                case "tatar":
                    return "tat";
                case "tatuyo":
                    return "tav";
                case "tauade":
                    return "ttd";
                case "taulil":
                    return "tuh";
                case "taungyo":
                    return "tco";
                case "taupota":
                    return "tpa";
                case "tause":
                    return "tad";
                case "taushiro":
                    return "trr";
                case "tausug":
                    return "tsg";
                case "tauya":
                    return "tya";
                case "taveta":
                    return "tvs";
                case "tavoyan":
                    return "tvn";
                case "tavringer romani":
                    return "rmu";
                case "tawala":
                    return "tbo";
                case "tawallammat tamajaq":
                    return "ttq";
                case "tawandê":
                    return "xtw";
                case "tawang monpa":
                    return "twm";
                case "tawara":
                    return "twl";
                case "tawoyan":
                    return "twy";
                case "tawr chin":
                    return "tcp";
                case "tày":
                    return "tyz";
                case "tay boi":
                    return "tas";
                case "tay khang":
                    return "tnu";
                case "tày sa pa":
                    return "tys";
                case "tày tac":
                    return "tyt";
                case "tayabas ayta":
                    return "ayy";
                case "tayart tamajeq":
                    return "thz";
                case "tayo":
                    return "cks";
                case "taznatit":
                    return "grr";
                case "tboli":
                    return "tbl";
                case "tchitchege":
                    return "tck";
                case "tchumbuli":
                    return "bqa";
                case "teanu":
                    return "tkw";
                case "tebul ure dogon":
                    return "dtu";
                case "tecpatlán totonac":
                    return "tcw";
                case "tedaga":
                    return "tuq";
                case "tedim chin":
                    return "ctd";
                case "tee":
                    return "tkq";
                case "téén":
                    return "lor";
                case "tefaro":
                    return "tfo";
                case "tegali":
                    return "ras";
                case "tehit":
                    return "kps";
                case "tehuelche":
                    return "teh";
                case "tejalapan zapotec":
                    return "ztt";
                case "teke-ebo":
                    return "ebo";
                case "teke-fuumu":
                    return "ifm";
                case "teke-kukuya":
                    return "kkw";
                case "teke-laali":
                    return "lli";
                case "teke-nzikou":
                    return "nzu";
                case "teke-tege":
                    return "teg";
                case "teke-tsaayi":
                    return "tyi";
                case "teke-tyee":
                    return "tyx";
                case "tektiteko":
                    return "ttc";
                case "tela-masbuar":
                    return "tvm";
                case "telefol":
                    return "tlf";
                case "telugu":
                    return "tel";
                case "teluti":
                    return "tlt";
                case "tem":
                    return "kdh";
                case "temacine tamazight":
                    return "tjo";
                case "temascaltepec nahuatl":
                    return "nhv";
                case "tembé":
                    return "tqb";
                case "tembo":
                    return "tbt";
                case "teme":
                    return "tdo";
                case "temein":
                    return "teq";
                case "temi":
                    return "soz";
                case "temiar":
                    return "tea";
                case "temoaya otomi":
                    return "ott";
                case "temoq":
                    return "tmo";
                case "tempasuk dusun":
                    return "tdu";
                case "temuan":
                    return "tmw";
                case "t'en":
                    return "tct";
                case "tena lowland quichua":
                    return "quw";
                case "tenango otomi":
                    return "otn";
                case "tene kan dogon":
                    return "dtk";
                case "tenggarong kutai malay":
                    return "vkt";
                case "tengger":
                    return "tes";
                case "tenharim":
                    return "pah";
                case "tenino":
                    return "tqn";
                case "tenis":
                    return "tns";
                case "tennet":
                    return "tex";
                case "teop":
                    return "tio";
                case "teor":
                    return "tev";
                case "tepecano":
                    return "tep";
                case "tepetotutla chinantec":
                    return "cnt";
                case "tepeuxila cuicatec":
                    return "cux";
                case "tepinapa chinantec":
                    return "cte";
                case "tepo krumen":
                    return "ted";
                case "ter sami":
                    return "sjt";
                case "tera":
                    return "ttr";
                case "terebu":
                    return "trb";
                case "terei":
                    return "buo";
                case "tereno":
                    return "ter";
                case "teressa":
                    return "tef";
                case "tereweng":
                    return "twg";
                case "teribe":
                    return "tfr";
                case "terik":
                    return "tec";
                case "termanu":
                    return "twu";
                case "ternate":
                    return "tft";
                case "ternateño":
                    return "tmg";
                case "tese":
                    return "keg";
                case "teshenawa":
                    return "twc";
                case "teso":
                    return "teo";
                case "tetela":
                    return "tll";
                case "tetelcingo nahuatl":
                    return "nhg";
                case "tetete":
                    return "teb";
                case "tetum":
                    return "tet";
                case "tetun dili":
                    return "tdt";
                case "te'un":
                    return "tve";
                case "teutila cuicatec":
                    return "cut";
                case "tewa":
                    return "tew";
                case "tewe":
                    return "twx";
                case "texcatepec otomi":
                    return "otx";
                case "texistepec popoluca":
                    return "poq";
                case "texmelucan zapotec":
                    return "zpz";
                case "tezoatlán mixtec":
                    return "mxb";
                case "tha":
                    return "thy";
                case "thachanadan":
                    return "thn";
                case "thado chin":
                    return "tcz";
                case "thai":
                    return "tha";
                case "thai song":
                    return "soa";
                case "thakali":
                    return "ths";
                case "thangal naga":
                    return "nki";
                case "thangmi":
                    return "thf";
                case "thao":
                    return "ssf";
                case "thayore":
                    return "thd";
                case "thaypan":
                    return "typ";
                case "the":
                    return "thx";
                case "tho":
                    return "tou";
                case "thompson":
                    return "thp";
                case "thopho":
                    return "ytp";
                case "thracian":
                    return "txh";
                case "thu lao":
                    return "tyl";
                case "thudam":
                    return "thw";
                case "thulung":
                    return "tdh";
                case "thurawal":
                    return "tbh";
                case "thuri":
                    return "thu";
                case "tiagbamrin aizi":
                    return "ahi";
                case "tiale":
                    return "mnl";
                case "tiang":
                    return "tbj";
                case "tibea":
                    return "ngy";
                case "tibetan":
                    return "bod";
                case "tichurong":
                    return "tcn";
                case "ticuna":
                    return "tca";
                case "tidaá mixtec":
                    return "mtx";
                case "tidikelt tamazight":
                    return "tia";
                case "tidong":
                    return "tid";
                case "tidore":
                    return "tvo";
                case "tiéfo":
                    return "tiq";
                case "tiemacèwè bozo":
                    return "boo";
                case "tiene":
                    return "tii";
                case "tiéyaxo bozo":
                    return "boz";
                case "tifal":
                    return "tif";
                case "tigak":
                    return "tgc";
                case "tigon mbembe":
                    return "nza";
                case "tigre":
                    return "tig";
                case "tigrinya":
                    return "tir";
                case "tii":
                    return "txq";
                case "tijaltepec mixtec":
                    return "xtl";
                case "tikar":
                    return "tik";
                case "tikopia":
                    return "tkp";
                case "tila chol":
                    return "cti";
                case "tilapa otomi":
                    return "otl";
                case "tillamook":
                    return "til";
                case "tilquiapan zapotec":
                    return "zts";
                case "tilung":
                    return "tij";
                case "tima":
                    return "tms";
                case "timbe":
                    return "tim";
                case "timne":
                    return "tem";
                case "timor pidgin":
                    return "tvy";
                case "timucua":
                    return "tjm";
                case "timugon murut":
                    return "tih";
                case "tinà sambal":
                    return "xsb";
                case "tinani":
                    return "lbf";
                case "tindi":
                    return "tin";
                case "tingal":
                    return "tie";
                case "tingui-boto":
                    return "tgv";
                case "tinigua":
                    return "tit";
                case "tinoc kallahan":
                    return "tne";
                case "tinputz":
                    return "tpz";
                case "tippera":
                    return "tpe";
                case "tira":
                    return "tic";
                case "tirahi":
                    return "tra";
                case "tiri":
                    return "cir";
                case "tiruray":
                    return "tiy";
                case "tita":
                    return "tdq";
                case "titan":
                    return "ttv";
                case "tiv":
                    return "tiv";
                case "tiwa":
                    return "lax";
                case "tiwi":
                    return "tiw";
                case "tjurruru":
                    return "tju";
                case "tlachichilco tepehua":
                    return "tpt";
                case "tlacoapa tlapanec":
                    return "tpl";
                case "tlacoatzintepec chinantec":
                    return "ctl";
                case "tlacolulita zapotec":
                    return "zpk";
                case "tlahuitoltepec mixe":
                    return "mxp";
                case "tlamacazapa nahuatl":
                    return "nuz";
                case "tlazoyaltepec mixtec":
                    return "mqh";
                case "tlingit":
                    return "tli";
                case "to":
                    return "toz";
                case "to'abaita":
                    return "mlu";
                case "toala'":
                    return "tlz";
                case "toaripi":
                    return "tqo";
                case "toba":
                    return "tob";
                case "tobagonian creole english":
                    return "tgh";
                case "toba-maskoy":
                    return "tmf";
                case "tobanga":
                    return "tng";
                case "tobati":
                    return "tti";
                case "tobelo":
                    return "tlb";
                case "tobian":
                    return "tox";
                case "tobilung":
                    return "tgb";
                case "tobo":
                    return "tbv";
                case "tocantins asurini":
                    return "asu";
                case "tocho":
                    return "taz";
                case "toda":
                    return "tcx";
                case "todos santos cuchumatán mam":
                    return "mvj";
                case "todrah":
                    return "tdr";
                case "tofanma":
                    return "tlg";
                case "tofin gbe":
                    return "tfi";
                case "toga":
                    return "lht";
                case "togbo-vara banda":
                    return "tor";
                case "togoyo":
                    return "tgy";
                case "tohono o'odham":
                    return "ood";
                case "tojolabal":
                    return "toj";
                case "tok pisin":
                    return "tpi";
                case "tokano":
                    return "zuh";
                case "tokelau":
                    return "tkl";
                case "tokharian a":
                    return "xto";
                case "tokharian b":
                    return "txb";
                case "toku-no-shima":
                    return "tkn";
                case "tol":
                    return "jic";
                case "tolaki":
                    return "lbw";
                case "tolomako":
                    return "tlm";
                case "tolowa":
                    return "tol";
                case "toma":
                    return "tod";
                case "tomadino":
                    return "tdi";
                case "tombelala":
                    return "ttp";
                case "tombonuo":
                    return "txa";
                case "tombulu":
                    return "tom";
                case "tomedes":
                    return "toe";
                case "tomini":
                    return "txm";
                case "tomo kan dogon":
                    return "dtm";
                case "tomoip":
                    return "tqp";
                case "tondano":
                    return "tdn";
                case "tonga":
                    return "tog";
                case "tongwe":
                    return "tny";
                case "tonjon":
                    return "tjn";
                case "tonkawa":
                    return "tqw";
                case "tonsawang":
                    return "tnw";
                case "tonsea":
                    return "txs";
                case "tontemboan":
                    return "tnt";
                case "tooro":
                    return "ttj";
                case "topoiyo":
                    return "toy";
                case "toposa":
                    return "toq";
                case "torá":
                    return "trz";
                case "toraja-sa'dan":
                    return "sda";
                case "toram":
                    return "trj";
                case "torau":
                    return "ttu";
                case "tornedalen finnish":
                    return "fit";
                case "toro":
                    return "tdv";
                case "toro so dogon":
                    return "dts";
                case "toro tegu dogon":
                    return "dtt";
                case "toromono":
                    return "tno";
                case "torona":
                    return "tqr";
                case "torres strait creole":
                    return "tcs";
                case "torricelli":
                    return "tei";
                case "torwali":
                    return "trw";
                case "tosk albanian":
                    return "als";
                case "totela":
                    return "ttl";
                case "toto":
                    return "txo";
                case "totoli":
                    return "txe";
                case "totomachapan zapotec":
                    return "zph";
                case "totontepec mixe":
                    return "mto";
                case "totoro":
                    return "ttk";
                case "touo":
                    return "tqu";
                case "toura":
                    return "don";
                case "towei":
                    return "ttn";
                case "transalpine gaulish":
                    return "xtg";
                case "traveller danish":
                    return "rmd";
                case "traveller norwegian":
                    return "rmg";
                case "traveller scottish":
                    return "trl";
                case "tregami":
                    return "trm";
                case "tremembé":
                    return "tme";
                case "trieng":
                    return "stg";
                case "trimuris":
                    return "tip";
                case "tring":
                    return "tgq";
                case "tringgus-sembaan bidayuh":
                    return "trx";
                case "trinidadian creole english":
                    return "trf";
                case "trinitario":
                    return "trn";
                case "trió":
                    return "tri";
                case "truká":
                    return "tka";
                case "trumai":
                    return "tpy";
                case "tsaangi":
                    return "tsa";
                case "tsakhur":
                    return "tkr";
                case "tsakonian":
                    return "tsd";
                case "tsakwambo":
                    return "kvz";
                case "tsamai":
                    return "tsb";
                case "tsat":
                    return "huq";
                case "tseku":
                    return "tsk";
                case "tsetsaut":
                    return "txc";
                case "tshangla":
                    return "tsj";
                case "tsikimba":
                    return "kdl";
                case "tsimané":
                    return "cas";
                case "tsimihety malagasy":
                    return "xmw";
                case "tsimshian":
                    return "tsi";
                case "tsishingini":
                    return "tsw";
                case "tso":
                    return "ldp";
                case "tsoa":
                    return "hio";
                case "tsogo":
                    return "tsv";
                case "tsonga":
                    return "tso";
                case "tsotsitaal":
                    return "fly";
                case "tsou":
                    return "tsu";
                case "tsum":
                    return "ttz";
                case "ts'ün-lao":
                    return "tsl";
                case "tsuvadi":
                    return "tvd";
                case "tsuvan":
                    return "tsh";
                case "tswa":
                    return "tsc";
                case "tswana":
                    return "tsn";
                case "tswapong":
                    return "two";
                case "tu":
                    return "mjg";
                case "tuamotuan":
                    return "pmt";
                case "tubar":
                    return "tbu";
                case "tübatulabal":
                    return "tub";
                case "tucano":
                    return "tuo";
                case "tugen":
                    return "tuy";
                case "tugun":
                    return "tzn";
                case "tugutil":
                    return "tuj";
                case "tukang besi north":
                    return "khc";
                case "tukang besi south":
                    return "bhq";
                case "tuki":
                    return "bag";
                case "tukpa":
                    return "tpq";
                case "tukudede":
                    return "tkd";
                case "tukumanféd":
                    return "tkf";
                case "tula":
                    return "tul";
                case "tulehu":
                    return "tlu";
                case "tulishi":
                    return "tey";
                case "tulu":
                    return "tcy";
                case "tulu-bohuai":
                    return "rak";
                case "tuma-irumu":
                    return "iou";
                case "tumak":
                    return "tmc";
                case "tumari kanuri":
                    return "krt";
                case "tumbalá chol":
                    return "ctu";
                case "tumbuka":
                    return "tum";
                case "tumi":
                    return "kku";
                case "tumleo":
                    return "tmq";
                case "tumshuqese":
                    return "xtq";
                case "tumtum":
                    return "tbr";
                case "tumulung sisaala":
                    return "sil";
                case "tumzabt":
                    return "mzb";
                case "tundra enets":
                    return "enh";
                case "tunen":
                    return "baz";
                case "tungag":
                    return "lcm";
                case "tunggare":
                    return "trt";
                case "tunia":
                    return "tug";
                case "tunica":
                    return "tun";
                case "tunisian arabic":
                    return "aeb";
                case "tunjung":
                    return "tjg";
                case "tunni":
                    return "tqq";
                case "tunzu":
                    return "dza";
                case "tuotomb":
                    return "ttf";
                case "tuparí":
                    return "tpr";
                case "tupí":
                    return "tpw";
                case "tupinambá":
                    return "tpn";
                case "tupinikin":
                    return "tpk";
                case "tupuri":
                    return "tui";
                case "turaka":
                    return "trh";
                case "turi":
                    return "trd";
                case "turiwára":
                    return "twt";
                case "turka":
                    return "tuz";
                case "turkana":
                    return "tuv";
                case "turkic khalaj":
                    return "klj";
                case "turkish":
                    return "tur";
                case "turkmen":
                    return "tuk";
                case "turks and caicos creole english":
                    return "tch";
                case "turoyo":
                    return "tru";
                case "turumsa":
                    return "tqm";
                case "turung":
                    return "try";
                case "tuscarora":
                    return "tus";
                case "tutelo":
                    return "tta";
                case "tutong":
                    return "ttg";
                case "tutsa naga":
                    return "tvt";
                case "tutuba":
                    return "tmi";
                case "tututepec mixtec":
                    return "mtu";
                case "tututni":
                    return "tuu";
                case "tuvalu":
                    return "tvl";
                case "tuvinian":
                    return "tyv";
                case "tuwali ifugao":
                    return "ifk";
                case "tuwari":
                    return "tww";
                case "tuwuli":
                    return "bov";
                case "tuxá":
                    return "tud";
                case "tuxináwa":
                    return "tux";
                case "tuyuca":
                    return "tue";
                case "twana":
                    return "twa";
                case "twendi":
                    return "twn";
                case "twents":
                    return "twd";
                case "twi":
                    return "twi";
                case "tyap":
                    return "kcg";
                case "tyaraity":
                    return "woa";
                case "uab meto":
                    return "aoz";
                case "uamué":
                    return "uam";
                case "uare":
                    return "ksj";
                case "ubaghara":
                    return "byc";
                case "ubang":
                    return "uba";
                case "ubi":
                    return "ubi";
                case "ubir":
                    return "ubr";
                case "ubykh":
                    return "uby";
                case "ucayali-yurúa ashéninka":
                    return "cpb";
                case "uda":
                    return "uda";
                case "udi":
                    return "udi";
                case "udihe":
                    return "ude";
                case "udmurt":
                    return "udm";
                case "uduk":
                    return "udu";
                case "ufim":
                    return "ufi";
                case "ugaritic":
                    return "uga";
                case "ughele":
                    return "uge";
                case "ugong":
                    return "ugo";
                case "uhami":
                    return "uha";
                case "uighur":
                    return "uig";
                case "uisai":
                    return "uis";
                case "ujir":
                    return "udj";
                case "ukaan":
                    return "kcf";
                case "ukhwejo":
                    return "ukh";
                case "ukit":
                    return "umi";
                case "ukpe-bayobiri":
                    return "ukp";
                case "ukpet-ehom":
                    return "akd";
                case "ukrainian":
                    return "ukr";
                case "ukue":
                    return "uku";
                case "ukuriguma":
                    return "ukg";
                case "ukwa":
                    return "ukq";
                case "ukwuani-aboh-ndoni":
                    return "ukw";
                case "ulau-suain":
                    return "svb";
                case "ulch":
                    return "ulc";
                case "ulithian":
                    return "uli";
                case "ullatan":
                    return "ull";
                case "ulukwumi":
                    return "ulb";
                case "ulumanda'":
                    return "ulm";
                case "uma":
                    return "ppk";
                case "uma' lasan":
                    return "xky";
                case "uma' lung":
                    return "ulu";
                case "umanakaina":
                    return "gdn";
                case "umatilla":
                    return "uma";
                case "umbindhamu":
                    return "umd";
                case "umbrian":
                    return "xum";
                case "umbugarla":
                    return "umr";
                case "umbundu":
                    return "umb";
                case "umbu-ungu":
                    return "ubu";
                case "umbuygamu":
                    return "umg";
                case "ume sami":
                    return "sju";
                case "umeda":
                    return "upi";
                case "umiray dumaget agta":
                    return "due";
                case "umon":
                    return "umm";
                case "umotína":
                    return "umo";
                case "umpila":
                    return "ump";
                case "una":
                    return "mtg";
                case "unami":
                    return "unm";
                case "uncoded languages":
                    return "mis";
                case "unde kaili":
                    return "unz";
                case "undetermined":
                    return "und";
                case "uneapa":
                    return "bbn";
                case "uneme":
                    return "une";
                case "unserdeutsch":
                    return "uln";
                case "unua":
                    return "onu";
                case "uokha":
                    return "uok";
                case "upper chehalis":
                    return "cjh";
                case "upper grand valley dani":
                    return "dna";
                case "upper guinea crioulo":
                    return "pov";
                case "upper kinabatangan":
                    return "dmg";
                case "upper kuskokwim":
                    return "kuu";
                case "upper necaxa totonac":
                    return "tku";
                case "upper saxon":
                    return "sxu";
                case "upper sorbian":
                    return "hsb";
                case "upper tanana":
                    return "tau";
                case "upper tanudan kalinga":
                    return "kgh";
                case "upper ta'oih":
                    return "tth";
                case "upper taromi":
                    return "tov";
                case "upper umpqua":
                    return "xup";
                case "ura":
                    return "uro";
                case "uradhi":
                    return "urf";
                case "urak lawoi'":
                    return "urk";
                case "urali":
                    return "url";
                case "urapmin":
                    return "urm";
                case "urarina":
                    return "ura";
                case "urartian":
                    return "xur";
                case "urat":
                    return "urt";
                case "urdu":
                    return "urd";
                case "urhobo":
                    return "urh";
                case "uri":
                    return "uvh";
                case "urigina":
                    return "urg";
                case "urim":
                    return "uri";
                case "urimo":
                    return "urx";
                case "uripiv-wala-rano-atchin":
                    return "upv";
                case "urningangg":
                    return "urc";
                case "uru":
                    return "ure";
                case "uruangnirin":
                    return "urn";
                case "uruava":
                    return "urv";
                case "uru-eu-wau-wau":
                    return "urz";
                case "urum":
                    return "uum";
                case "urumi":
                    return "uru";
                case "uru-pa-in":
                    return "urp";
                case "usaghade":
                    return "usk";
                case "usan":
                    return "wnu";
                case "usarufa":
                    return "usa";
                case "ushojo":
                    return "ush";
                case "usila chinantec":
                    return "cuc";
                case "uspanteco":
                    return "usp";
                case "usui":
                    return "usi";
                case "utarmbung":
                    return "omo";
                case "ute-southern paiute":
                    return "ute";
                case "utu":
                    return "utu";
                case "uvbie":
                    return "evh";
                case "uya":
                    return "usu";
                case "uzbek":
                    return "uzb";
                case "uzbeki arabic":
                    return "auz";
                case "uzekwe":
                    return "eze";
                case "vaagri booli":
                    return "vaa";
                case "vafsi":
                    return "vaf";
                case "vaghat-ya-bijim-legeri":
                    return "bij";
                case "vaghri":
                    return "vgr";
                case "vaghua":
                    return "tva";
                case "vagla":
                    return "vag";
                case "vai":
                    return "vai";
                case "vaiphei":
                    return "vap";
                case "vale":
                    return "vae";
                case "valle nacional chinantec":
                    return "cvn";
                case "valley maidu":
                    return "vmv";
                case "valman":
                    return "van";
                case "valpei":
                    return "vlp";
                case "vamale":
                    return "mkt";
                case "vame":
                    return "mlr";
                case "vandalic":
                    return "xvn";
                case "vangunu":
                    return "mpr";
                case "vanimo":
                    return "vam";
                case "vano":
                    return "vnk";
                case "vanuma":
                    return "vau";
                case "vao":
                    return "vao";
                case "varhadi-nagpuri":
                    return "vah";
                case "varisi":
                    return "vrs";
                case "varli":
                    return "vav";
                case "vasavi":
                    return "vas";
                case "vasekela bushman":
                    return "vaj";
                case "vatrata":
                    return "vlr";
                case "veddah":
                    return "ved";
                case "vehes":
                    return "val";
                case "veluws":
                    return "vel";
                case "vemgo-mabas":
                    return "vem";
                case "venda":
                    return "ven";
                case "venetian":
                    return "vec";
                case "venetic":
                    return "xve";
                case "vengo":
                    return "bav";
                case "ventureño":
                    return "veo";
                case "venustiano carranza tzotzil":
                    return "tzo";
                case "veps":
                    return "vep";
                case "veracruz huastec":
                    return "hus";
                case "vestinian":
                    return "xvs";
                case "vidunda":
                    return "vid";
                case "viemo":
                    return "vig";
                case "vietnamese":
                    return "vie";
                case "vilela":
                    return "vil";
                case "vili":
                    return "vif";
                case "villa viciosa agta":
                    return "dyg";
                case "vincentian creole english":
                    return "svc";
                case "vinmavis":
                    return "vnm";
                case "vinza":
                    return "vin";
                case "virgin islands creole english":
                    return "vic";
                case "vishavan":
                    return "vis";
                case "viti":
                    return "vit";
                case "vitou":
                    return "vto";
                case "vlaams":
                    return "vls";
                case "vlax romani":
                    return "rmy";
                case "volapük":
                    return "vol";
                case "volscian":
                    return "xvo";
                case "vono":
                    return "kch";
                case "voro":
                    return "vor";
                case "votic":
                    return "vot";
                case "vumbu":
                    return "vum";
                case "vunapu":
                    return "vnp";
                case "vunjo":
                    return "vun";
                case "vute":
                    return "vut";
                case "vwanji":
                    return "wbi";
                case "wa":
                    return "wbm";
                case "waama":
                    return "wwa";
                case "waamwang":
                    return "wmn";
                case "waata":
                    return "ssn";
                case "wab":
                    return "wab";
                case "wabo":
                    return "wbb";
                case "waboda":
                    return "kmx";
                case "waci gbe":
                    return "wci";
                case "wadaginam":
                    return "wdg";
                case "waddar":
                    return "wbq";
                case "wadiyara koli":
                    return "kxp";
                case "wadjiginy":
                    return "wdj";
                case "wadjigu":
                    return "wdu";
                case "wae rana":
                    return "wrx";
                case "wa'ema":
                    return "wag";
                case "waffa":
                    return "waj";
                case "wagawaga":
                    return "wgw";
                case "wagaya":
                    return "wga";
                case "wagdi":
                    return "wbr";
                case "wageman":
                    return "waq";
                case "wagi":
                    return "fad";
                case "wahau kayan":
                    return "whu";
                case "wahau kenyah":
                    return "whk";
                case "wahgi":
                    return "wgi";
                case "waigali":
                    return "wbk";
                case "waigeo":
                    return "wgo";
                case "wailaki":
                    return "wlk";
                case "wailapa":
                    return "wlr";
                case "waima":
                    return "rro";
                case "waima'a":
                    return "wmh";
                case "waimaha":
                    return "bao";
                case "waimiri-atroari":
                    return "atr";
                case "waioli":
                    return "wli";
                case "waiwai":
                    return "waw";
                case "waja":
                    return "wja";
                case "wajarri":
                    return "wbv";
                case "waka":
                    return "wav";
                case "wakawaka":
                    return "wkw";
                case "wakhi":
                    return "wbl";
                case "wakoná":
                    return "waf";
                case "wala":
                    return "lgl";
                case "walak":
                    return "wlw";
                case "walamo":
                    return "wal";
                case "wali":
                    return "wll";
                case "waling":
                    return "wly";
                case "walio":
                    return "wla";
                case "walla walla":
                    return "waa";
                case "wallisian":
                    return "wls";
                case "walloon":
                    return "wln";
                case "walmajarri":
                    return "wmt";
                case "walo kumbe dogon":
                    return "dwl";
                case "walser":
                    return "wae";
                case "walungge":
                    return "ola";
                case "wamas":
                    return "wmc";
                case "wambaya":
                    return "wmb";
                case "wambon":
                    return "wms";
                case "wambule":
                    return "wme";
                case "wamey":
                    return "cou";
                case "wamin":
                    return "wmi";
                case "wampanoag":
                    return "wam";
                case "wampar":
                    return "lbq";
                case "wampur":
                    return "waz";
                case "wan":
                    return "wan";
                case "wanambre":
                    return "wnb";
                case "wanap":
                    return "wnp";
                case "wancho naga":
                    return "nnp";
                case "wanda":
                    return "wbh";
                case "wandala":
                    return "mfi";
                case "wandamen":
                    return "wad";
                case "wandarang":
                    return "wnd";
                case "wandji":
                    return "wdd";
                case "wané":
                    return "hwa";
                case "waneci":
                    return "wne";
                case "wangaaybuwan-ngiyambaa":
                    return "wyb";
                case "wanggamala":
                    return "wnm";
                case "wangganguru":
                    return "wgg";
                case "wanggom":
                    return "wng";
                case "wanman":
                    return "wbt";
                case "wannu":
                    return "jub";
                case "wano":
                    return "wno";
                case "wantoat":
                    return "wnc";
                case "wanukaka":
                    return "wnk";
                case "waorani":
                    return "auc";
                case "wapan":
                    return "juk";
                case "wãpha":
                    return "juw";
                case "wapishana":
                    return "wap";
                case "wappo":
                    return "wao";
                case "wara":
                    return "wbf";
                case "wára":
                    return "tci";
                case "warao":
                    return "wba";
                case "warapu":
                    return "wra";
                case "waray":
                    return "war";
                case "waray sorsogon":
                    return "srv";
                case "wardaman":
                    return "wrr";
                case "warduji":
                    return "wrd";
                case "warembori":
                    return "wsa";
                case "wares":
                    return "wai";
                case "waris":
                    return "wrs";
                case "waritai":
                    return "wbe";
                case "wariyangga":
                    return "wri";
                case "war-jaintia":
                    return "aml";
                case "warji":
                    return "wji";
                case "warkay-bipim":
                    return "bgv";
                case "warlmanpa":
                    return "wrl";
                case "warlpiri":
                    return "wbp";
                case "warluwara":
                    return "wrb";
                case "warnang":
                    return "wrn";
                case "waropen":
                    return "wrp";
                case "warrgamay":
                    return "wgy";
                case "warrwa":
                    return "wwr";
                case "waru":
                    return "wru";
                case "warumungu":
                    return "wrm";
                case "waruna":
                    return "wrv";
                case "warungu":
                    return "wrg";
                case "wasa":
                    return "wss";
                case "wasco-wishram":
                    return "wac";
                case "wasembo":
                    return "gsp";
                case "washo":
                    return "was";
                case "waskia":
                    return "wsk";
                case "wasu":
                    return "wsu";
                case "watakataui":
                    return "wtk";
                case "watam":
                    return "wax";
                case "watubela":
                    return "wah";
                case "waurá":
                    return "wau";
                case "wauyai":
                    return "wuy";
                case "wawa":
                    return "www";
                case "wawonii":
                    return "wow";
                case "waxianghua":
                    return "wxa";
                case "wayampi":
                    return "oym";
                case "wayana":
                    return "way";
                case "wayanad chetti":
                    return "ctt";
                case "wayoró":
                    return "wyr";
                case "wayu":
                    return "vay";
                case "wayuu":
                    return "guc";
                case "wè northern":
                    return "wob";
                case "wè southern":
                    return "gxx";
                case "wè western":
                    return "wec";
                case "wedau":
                    return "wed";
                case "weh":
                    return "weh";
                case "wejewa":
                    return "wew";
                case "welaung":
                    return "weu";
                case "weliki":
                    return "klh";
                case "welsh":
                    return "cym";
                case "welsh romani":
                    return "rmw";
                case "weme gbe":
                    return "wem";
                case "were":
                    return "wei";
                case "weri":
                    return "wer";
                case "wersing":
                    return "kvw";
                case "west ambae":
                    return "nnd";
                case "west berawan":
                    return "zbw";
                case "west central banda":
                    return "bbp";
                case "west central oromo":
                    return "gaz";
                case "west central quiché":
                    return "qut";
                case "west coast bajau":
                    return "bdr";
                case "west damar":
                    return "drn";
                case "west kewa":
                    return "kew";
                case "west lembata":
                    return "lmj";
                case "west makian":
                    return "mqs";
                case "west masela":
                    return "mss";
                case "west tarangan":
                    return "txn";
                case "west uvean":
                    return "uve";
                case "west yugur":
                    return "ybe";
                case "west-central limba":
                    return "lia";
                case "western abnaki":
                    return "abe";
                case "western acipa":
                    return "awc";
                case "western apache":
                    return "apw";
                case "western arrarnta":
                    return "are";
                case "western balochi":
                    return "bgn";
                case "western bolivian guaraní":
                    return "gnw";
                case "western bru":
                    return "brv";
                case "western bukidnon manobo":
                    return "mbb";
                case "western cakchiquel":
                    return "ckw";
                case "western canadian inuktitut":
                    return "ikt";
                case "western cham":
                    return "cja";
                case "western dani":
                    return "dnw";
                case "western farsi":
                    return "pes";
                case "western fijian":
                    return "wyy";
                case "western frisian":
                    return "fry";
                case "western gurung":
                    return "gvr";
                case "western highland chatino":
                    return "ctp";
                case "western highland purepecha":
                    return "pua";
                case "western huasteca nahuatl":
                    return "nhw";
                case "western jacalteco":
                    return "jai";
                case "western juxtlahuaca mixtec":
                    return "jmx";
                case "western kanjobal":
                    return "knj";
                case "western karaboro":
                    return "kza";
                case "western katu":
                    return "kuf";
                case "western kayah":
                    return "kyu";
                case "western keres":
                    return "kjq";
                case "western krahn":
                    return "krw";
                case "western lalu":
                    return "ywl";
                case "western lawa":
                    return "lcp";
                case "western magar":
                    return "mrd";
                case "western maninkakan":
                    return "mlq";
                case "western mari":
                    return "mrj";
                case "western mashan hmong":
                    return "hmw";
                case "western meohang":
                    return "raf";
                case "western muria":
                    return "mut";
                case "western neo-aramaic":
                    return "amw";
                case "western niger fulfulde":
                    return "fuh";
                case "western ojibwa":
                    return "ojw";
                case "western panjabi":
                    return "pnb";
                case "western parbate kham":
                    return "kjl";
                case "western penan":
                    return "pne";
                case "western pokomchí":
                    return "pob";
                case "western sisaala":
                    return "ssl";
                case "western subanon":
                    return "suc";
                case "western tamang":
                    return "tdg";
                case "western tawbuid":
                    return "twb";
                case "western totonac":
                    return "tqt";
                case "western tunebo":
                    return "tnb";
                case "western tzutujil":
                    return "tzt";
                case "western xiangxi miao":
                    return "mmr";
                case "western xwla gbe":
                    return "xwl";
                case "western yiddish":
                    return "yih";
                case "westphalien":
                    return "wep";
                case "wetamut":
                    return "wwo";
                case "wewaw":
                    return "wea";
                case "weyto":
                    return "woy";
                case "white gelao":
                    return "giw";
                case "white lachi":
                    return "lwh";
                case "whitesands":
                    return "tnp";
                case "wiarumus":
                    return "tua";
                case "wichí lhamtés güisnay":
                    return "mzh";
                case "wichí lhamtés nocten":
                    return "mtp";
                case "wichí lhamtés vejoz":
                    return "wlv";
                case "wichita":
                    return "wic";
                case "wikalkan":
                    return "wik";
                case "wik-epa":
                    return "wie";
                case "wik-iiyanh":
                    return "wij";
                case "wik-keyangan":
                    return "wif";
                case "wik-me'anha":
                    return "wih";
                case "wik-mungkan":
                    return "wim";
                case "wik-ngathana":
                    return "wig";
                case "wikngenchera":
                    return "wua";
                case "wilawila":
                    return "wil";
                case "wintu":
                    return "wit";
                case "winyé":
                    return "kst";
                case "wipi":
                    return "gdr";
                case "wiradhuri":
                    return "wrh";
                case "wiraféd":
                    return "wir";
                case "wirangu":
                    return "wiw";
                case "wiru":
                    return "wiu";
                case "wiyot":
                    return "wiy";
                case "woccon":
                    return "xwc";
                case "wogamusin":
                    return "wog";
                case "wogeo":
                    return "woc";
                case "woi":
                    return "wbw";
                case "wojenaka":
                    return "jod";
                case "wolane":
                    return "wle";
                case "wolani":
                    return "wod";
                case "woleaian":
                    return "woe";
                case "wolio":
                    return "wlo";
                case "wolof":
                    return "wol";
                case "wom":
                    return "wom";
                case "wongo":
                    return "won";
                case "woods cree":
                    return "cwd";
                case "woria":
                    return "wor";
                case "worimi":
                    return "kda";
                case "worodougou":
                    return "jud";
                case "worora":
                    return "unp";
                case "wotapuri-katarqalai":
                    return "wsv";
                case "wotu":
                    return "wtw";
                case "woun meu":
                    return "noa";
                case "written oirat":
                    return "xwo";
                case "wu chinese":
                    return "wuu";
                case "wuding-luquan yi":
                    return "ywq";
                case "wudu":
                    return "wud";
                case "wuliwuli":
                    return "wlu";
                case "wulna":
                    return "wux";
                case "wumboko":
                    return "bqm";
                case "wumbvu":
                    return "wum";
                case "wumeng nasu":
                    return "ywu";
                case "wunai bunu":
                    return "bwn";
                case "wunambal":
                    return "wub";
                case "wurrugu":
                    return "wur";
                case "wusa nasu":
                    return "yig";
                case "wushi":
                    return "bse";
                case "wusi":
                    return "wsi";
                case "wutung":
                    return "wut";
                case "wutunhua":
                    return "wuh";
                case "wuvulu-aua":
                    return "wuv";
                case "wuzlam":
                    return "udl";
                case "wyandot":
                    return "wya";
                case "wymysorys":
                    return "wym";
                case "xaasongaxango":
                    return "kao";
                case "xadani zapotec":
                    return "zax";
                case "xakriabá":
                    return "xkr";
                case "xam":
                    return "xam";
                case "xamtanga":
                    return "xan";
                case "xanaguía zapotec":
                    return "ztg";
                case "xârâcùù":
                    return "ane";
                case "xaragure":
                    return "axx";
                case "xavánte":
                    return "xav";
                case "xegwi":
                    return "xeg";
                case "xerénte":
                    return "xer";
                case "xetá":
                    return "xet";
                case "xhosa":
                    return "xho";
                case "xiandao":
                    return "xia";
                case "xiang chinese":
                    return "hsn";
                case "xibe":
                    return "sjo";
                case "xicotepec de juárez totonac":
                    return "too";
                case "xinca":
                    return "xin";
                case "xingú asuriní":
                    return "asn";
                case "xipaya":
                    return "xiy";
                case "xipináwa":
                    return "xip";
                case "xiri":
                    return "xii";
                case "xiriâna":
                    return "xir";
                case "xishanba lalo":
                    return "ywt";
                case "xokleng":
                    return "xok";
                case "xukurú":
                    return "xoo";
                case "xwela gbe":
                    return "xwe";
                case "yaaku":
                    return "muu";
                case "yabaâna":
                    return "ybn";
                case "yabarana":
                    return "yar";
                case "yabem":
                    return "jae";
                case "yaben":
                    return "ybm";
                case "yabong":
                    return "ybo";
                case "yace":
                    return "ekr";
                case "yaeyama":
                    return "rys";
                case "yafi":
                    return "wfg";
                case "yagaria":
                    return "ygr";
                case "yagnobi":
                    return "yai";
                case "yagomi":
                    return "ygm";
                case "yagua":
                    return "yad";
                case "yagwoia":
                    return "ygw";
                case "yahadian":
                    return "ner";
                case "yahang":
                    return "rhp";
                case "yahuna":
                    return "ynu";
                case "yaka":
                    return "axk";
                case "yakaikeke":
                    return "ykk";
                case "yakamul":
                    return "ykm";
                case "yakan":
                    return "yka";
                case "yakha":
                    return "ybh";
                case "yakima":
                    return "yak";
                case "yakoma":
                    return "yky";
                case "yakut":
                    return "sah";
                case "yala":
                    return "yba";
                case "yalahatan":
                    return "jal";
                case "yalakalore":
                    return "xyl";
                case "yalálag zapotec":
                    return "zpu";
                case "yalarnnga":
                    return "ylr";
                case "yale":
                    return "nce";
                case "yalunka":
                    return "yal";
                case "yámana":
                    return "yag";
                case "yamap":
                    return "ymp";
                case "yamba":
                    return "yam";
                case "yambes":
                    return "ymb";
                case "yambeta":
                    return "yat";
                case "yamdena":
                    return "jmd";
                case "yameo":
                    return "yme";
                case "yami":
                    return "tao";
                case "yaminahua":
                    return "yaa";
                case "yamongeri":
                    return "ymg";
                case "yamphe":
                    return "yma";
                case "yamphu":
                    return "ybi";
                case "yana":
                    return "ynn";
                case "yanahuanca pasco quechua":
                    return "qur";
                case "yanda dom dogon":
                    return "dym";
                case "yandruwandha":
                    return "ynd";
                case "yanesha'":
                    return "ame";
                case "yang zhuang":
                    return "zyg";
                case "yangben":
                    return "yav";
                case "yangbye":
                    return "ybd";
                case "yangho":
                    return "ynh";
                case "yangkam":
                    return "bsx";
                case "yangman":
                    return "jng";
                case "yango":
                    return "yng";
                case "yangulam":
                    return "ynl";
                case "yangum dey":
                    return "yde";
                case "yangum gel":
                    return "ygl";
                case "yangum mon":
                    return "ymo";
                case "yankunytjatjara":
                    return "kdd";
                case "yan-nhangu":
                    return "jay";
                case "yanomámi":
                    return "wca";
                case "yanomamö":
                    return "guu";
                case "yansi":
                    return "yns";
                case "yanyuwa":
                    return "jao";
                case "yao":
                    return "yao";
                case "yaosakor asmat":
                    return "asy";
                case "yaouré":
                    return "yre";
                case "yapese":
                    return "yap";
                case "yapunda":
                    return "yev";
                case "yaqay":
                    return "jaq";
                case "yaqui":
                    return "yaq";
                case "yarawata":
                    return "yrw";
                case "yareba":
                    return "yrb";
                case "yareni zapotec":
                    return "zae";
                case "yarí":
                    return "yri";
                case "yarsun":
                    return "yrs";
                case "yasa":
                    return "yko";
                case "yassic":
                    return "ysc";
                case "yatee zapotec":
                    return "zty";
                case "yatzachi zapotec":
                    return "zav";
                case "yau":
                    return "yuw";
                case "yaul":
                    return "yla";
                case "yauma":
                    return "yax";
                case "yaur":
                    return "jau";
                case "yautepec zapotec":
                    return "zpb";
                case "yauyos quechua":
                    return "qux";
                case "yavitero":
                    return "yvt";
                case "yawa":
                    return "yva";
                case "yawalapití":
                    return "yaw";
                case "yawanawa":
                    return "ywn";
                case "yawarawarga":
                    return "yww";
                case "yaweyuha":
                    return "yby";
                case "yawiyo":
                    return "ybx";
                case "yawuru":
                    return "ywr";
                case "yazgulyam":
                    return "yah";
                case "yecuatla totonac":
                    return "tlc";
                case "yei":
                    return "jei";
                case "yekhee":
                    return "ets";
                case "yekora":
                    return "ykr";
                case "yela":
                    return "yel";
                case "yele":
                    return "yle";
                case "yelmek":
                    return "jel";
                case "yelogu":
                    return "ylg";
                case "yemba":
                    return "ybb";
                case "yemsa":
                    return "jnj";
                case "yendang":
                    return "yen";
                case "yeni":
                    return "yei";
                case "yeniche":
                    return "yec";
                case "yepocapa southwestern cakchiquel":
                    return "cbm";
                case "yerakai":
                    return "yra";
                case "yeretuar":
                    return "gop";
                case "yerong":
                    return "yrn";
                case "yerukula":
                    return "yeu";
                case "yeskwa":
                    return "yes";
                case "yessan-mayo":
                    return "yss";
                case "yetfa":
                    return "yet";
                case "yevanic":
                    return "yej";
                case "yeyi":
                    return "yey";
                case "yiddish":
                    return "yid";
                case "yidgha":
                    return "ydg";
                case "yidiny":
                    return "yii";
                case "yil":
                    return "yll";
                case "yimas":
                    return "yee";
                case "yimchungru naga":
                    return "yim";
                case "yinbaw karen":
                    return "kvu";
                case "yinchia":
                    return "yin";
                case "yindjibarndi":
                    return "yij";
                case "yindjilandji":
                    return "yil";
                case "yine":
                    return "pib";
                case "yinggarda":
                    return "yia";
                case "yintale karen":
                    return "kvy";
                case "yir yoront":
                    return "yiy";
                case "yis":
                    return "yis";
                case "yiwom":
                    return "gek";
                case "yoba":
                    return "yob";
                case "yocoboué dida":
                    return "gud";
                case "yogad":
                    return "yog";
                case "yoidik":
                    return "ydk";
                case "yoke":
                    return "yki";
                case "yokuts":
                    return "yok";
                case "yoloxochitl mixtec":
                    return "xty";
                case "yom":
                    return "pil";
                case "yombe":
                    return "yom";
                case "yonaguni":
                    return "yoi";
                case "yong":
                    return "yno";
                case "yongbei zhuang":
                    return "zyb";
                case "yonggom":
                    return "yon";
                case "yongnan zhuang":
                    return "zyn";
                case "yopno":
                    return "yut";
                case "yora":
                    return "mts";
                case "yoron":
                    return "yox";
                case "yoruba":
                    return "yor";
                case "yos":
                    return "yos";
                case "yosondúa mixtec":
                    return "mpm";
                case "youjiang zhuang":
                    return "zyj";
                case "youle jinuo":
                    return "jiu";
                case "younuo bunu":
                    return "buh";
                case "yoy":
                    return "yoy";
                case "yuaga":
                    return "nua";
                case "yucatán maya":
                    return "yua";
                case "yuchi":
                    return "yuc";
                case "yucuañe mixtec":
                    return "mvg";
                case "yucuna":
                    return "ycn";
                case "yue chinese":
                    return "yue";
                case "yug":
                    return "yug";
                case "yugambal":
                    return "yub";
                case "yugh":
                    return "yuu";
                case "yuhup":
                    return "yab";
                case "yuki":
                    return "yuk";
                case "yukpa":
                    return "yup";
                case "yukuben":
                    return "ybl";
                case "yulu":
                    return "yul";
                case "yuqui":
                    return "yuq";
                case "yuracare":
                    return "yuz";
                case "yurok":
                    return "yur";
                case "yurutí":
                    return "yui";
                case "yutanduchi mixtec":
                    return "mab";
                case "yuwana":
                    return "yau";
                case "zaachila zapotec":
                    return "ztx";
                case "zabana":
                    return "kji";
                case "zacatepec chatino":
                    return "ctz";
                case "zacatlán-ahuacatlán-tepetzintla nahuatl":
                    return "nhi";
                case "zaghawa":
                    return "zag";
                case "zaiwa":
                    return "atb";
                case "zakhring":
                    return "zkr";
                case "zan gula":
                    return "zna";
                case "zanaki":
                    return "zak";
                case "zande":
                    return "zne";
                case "zangskari":
                    return "zau";
                case "zangwal":
                    return "zah";
                case "zaniza zapotec":
                    return "zpw";
                case "záparo":
                    return "zro";
                case "zapotec":
                    return "zap";
                case "zaramo":
                    return "zaj";
                case "zari":
                    return "zaz";
                case "zarma":
                    return "dje";
                case "zarphatic":
                    return "zrp";
                case "zauzou":
                    return "zal";
                case "zay":
                    return "zwa";
                case "zayein karen":
                    return "kxk";
                case "zaysete":
                    return "zay";
                case "zazaki":
                    return "zza";
                case "zazao":
                    return "jaj";
                case "zeem":
                    return "zua";
                case "zeeuws":
                    return "zea";
                case "zemba":
                    return "dhm";
                case "zeme naga":
                    return "nzm";
                case "zemgalian":
                    return "xzm";
                case "zenag":
                    return "zeg";
                case "zenaga":
                    return "zen";
                case "zenzontepec chatino":
                    return "czn";
                case "zhaba":
                    return "zhb";
                case "zhang-zhung":
                    return "xzh";
                case "zhire":
                    return "zhi";
                case "zhoa":
                    return "zhw";
                case "zia":
                    return "zia";
                case "zigula":
                    return "ziw";
                case "zimakani":
                    return "zik";
                case "zimba":
                    return "zmb";
                case "zinacantán tzotzil":
                    return "tzz";
                case "zinza":
                    return "zin";
                case "zire":
                    return "sih";
                case "zirenkel":
                    return "zrn";
                case "ziriya":
                    return "zir";
                case "zizilivakan":
                    return "ziz";
                case "zo'é":
                    return "pto";
                case "zokhuo":
                    return "yzk";
                case "zoogocho zapotec":
                    return "zpq";
                case "zoroastrian dari":
                    return "gbz";
                case "zotung chin":
                    return "czt";
                case "zou":
                    return "zom";
                case "zulgo-gemzek":
                    return "gnd";
                case "zulu":
                    return "zul";
                case "zumaya":
                    return "zuy";
                case "zumbun":
                    return "jmb";
                case "zuni":
                    return "zun";
                case "zuojiang zhuang":
                    return "zzj";
                case "zyphe":
                    return "zyp";
                default: return "";
            }
        }
    }
}
