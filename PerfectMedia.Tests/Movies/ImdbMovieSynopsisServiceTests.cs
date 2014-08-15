using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.Movies
{
    public class ImdbMovieSynopsisServiceTests
    {
        #region Constants
        private const string MovieId = "tt0446029";
        private const string ImdbPageHtml = @"<!DOCTYPE html>
<html
xmlns:og=""http://ogp.me/ns#""
xmlns:fb=""http://www.facebook.com/2008/fbml"">
    <head>
            <script type=""text/javascript"">var ue_t0=window.ue_t0||+new Date();</script>
            <script type=""text/javascript"">
                var ue_mid = ""A1EVAM02EL8SFB"";
                var ue_sn = ""www.imdb.com"";
                var ue_furl = ""fls-na.amazon.com"";
                var ue_sid = ""810-2165397-0496190"";
                var ue_id = ""15VE9X8Y818EAKHK5QRX"";
                (function(e){var c=e,a={main_scope:""mainscopecsm"",q:[],t0:c.ue_t0||+new Date(),d:g};function g(h){return +new Date()-(h?0:a.t0)}function d(h){return function(){a.q.push({n:h,a:arguments,t:a.d()})}}function b(k,j,h){var i={m:k,f:j,l:h,fromOnError:1,args:arguments};c.ueLogError(i);return false}b.skipTrace=1;e.onerror=b;function f(){c.uex(""ld"")}if(e.addEventListener){e.addEventListener(""load"",f,false)}else{if(e.attachEvent){e.attachEvent(""onload"",f)}}a.tag=d(""tag"");a.log=d(""log"");a.reset=d(""rst"");c.ue_csm=c;c.ue=a;c.ueLogError=d(""err"");c.ues=d(""ues"");c.uet=d(""uet"");c.uex=d(""uex"");c.uet(""ue"")})(window);(function(e,d){var a=e.ue||{};function c(g){if(!g){return}var f=d.head||d.getElementsByTagName(""head"")[0]||d.documentElement,h=d.createElement(""script"");h.async=""async"";h.src=g;f.insertBefore(h,f.firstChild)}function b(){var k=e.ue_cdn||""z-ecx.images-amazon.com"",g=e.ue_cdns||""images-na.ssl-images-amazon.com"",j=""/images/G/01/csminstrumentation/"",h=e.ue_file||""ue-full-ef584a44e8ea58e3d4d928956600a9b6._V1_.js"",f,i;if(h.indexOf(""NSTRUMENTATION_FIL"")>=0){return}if(""ue_https"" in e){f=e.ue_https}else{f=e.location&&e.location.protocol==""https:""?1:0}i=f?""https://"":""http://"";i+=f?g:k;i+=j;i+=h;c(i)}if(!e.ue_inline){b()}a.uels=c;e.ue=a})(window,document);
            </script>
        <script type=""text/javascript"">var IMDbTimer={starttime: new Date().getTime(),pt:'java'};</script>
  <script>(function(t){ (t.events = t.events || {})[""csm_head_pre_title""] = new Date().getTime(); })(IMDbTimer);</script>
        <title>Scott Pilgrim vs. the World (2010) - IMDb</title>
  <script>(function(t){ (t.events = t.events || {})[""csm_head_post_title""] = new Date().getTime(); })(IMDbTimer);</script>
        <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
            <link rel=""canonical"" href=""http://www.imdb.com/title/tt0446029/"" />
            <meta property=""og:url"" content=""http://www.imdb.com/title/tt0446029/"" />
  <script>(function(t){ (t.events = t.events || {})[""csm_head_pre_icon""] = new Date().getTime(); })(IMDbTimer);</script>
        <link rel=""icon"" type=""image/ico"" href=""http://ia.media-imdb.com/images/G/01/imdb/images/favicon-2165806970._CB379387995_.ico"" />
        <link rel=""shortcut icon"" type=""image/x-icon"" href=""http://ia.media-imdb.com/images/G/01/imdb/images/desktop-favicon-2165806970._CB379390718_.ico"" />
        <link href=""http://ia.media-imdb.com/images/G/01/imdb/images/mobile/apple-touch-icon-web-4151659188._CB361295786_.png"" rel=""apple-touch-icon""> 
        <link href=""http://ia.media-imdb.com/images/G/01/imdb/images/mobile/apple-touch-icon-web-76x76-53536248._CB361295462_.png"" rel=""apple-touch-icon"" sizes=""76x76""> 
        <link href=""http://ia.media-imdb.com/images/G/01/imdb/images/mobile/apple-touch-icon-web-120x120-2442878471._CB361295428_.png"" rel=""apple-touch-icon"" sizes=""120x120""> 
        <link href=""http://ia.media-imdb.com/images/G/01/imdb/images/mobile/apple-touch-icon-web-152x152-1475823641._CB361295368_.png"" rel=""apple-touch-icon"" sizes=""152x152""> 
        <link rel=""search"" type=""application/opensearchdescription+xml"" href=""http://ia.media-imdb.com/images/G/01/imdb/images/imdbsearch-3349468880._CB379388505_.xml"" title=""IMDb"" />
  <script>(function(t){ (t.events = t.events || {})[""csm_head_post_icon""] = new Date().getTime(); })(IMDbTimer);</script>
        <link rel='image_src' href=""http://ia.media-imdb.com/images/M/MV5BMTkwNTczNTMyOF5BMl5BanBnXkFtZTcwNzUxOTUyMw@@._V1_SY1200_CR90,0,630,1200_AL_.jpg"">
        <meta property='og:image' content=""http://ia.media-imdb.com/images/M/MV5BMTkwNTczNTMyOF5BMl5BanBnXkFtZTcwNzUxOTUyMw@@._V1_SY1200_CR90,0,630,1200_AL_.jpg"" />
        <meta property='og:type' content=""video.movie"" />
    <meta property='fb:app_id' content='115109575169727' />
    <meta property='og:title' content=""Scott Pilgrim vs. the World (2010)"" />
    <meta property='og:site_name' content='IMDb' />
    <meta name=""title"" content=""Scott Pilgrim vs. the World (2010) - IMDb"" />
        <meta name=""description"" content=""Directed by Edgar Wright.  With Michael Cera, Mary Elizabeth Winstead, Kieran Culkin, Alison Pill. Scott Pilgrim must defeat his new girlfriend's seven evil exes in order to win her heart."" />
        <meta property=""og:description"" content=""Directed by Edgar Wright.  With Michael Cera, Mary Elizabeth Winstead, Kieran Culkin, Alison Pill. Scott Pilgrim must defeat his new girlfriend's seven evil exes in order to win her heart."" />
        <meta name=""keywords"" content=""Reviews, Showtimes, DVDs, Photos, Message Boards, User Ratings, Synopsis, Trailers, Credits"" />
        <meta name=""request_id"" content=""15VE9X8Y818EAKHK5QRX"" />
  <script>(function(t){ (t.events = t.events || {})[""csm_head_pre_css""] = new Date().getTime(); })(IMDbTimer);</script>
<!-- h=ics-http-1e-c1xl-i-0ba7ad2b.us-east-1 -->
            <link rel=""stylesheet"" type=""text/css"" href=""http://ia.media-imdb.com/images/G/01/imdb/css/collections/title-3550098364._CB345393794_.css"" />
            <!--[if IE]><link rel=""stylesheet"" type=""text/css"" href=""http://ia.media-imdb.com/images/G/01/imdb/css/collections/ie-1918465287._CB354866480_.css"" /><![endif]-->
            <link rel=""stylesheet"" type=""text/css"" href=""http://ia.media-imdb.com/images/G/01/imdb/css/site/consumer-navbar-mega-3538633082._CB355276482_.css"" />
        <noscript>
            <link rel=""stylesheet"" type=""text/css"" href=""http://ia.media-imdb.com/images/G/01/imdb/css/wheel/nojs-2627072490._CB343672767_.css"">
        </noscript>
  <script>(function(t){ (t.events = t.events || {})[""csm_head_post_css""] = new Date().getTime(); })(IMDbTimer);</script>
  <script>(function(t){ (t.events = t.events || {})[""csm_head_pre_ads""] = new Date().getTime(); })(IMDbTimer);</script>
        <script>
window.ads_js_start = new Date().getTime();
var imdbads = imdbads || {}; imdbads.cmd = imdbads.cmd || [];
</script>
<!-- begin SRA -->
<script>
(function(){var d=function(o){return Object.prototype.toString.call(o)===""[object Array]"";},g=function(q,p){var o;for(o=0;o<q.length;o++){if(o in q){p.call(null,q[o],o);}}},h=[],k,b,l=false,n=false,f=function(){var o=[],p=[],q={};g(h,function(s){var r="""";g(s.dartsite.split(""/""),function(t){if(t!==""""){if(t in q){}else{q[t]=o.length;o.push(t);}r+=""/""+q[t];}});p.push(r);});return{iu_parts:o,enc_prev_ius:p};},c=function(){var o=[];g(h,function(q){var p=[];g(q.sizes,function(r){p.push(r.join(""x""));});o.push(p.join(""|""));});return o;},m=function(){var o=[];g(h,function(p){o.push(a(p.targeting));});return o.join(""|"");},a=function(r,o){var q,p,s=[];for(q in r){p=[];for(j=0;j<r[q].length;j++){p.push(encodeURIComponent(r[q][j]));}if(o){s.push(q+""=""+encodeURIComponent(p.join("","")));}else{s.push(q+""=""+p.join("",""));}}return s.join(""&"");},e=function(){var o=+new Date();if(n){return;}if(!this.readyState||""loaded""===this.readyState){n=true;if(l){imdbads.cmd.push(function(){for(i=0;i<h.length;i++){generic.monitoring.record_metric(h[i].name+"".fail"",csm.duration(o));}});}}};window.tinygpt={define_slot:function(r,q,o,p){h.push({dartsite:r.replace(/\/$/,""""),sizes:q,name:o,targeting:p});},set_targeting:function(o){k=o;},callback:function(q){var r,p={},t,o,s=+new Date();l=false;for(r=0;r<h.length;r++){t=h[r].dartsite;o=h[r].name;if(q[r][t]){p[o]=q[r][t];}else{window.console&&console.error&&console.error(""Unable to correlate GPT response for ""+o);}}imdbads.cmd.push(function(){for(r=0;r<h.length;r++){ad_utils.slot_events.trigger(h[r].name,""request"",{timestamp:b});ad_utils.slot_events.trigger(h[r].name,""tagdeliver"",{timestamp:s});}ad_utils.gpt.handle_response(p);});},send:function(){var r=[],q=function(s,t){if(d(t)){t=t.join("","");}if(t){r.push(s+""=""+encodeURIComponent(""""+t));}},o,p;if(h.length===0){tinygpt.callback({});return;}q(""gdfp_req"",""1"");q(""correlator"",Math.floor(4503599627370496*Math.random()));q(""output"",""json_html"");q(""callback"",""tinygpt.callback"");q(""impl"",""fifs"");q(""json_a"",""1"");result=f();q(""iu_parts"",result.iu_parts);q(""enc_prev_ius"",result.enc_prev_ius);q(""prev_iu_szs"",c());q(""prev_scp"",m());q(""cust_params"",a(k,true));o=document.createElement(""script"");p=document.getElementsByTagName(""script"")[0];o.async=true;o.type=""text/javascript"";o.src=""http://pubads.g.doubleclick.net/gampad/ads?""+r.join(""&"");o.id=""tinygpt"";o.onload=o.onerror=o.onreadystatechange=e;l=true;p.parentNode.insertBefore(o,p);b=+new Date();}};})();</script>
<script>
tinygpt.define_slot('/4215/imdb2.consumer.title/maindetails',
[[300,250],[300,600],[300,300],[11,1]],
'top_rhs',
{
'p': ['tr']
});
tinygpt.define_slot('/4215/imdb2.consumer.title/maindetails',
[[728,90],[1008,150],[1008,200],[1008,30],[970,250],[1008,400],[9,1]],
'top_ad',
{
'p': ['top','t']
});
tinygpt.set_targeting({
'g' : ['ro','co','brc','ac'],
'tt' : ['f'],
'm' : ['PG13'],
'mh' : ['PG13'],
'ml' : ['PG13'],
'coo' : ['us','gb','ca','jp'],
'b' : [],
'fv' : ['1'],
'id' : ['tt0446029'],
'ab' : ['a'],
'bpx' : ['2'],
'md' : ['tt0446029'],
's' : ['3075','32'],
'u': ['973136698718'],
'oe': ['utf-8']
});
tinygpt.send();
</script>
<!-- begin ads header -->
<script src=""http://ia.media-imdb.com/images/G/01/imdbads/js/collections/ads-2207842331._CB349580361_.js""></script>
<script>
doWithAds = function(){};
</script>
<script>
doWithAds = function(inside, failureMessage){
if ('consoleLog' in window &&
'generic' in window &&
'ad_utils' in window &&
'custom' in window &&
'monitoring' in generic &&
'document_is_ready' in generic) {
try{
inside.call(this);
}catch(e) {
if ( window.ueLogError ) {
if(typeof failureMessage !== 'undefined'){
e.message = failureMessage;
}
e.attribution = ""Advertising"";
e.logLevel = ""ERROR"";
ueLogError(e);
}
if( (document.location.hash.match('debug=1')) &&
(typeof failureMessage !== 'undefined') ){
console.error(failureMessage);
}
}
} else {
if( (document.location.hash.match('debug=1')) &&
(typeof failureMessage !== 'undefined') ){
console.error(failureMessage);
}
}
};
</script><script>
doWithAds(function(){
generic.monitoring.record_metric(""ads_js_request_to_done"", (new Date().getTime()) - window.ads_js_start);
ad_utils.weblab.set_treatment('gpt single-request', 'Use GPT ad requests.');
generic.monitoring.enable_weblab_metrics('107', '2', [
'csm_core_ads_load', 'csm_core_ads_iframe', 'csm_core_ads_reflow', 'csm_core_ads_tagdeliver', 'csm_core_ads_request',
'csm_top_ad_load', 'csm_top_ad_iframe', 'csm_top_ad_reflow', 'csm_top_ad_tagdeliver', 'csm_top_ad_request',
'csm_top_rhs_load', 'csm_top_rhs_iframe', 'csm_top_rhs_reflow', 'csm_top_rhs_tagdeliver', 'csm_top_rhs_request',
'top_ad.got_ad', 'top_rhs.got_ad', 'injected_billboard.got_ad', 'injected_navstrip.got_ad', 'bottom_ad.got_ad',
'top_ad.blank', 'top_rhs.blank', 'injected_billboard.blank', 'injected_navstrip.blank', 'bottom_ad.blank',
'top_ad.null', 'top_rhs.null', 'injected_billboard.null', 'injected_navstrip.null', 'bottom_ad.null',
'page_load'
]);
generic.monitoring.set_forester_info(""title"");
generic.monitoring.set_twilight_info(
""title"",
""CA"",
""fa5f2124275ce11295345535f6f5e98daaffa336"",
""2014-08-12T02%3A24%3A25GMT"",
""http://s.media-imdb.com/twilight/?"",
""consumer"");
generic.send_csm_head_metrics && generic.send_csm_head_metrics();
generic.monitoring.start_timing(""page_load"");
generic.seconds_to_midnight = 16535;
generic.days_to_midnight = 0.1913773119449616;
ad_utils.set_slots_on_page({ 'injected_navstrip':1, 'top_ad':1, 'top_rhs':1, 'navboard':1, 'btf_rhs2':1, 'bottom_ad':1, 'injected_billboard':1, 'rhs_cornerstone':1 });
custom.full_page.data_url = ""http://ia.media-imdb.com/images/G/01/imdbads/js/graffiti_data-1150089811._CB336142543_.js"";
consoleLog('advertising initialized','ads');
},""ads js missing, skipping ads setup."");
var _gaq = _gaq || [];
_gaq.push(['_setCustomVar', 4, 'ads_abtest_treatment', 'a']);
</script>
<script>
doWithAds(function(){
ad_utils.register_punt_ad(""top_rhs"",""300"",""250"","" \r\n\r\n<a target=\""_blank\"" href=\""http://aax-us-east.amazon-adsystem.com/x/c/QbyMJEp64Nq3run2paBMCxsAAAFHyAfhEgEAAADKx1VW5Q/http://pda-bes.amazon.com/c?i=1$AgAAAAAAAAAEAAAAAAAAAAMAAAAA2TZhzMc.XRS7ZCVLPNk48DJzqAjyDalzKLcbgkj7bSNwSSwJtLkdLoh8mxGx0HlDE.7mMgdDshuZ7oRXF1QMP0-gx8H.rTnTNyIdtItDShAA8mk2yG29FpkhSZ6dfKparRb6EE4UerUe3AOnRkjzJrrD3trH-yrOrM4mOT4O3eiZYJW63bAWWm6pDSBkdVTXYDbbF0eObJKKzbNPdpoTpiUCIpvAdINj3U824BeWkTjSyefy09yxNELX.htQlgbiD5ocS8hyDzO3jTq0D9XRWVsndFuzENK8byONcI2mzrJSCCYNXcj-Q7yvXnpQt7L5EKUVQNQiVCTzYJbXTi29A1FXHiwskD7YwywYlLZFpdqZ2LvcU445E-xVnUPdA9nXTWlxGRlGt09OzW8DmNoJXe0vLmgmB.hzYEwXHjJns9dGJFalbdhiR9h3LqJ.gRu9fZ1UMs-YZZo9acDbCxdrx8MKi.9RXUTxA9KXMjJ.9WqdFfvS033HTI4CO9N48hxR7yE1Cy-iq4swHrDhcQrqhfmiA6qXE76DcJNOvq.qRW-Yic.TT0ipQSTnu43QwhCMDKvdUm1eKqOn6ba2hlTudQ5Lb-Ka0UAnSm8OJhEe0eKFhrerCqQD8zIfVxmZyghSOYykZTKp0wWoSaBVafoouxpQBvaJKWleaQ3bqiMSr362oPSQRgNNySA3-MeZG401PtnYGxP1o9PuvjsdtSFryCo7Rl9an.HUY4M6Sr4CbdmrYKn09crOkvDJmjga0JwzY8XZEuhFwJY-TcX7kBhWfyxCctwj-xNa4wRlmTy7lY25J2wFWyhrY2Mur6pY0TYiPUYi1plv1LhtjGtDZW7bZTyfiwMr0U55y7NMpipIgPSkb.gjD5SKcGLxDJjHt12OC7wBdpY9srzyXOCceoe32i7SDL5GpvWN1byZIDhFUQjETT5d8lImH9mTaGi3Ys7Xe7NJ8r3yia.yRUQWkIp4LGpLOZOpcg3wPlOG4IZWfppwMCzqqr-U-axUatpWsAlt9oFR8ppb8cMv4X3PdBPSPo9HVspgpxigSKcOoiPllxRSwYs7plRApHWLyOEPcR18B1psLBYSVfCCvJ.cfx6WsfRymnZzg1UZi5jkagow1m9jN1UVoQ8ZOFhU1cdaSSvLdO4wLwz4FLiIE8jLnE63h4AdZJWC8QIhqjc0QKrJ5q5-FKA2cjPZX-7qIP9dSQs1.90ASbPUN5yXnVul-C7SNZJ0LkPLMK4OwINx.Bd.R9h9WCsNBnRLc9NrZ8Hk.mJEfG3JbXg1JFhYofcG9id0T.RbX86hNG0JgH3ICRKtMfxgvNSaG-Ayn6A.yQMdwWNZReZRV68BAaA5oI1PNaeIpms3aZBXtzybasIJx.qd6QZAdquBT-r5ITUx6cgD-hsmzafluS5C3YZ.wn3m5x6eMeIh3zvHp2uV6-A7G7lH6aQKNroC0Z-Uug6ASXjwTgdloRx-ng__\""><img src=\""//d2o307dm5mqftz.cloudfront.net/1505855001/1395677029443/ca_imdb_300.gif\"" alt=\""\"" title=\""\"" width=\""300\"" height=\""250\"" border=\""0\""></a>\r\n\r\n<\!-- creativeModDate = 1407807370000 --\>\n <div id=\""top_rhs_webbug\"" style=\""display:none;\"">\n <img src=\""http://aax-us-east.amazon-adsystem.com/e/loi/imp?b=a7c37b7a-ddf3-455f-a6c6-70c6c0f0778e&pj=[PUNT_ORIGIN]\"" border=\""0\"" height=\""1\"" width=\""1\"" alt=\""\""/>\n </div>\n"");
}, ""ad_utils not defined, skipping punt ad data setup."");
</script>
<script>
doWithAds(function(){
ad_utils.register_punt_ad(""top_ad"",""728"",""90"","" \r\n\r\n<a target=\""_blank\"" href=\""http://aax-us-east.amazon-adsystem.com/x/c/QW6Oa6l3s9V54dZDzpAmU74AAAFHyAfhCwEAAADK4rQIBg/http://pda-bes.amazon.com/c?i=1$AgAAAAAAAAAEAAAAAAAAAAMAAAAA2TZhzBjiQ4FWUUZh2CDjv4DlMFizP1-GmwizV-TD9p2kfRnPjyBu.XVnN.lK39v.MuTIfB-8-gQcrTJS6b0FA3eWqt366e4SHGJYdbwvQ1lmhqqBk7TCcTjotpEBOG0jenpmW7p5NnbWeNcJwv5QGbXHMKWChmONAfzNqRfRSwcTScpOukkOTVIb0o3GHQAOJiV37dBeX86xGP3uo8ezwMS-lV.Bjgc717YBZ.8Lejf-y9aD2xBuRqZHvcj7ecGAyqcoIcoBTCTLHZiqwxojT7I4HMJOepers8Oio7nS2-hcg.40eR9tBX5AjrbyhQHOsXXe9s09VnDC0AlOmX2QA40vOfgDYZn-.0.oKw6V5Xtv-qMm8cxvydiJRQPO1ulSYt9-0Y5Xw4Dqe5F5SeY9Y2cXeIK.0RZ4G18MFr62Uledba.8Ft2MV79LKq1QgARLjfQcCBOHbLZFVFd1LgdJgC1ITQgv.lM0adkZ2wUKdACBZGEPQwY--KXUD0rjA8jpWG3LJLZhN65Akbgkh4pvS3YuHd1lxvxjF3mAcvRtCJl8Ar7Pw1dkPIwSRq9OFCSMc3WNa2xGPf1jhW-.jmRniI-fIke4ueqOJFZNSOSLabCIA69d8r3ND.Jxjw3jsf70NHFJujOQ2B25ji9VeFb8vRYppHAcYNJH.igxzFXnA-64XmZ92HmkwcKZlkjEX7TzF2CC9Rc7NwZUrzgpNvrYOoj-jZwcBhSqM.lGhFoffwZ79WewlZK63Xl90BI-kutXKqSD5GYFf4dO1ISkQ9uw5HMALiFaG1pTUkvdS2R19G2VxzsV4sIvRPwkTIlEMx9ab8EGVbei-Ldrd84DPnbRy91soAm6gHF6-IWEmAKcg-n5L.JuAAQTcDlkKKA9M3fuqQdogJ5WvaAxx-jBM2QvSohrV1gfSXwFI6IUOuaxJe.tltyuNDNZl9Z-JIkkDJ3t3ZGjSU5XvTKyQ1jSLKJq9N3ZVj6bULxLpYXYjZlwGkECTpBj3HGGt4KFZu2VzWcXWeTVW4UVhnvqIV-zwKIUebtDFFI9FBGqrbAkYvLsN8vAuKp1Ff0oEZ8kJltNZ-2Wdr0XWKJL903YoMdR7hHc7wQM3FTy-ntTXqnZC195Iqd1vpcANK3tixo.7e3puCFyOLA9nQFvO1.0p-vMk0y-ahBj8QknqahjZiaKxmgNVzScGgFi0KA7KLsx.CliNBgS48HIOG0dGsROCMVTn3.LpJ.Tn053xatj4mf6QN.1t8Gng17dK1QGW5T2oMjdZi92bSO4iEpFhzLu86DKtzoAY4z3Z4N3SWH24HorPz3d5p13v6DjBOqomDfgvjSmrDyWXsBnoB7LPmEHFjXMBCo05bjjB-pO.xfz61MGTI7QIcLZGBOxS5HGiPFhfsnbQ0oB0dwskdwsstM65ndSeXOkmnORwQEXC..8xfDR0F9g8mCGPtWq\""><img src=\""//d2o307dm5mqftz.cloudfront.net/1505855001/1395681100916/728_imdb_ca.gif\"" alt=\""\"" title=\""\"" width=\""728\"" height=\""90\"" border=\""0\""></a>\r\n\r\n<\!-- creativeModDate = 1407807370000 --\>\n <div id=\""top_ad_webbug\"" style=\""display:none;\"">\n <img src=\""http://aax-us-east.amazon-adsystem.com/e/loi/imp?b=c54e74d5-197b-494f-8d8d-62ff9c9e8f83&pj=[PUNT_ORIGIN]\"" border=\""0\"" height=\""1\"" width=\""1\"" alt=\""\""/>\n </div>\n"");
}, ""ad_utils not defined, skipping punt ad data setup."");
</script>
<script>doWithAds(function() { ad_utils.ads_header.done(); });</script>
<!-- end ads header -->
        <script  type=""text/javascript"">
            // ensures js doesn't die if ads service fails.
            // Note that we need to define the js here, since ad js is being rendered inline after this.
            (function(f) {
                // Fallback javascript, when the ad Service call fails.
                if((window.csm === undefined || window.generic === undefined || window.consoleLog === undefined)) {
                    if (console !== undefined && console.log !== undefined) {
                        console.log(""one or more of window.csm, window.generic or window.consoleLog has been stubbed..."");
                    }
                }
                window.csm = window.csm || { measure:f, record:f, duration:f, listen:f, metrics:{} };
                window.generic = window.generic || { monitoring: { start_timing: f, stop_timing: f } };
                window.consoleLog = window.consoleLog || f;
            })(function() {});
        </script>
  <script>
    if ('csm' in window) {
      csm.measure('csm_head_delivery_finished');
    }
  </script>
        </head>
    <body id=""styleguide-v2"" class=""fixed"">
<script>
    if (typeof uet == 'function') {
      uet(""bb"");
    }
</script>
  <script>
    if ('csm' in window) {
      csm.measure('csm_body_delivery_started');
    }
  </script>
        <div id=""wrapper"">
            <div id=""root"" class=""redesign"">
<script>
    if (typeof uet == 'function') {
      uet(""ns"");
    }
</script>
<div id=""nb20"" class=""navbarSprite"">
<div id=""supertab"">
    <!-- begin TOP_AD -->
<div id=""top_ad_wrapper"" class=""dfp_slot"">
<script type=""text/javascript"">
doWithAds(function(){
ad_utils.register_ad('top_ad');
});
</script>
<iframe data-dart-params=""#imdb2.consumer.title/maindetails;!TILE!;sz=728x90,1008x150,1008x200,1008x30,970x250,1008x400,9x1;p=top;p=t;g=ro;g=co;g=brc;g=ac;tt=f;m=PG13;mh=PG13;ml=PG13;coo=us;coo=gb;coo=ca;coo=jp;fv=1;id=tt0446029;ab=a;bpx=2;md=tt0446029;s=3075;s=32;oe=utf-8;[CLIENT_SIDE_KEYVALUES];u=973136698718;ord=973136698718?"" id=""top_ad"" name=""top_ad"" class=""yesScript"" width=""0"" height=""0"" data-original-width=""0"" data-original-height=""0"" data-config-width=""0"" data-config-height=""0"" data-cookie-width=""null"" data-cookie-height=""null"" marginwidth=""0"" marginheight=""0"" frameborder=""0"" scrolling=""no"" allowtransparency=""true"" onload=""doWithAds.call(this, function(){ ad_utils.on_ad_load(this); });""></iframe>
<noscript><a href=""http://ad.doubleclick.net/N4215/jump/imdb2.consumer.title/maindetails;tile=1;sz=728x90,1008x150,1008x200,1008x30,970x250,1008x400,9x1;p=top;p=t;g=ro;g=co;g=brc;g=ac;tt=f;m=PG13;mh=PG13;ml=PG13;coo=us;coo=gb;coo=ca;coo=jp;fv=1;id=tt0446029;ab=a;bpx=2;md=tt0446029;s=3075;s=32;ord=973136698718?"" target=""_blank""><img src=""http://ad.doubleclick.net/N4215/ad/imdb2.consumer.title/maindetails;tile=1;sz=728x90,1008x150,1008x200,1008x30,970x250,1008x400,9x1;p=top;p=t;g=ro;g=co;g=brc;g=ac;tt=f;m=PG13;mh=PG13;ml=PG13;coo=us;coo=gb;coo=ca;coo=jp;fv=1;id=tt0446029;ab=a;bpx=2;md=tt0446029;s=3075;s=32;ord=973136698718?"" border=""0"" alt=""advertisement"" /></a></noscript>
</div>
<div id=""top_ad_reflow_helper""></div>
<script>
doWithAds(function(){
ad_utils.gpt.render_ad('top_ad');
}, ""ad_utils not defined, unable to render client-side GPT ad."");
</script>
<!-- End TOP_AD -->
</div>
  <div id=""navbar"" class=""navbarSprite"">
<noscript>
  <link rel=""stylesheet"" type=""text/css"" href=""http://ia.media-imdb.com/images/G/01/imdb/css/site/consumer-navbar-no-js-4175877511._CB379390803_.css"" />
</noscript>
<!--[if IE]><link rel=""stylesheet"" type=""text/css"" href=""http://ia.media-imdb.com/images/G/01/imdb/css/site/consumer-navbar-ie-470687728._CB379390980_.css""><![endif]-->
<span id=""home_img_holder"">
<a href=""/?ref_=nv_home""
title=""Home"" class=""navbarSprite"" id=""home_img"" ></a>  <span class=""alt_logo"">
    <a href=""/?ref_=nv_home""
title=""Home"" >IMDb</a>
  </span>
</span>
<form
onsubmit=""(new Image()).src='/rg/SEARCH-BOX/HEADER/images/b.gif?link=/find';""
 method=""get""
 action=""/find""
 class=""nav-searchbar-inner""
 id=""navbar-form""
>
  <div id=""nb_search"">
    <noscript><div id=""more_if_no_javascript""><a href=""/search/"">More</a></div></noscript>
    <button id=""navbar-submit-button"" class=""primary btn"" type=""submit""><div class=""magnifyingglass navbarSprite""></div></button>
    <input type=""text"" autocomplete=""off"" value="""" name=""q"" id=""navbar-query"" placeholder=""Find Movies, TV shows, Celebrities and more..."">
    <div class=""quicksearch_dropdown_wrapper"">
      <select name=""s"" id=""quicksearch"" class=""quicksearch_dropdown navbarSprite""
              onchange=""jumpMenu(this); suggestionsearch_dropdown_choice(this);"">
        <option value=""all"" >All</option>
        <option value=""tt"" >Titles</option>
        <option value=""ep"" >TV Episodes</option>
        <option value=""nm"" >Names</option>
        <option value=""co"" >Companies</option>
        <option value=""kw"" >Keywords</option>
        <option value=""ch"" >Characters</option>
        <option value=""qu"" >Quotes</option>
        <option value=""bi"" >Bios</option>
        <option value=""pl"" >Plots</option>
      </select>
    </div>
    <div id=""navbar-suggestionsearch""></div>
  </div>
</form>
<div id=""megaMenu"">
    <ul id=""consumer_main_nav"" class=""main_nav"">
        <li class=""spacer""></li>
        <li class=""css_nav_item"" id=""navTitleMenu"">
            <p class=""navCategory"">
                <a href=""/movies-in-theaters/?ref_=nv_tp_inth_1""
>Movies</a>,
                <a href=""/tv/?ref_=nv_tp_tvhm_2""
>TV</a><br />
                & <a href=""/showtimes/?ref_=nv_tp_sh_3""
>Showtimes</a></p>
            <span class=""downArrow""></span>
            <div id=""navMenu1"" class=""sub_nav"">
                <div id=""titleAd""></div>
                <div class=""subNavListContainer"">
                    <h5>MOVIES</h5>
                    <ul>
                        <li><a href=""/movies-in-theaters/?ref_=nv_mv_inth_1""
>In Theaters</a></li>
                        <li><a href=""/showtimes/?ref_=nv_mv_sh_2""
>Showtimes & Tickets</a></li>
                        <li><a href=""/trailers/?ref_=nv_mv_tr_3""
>Latest Trailers</a></li>
                        <li><a href=""/movies-coming-soon/?ref_=nv_mv_cs_4""
>Coming Soon</a></li>
                        <li><a href=""/calendar/?ref_=nv_mv_cal_5""
>Release Calendar</a></li>
                    </ul>
                    <h5>CHARTS & TRENDS</h5>
                    <ul>
                        <li><a href=""/search/title?count=100&title_type=feature%2Ctv_series&ref_=nv_ch_mm_1""
>Popular Movies & TV</a></li>
                        <li><a href=""/chart/?ref_=nv_ch_cht_2""
>Box Office</a></li>
                        <li><a href=""/search/title?count=100&groups=oscar_best_picture_winners&sort=year%2Cdesc&ref_=nv_ch_osc_3""
>Oscar Winners</a></li>
                        <li><a href=""/chart/top?ref_=nv_ch_250_4""
>Top 250</a></li>
                        <li><a href=""/genre/?ref_=nv_ch_gr_5""
>Most Popular by Genre</a></li>
                    </ul>
                </div>
                <div class=""subNavListContainer"">
                    <h5>TV & VIDEO</h5>
                    <ul>
                        <li><a href=""/tv/?ref_=nv_tvv_hm_1""
>TV Home</a></li>
                        <li><a href=""/tvgrid/?ref_=nv_tvv_ls_2""
>On Tonight</a></li>
                        <li><a href=""/watchnow/?ref_=nv_tvv_wn_3""
>Watch Now on Amazon</a></li>
                        <li><a href=""/sections/dvd/?ref_=nv_tvv_dvd_4""
>DVD & Blu-Ray</a></li>
                        <li><a href=""/tv/blog?ref_=nv_tvv_blog_5""
>TV Blog</a></li>
                    </ul>
                    <h5>SPECIAL FEATURES</h5>
                    <ul>
                        <li><a href=""/imdbpicks/?ref_=nv_sf_pks_1""
>IMDb Picks</a></li>
                        <li><a href=""/poll/?ref_=nv_sf_pl_2""
>Polls</a></li>
                        <li><a href=""/x-ray/?ref_=nv_sf_xray_3""
>X-Ray for Movies & TV</a></li>
                        <li><a href=""/whattowatch/?ref_=nv_sf_wtw_4""
>What to Watch</a></li>
                    </ul>
                </div>
            </div>
        </li>
        <li class=""spacer""></li>
        <li class=""css_nav_item"" id=""navNameMenu"">
            <p class=""navCategory"">
                <a href=""/search/name?gender=male%2Cfemale&ref_=nv_tp_cel_1""
>Celebs</a>,
                <a href=""/event/?ref_=nv_tp_ev_2""
>Events</a><br />
                & <a href=""/media/index/rg1176148480?ref_=nv_tp_ph_3""
>Photos</a></p>
            <span class=""downArrow""></span>
            <div id=""navMenu2"" class=""sub_nav"">
                <div id=""nameAd""></div>
                <div class=""subNavListContainer"">
                    <h5>CELEBS</h5>
                    <ul>
                            <li><a href=""/search/name?birth_monthday=08-12&refine=birth_monthday&ref_=nv_cel_brn_1""
>Born Today</a></li>
                        <li><a href=""/news/celebrity?ref_=nv_cel_nw_2""
>Celebrity News</a></li>
                        <li><a href=""/search/name?gender=male%2Cfemale&ref_=nv_cel_m_3""
>Most Popular Celebs</a></li>
                    </ul>
                    <h5>PHOTOS</h5>
                    <ul>
                        <li><a href=""/media/index/rg1176148480?ref_=nv_ph_ls_1""
>Latest Stills</a></li>
                        <li><a href=""/media/index/rg1528338944?ref_=nv_ph_lp_2""
>Latest Posters</a></li>
                        <li><a href=""/sections/photos/premieres/?ref_=nv_ph_prem_3""
>Movie & TV Premieres</a></li>
                        <li><a href=""/sections/photos/red_carpet/?ref_=nv_ph_red_4""
>On the Red Carpet</a></li>
                        <li><a href=""/sections/photos/special_galleries/?ref_=nv_ph_sp_5""
>Special Galleries</a></li>
                    </ul>
                </div>
                <div class=""subNavListContainer"">
                    <h5>EVENTS</h5>
                    <ul>
                        <li><a href=""/sxsw/?ref_=nv_ev_sxsw_1""
>SXSW Film Festival</a></li>
                        <li><a href=""/oscars/?ref_=nv_ev_rto_2""
>Road to the Oscars</a></li>
                        <li><a href=""/emmys/?ref_=nv_ev_rte_3""
>Road to the Emmys</a></li>
                        <li><a href=""/comic-con/?ref_=nv_ev_comic_4""
>Comic-Con</a></li>
                        <li><a href=""/cannes/?ref_=nv_ev_can_5""
>Cannes</a></li>
                        <li><a href=""/tribeca/?ref_=nv_ev_tri_6""
>Tribeca</a></li>
                        <li><a href=""/sundance/?ref_=nv_ev_sun_7""
>Sundance</a></li>
                        <li><a href=""/event/?ref_=nv_ev_all_8""
>More Popular Events</a></li>
                    </ul>
                </div>
            </div>
        </li>
        <li class=""spacer""></li>
        <li class=""css_nav_item"" id=""navNewsMenu"">
            <p class=""navCategory"">
                <a href=""/news/top?ref_=nv_tp_nw_1""
>News</a> &<br />
                <a href=""/boards/?ref_=nv_tp_bd_2""
>Community</a></p>
            <span class=""downArrow""></span>
            <div id=""navMenu3"" class=""sub_nav"">
                <div id=""latestHeadlines"">
                    <div class=""subNavListContainer"">
                        <h5>LATEST HEADLINES</h5>
    <ul>
                <li itemprop=""headline"">
<a href=""/news/ni57586962/?ref_=nv_nw_tn_1""
> Robin Williams Found Dead in Possible Suicide
</a><br />
                        <span class=""time"">3 hours ago</span>
                </li>
                <li itemprop=""headline"">
<a href=""/news/ni57586555/?ref_=nv_nw_tn_2""
> 'American Horror Story' Adds Patti Labelle to 'Freak Show' Ranks
</a><br />
                        <span class=""time"">5 hours ago</span>
                </li>
                <li itemprop=""headline"">
<a href=""/news/ni57586199/?ref_=nv_nw_tn_3""
> Ed Harris to Play Ultimate Villain on HBO's ‘Westworld’
</a><br />
                        <span class=""time"">7 hours ago</span>
                </li>
    </ul>
                    </div>
                </div>
                <div class=""subNavListContainer"">
                    <h5>NEWS</h5>
                    <ul>
                        <li><a href=""/news/top?ref_=nv_nw_tp_1""
>Top News</a></li>
                        <li><a href=""/news/movie?ref_=nv_nw_mv_2""
>Movie News</a></li>
                        <li><a href=""/news/tv?ref_=nv_nw_tv_3""
>TV News</a></li>
                        <li><a href=""/news/celebrity?ref_=nv_nw_cel_4""
>Celebrity News</a></li>
                        <li><a href=""/news/indie?ref_=nv_nw_ind_5""
>Indie News</a></li>
                    </ul>
                    <h5>COMMUNITY</h5>
                    <ul>
                        <li><a href=""/boards/?ref_=nv_cm_bd_1""
>Message Boards</a></li>
                        <li><a href=""/czone/?ref_=nv_cm_cz_2""
>Contributor Zone</a></li>
                        <li><a href=""/games/guess?ref_=nv_cm_qz_3""
>Quiz Game</a></li>
                        <li><a href=""/poll/?ref_=nv_cm_pl_4""
>Polls</a></li>
                    </ul>
                </div>
            </div>
        </li>
        <li class=""spacer""></li>
        <li class=""css_nav_item"" id=""navWatchlistMenu"">
<p class=""navCategory singleLine watchlist"">
    <a href=""/list/watchlist?ref_=nv_wl_all_0""
>Watchlist</a>
</p>
<span class=""downArrow""></span>
<div id=""navMenu4"" class=""sub_nav"">
    <h5>
            YOUR WATCHLIST
    </h5>
    <ul id=""navWatchlist"">
    </ul>
    <script>
    if (!('imdb' in window)) { window.imdb = {}; }
    window.imdb.watchlistTeaserData = [
                {
                        href : ""/list/watchlist"",
                src : ""http://ia.media-imdb.com/images/G/01/imdb/images/navbar/watchlist_slot1_logged_out-1670046337._CB360061167_.jpg""
                },
                {
                    href : ""/search/title?count=100&title_type=feature,tv_series"",
                src : ""http://ia.media-imdb.com/images/G/01/imdb/images/navbar/watchlist_slot2_popular-4090757197._CB360060945_.jpg""
                },
                {
                    href : ""/chart/top"",
                src : ""http://ia.media-imdb.com/images/G/01/imdb/images/navbar/watchlist_slot3_top250-575799966._CB360061165_.jpg""
                }
    ];
    </script>
</div>
        </li>
        <li class=""spacer""></li>
    </ul>
<script>
if (!('imdb' in window)) { window.imdb = {}; }
window.imdb.navbarAdSlots = {
    titleAd : {
            clickThru : ""/title/tt0050083/"",
            imageUrl : ""http://ia.media-imdb.com/images/M/MV5BMTk0MDEzMjI3NV5BMl5BanBnXkFtZTcwODg4NDc3Mw@@._V1._SX430_CR10,10,410,315_.jpg"",
            titleYears : ""1957"",
            rank : 8,
                    headline : ""12 Angry Men""
    },
    nameAd : {
            clickThru : ""/name/nm0424060/"",
            imageUrl : ""http://ia.media-imdb.com/images/M/MV5BMTc1ODIxOTA1OV5BMl5BanBnXkFtZTcwNDY5MDc1NA@@._V1._SX300_CR15,30,250,315_BR10_CT10_.jpg"",
            rank : 7,
            headline : ""Scarlett Johansson""
    }
}
</script>
</div>
<div id=""nb_extra"">
    <ul id=""nb_extra_nav"" class=""main_nav"">
        <li class=""css_nav_item"" id=""navProMenu"">
            <p class=""navCategory"">
<a href=""http://pro.imdb.com/signup/index.html?rf=cons_nb_hm&ref_=cons_nb_hm""
> <img alt=""IMDbPro Menu"" src=""http://ia.media-imdb.com/images/G/01/imdb/images/navbar/imdbpro_logo_nb-720143162._CB377744227_.png"" />
</a>            </p>
            <span class=""downArrow""></span>
            <div id=""navMenuPro"" class=""sub_nav"">
<a href=""http://pro.imdb.com/signup/index.html?rf=cons_nb_hm&ref_=cons_nb_hm""
id=""proLink"" > <div id=""proAd"">
<script>
if (!('imdb' in window)) { window.imdb = {}; }
window.imdb.proMenuTeaser = {
imageUrl : ""http://ia.media-imdb.com/images/G/01/imdb/images/navbar/imdbpro_menu_user-2082544740._CB377744226_.jpg""
};
</script>
</div>
<div class=""subNavListContainer"">
<img alt=""Go to IMDbPro"" title=""Go to IMDbPro"" src=""http://ia.media-imdb.com/images/G/01/imdb/images/navbar/imdbpro_logo_menu-2185879182._CB377744253_.png"" />
<h5>GET INFORMED</h5>
<p>Industry information at your fingertips</p>
<h5>GET CONNECTED</h5>
<p>Over 200,000 Hollywood insiders</p>
<h5>GET DISCOVERED</h5>
<p>Enhance your IMDb Page</p>
<p><strong>Go to IMDbPro &raquo;</strong></p>
</div>
</a>            </div>
        </li>
        <li class=""spacer""><span class=""ghost"">|</span></li>
        <li>
            <a href=""/apps/?ref_=nb_app""
>IMDb Apps</a>
        </li>
        <li class=""spacer""><span class=""ghost"">|</span></li>
        <li>
            <a href=""/help/?ref_=nb_hlp""
>Help</a>
        </li>
    </ul>
</div>
<div id=""nb_personal"">
    <ul id=""consumer_user_nav"" class=""main_nav"">
        <li class=""css_nav_menu"" id=""navUserMenu"">
            <p class=""navCategory singleLine"">
                <a href=""/register/login?ref_=nv_usr_lgin_1""
rel=""login"" id=""nblogin"" >Login</a>
            </p>
            <span class=""downArrow""></span>
            <div class=""sub_nav"">
                <div class=""subNavListContainer"">
                    <br />
                    <ul>
                        <li>
                            <a href=""https://secure.imdb.com/register-imdb/form-v2?ref_=nv_usr_reg_2""
>Register</a>
                        </li>
                        <li>
                            <a href=""/register/login?ref_=nv_usr_lgin_3""
rel=""login"" id=""nblogin"" >Login</a>
                        </li>
                    </ul>
                </div>
            </div>
        </li>
    </ul>
</div>
  </div>
</div>
    <!-- no content received for slot: navstrip -->
    <!-- begin injectable INJECTED_NAVSTRIP -->
<div id=""injected_navstrip_wrapper"" class=""injected_slot"">
<iframe id=""injected_navstrip"" name=""injected_navstrip"" class=""yesScript"" width=""0"" height=""0"" data-dart-params=""#imdb2.consumer.title/maindetails;oe=utf-8;u=973136698718;ord=973136698718?"" data-original-width=""0"" data-original-height=""0"" data-config-width=""0"" data-config-height=""0"" data-cookie-width=""null"" data-cookie-height=""null"" marginwidth=""0"" marginheight=""0"" frameborder=""0"" scrolling=""no"" allowtransparency=""true"" onload=""doWithAds.call(this, function(){ ad_utils.on_ad_load(this); });""></iframe> </div>
<script>
doWithAds(function(){
ad_utils.inject_ad.register('injected_navstrip');
}, ""ad_utils not defined, unable to render injected ad."");
</script>
<div id=""injected_navstrip_reflow_helper""></div>
<!-- end injectable INJECTED_NAVSTRIP -->
<script>
    if (typeof uet == 'function') {
      uet(""ne"");
    }
</script>
                    <div id=""pagecontent"" itemscope itemtype=""http://schema.org/Movie"">
    <!-- begin injectable INJECTED_BILLBOARD -->
<div id=""injected_billboard_wrapper"" class=""injected_slot"">
<iframe id=""injected_billboard"" name=""injected_billboard"" class=""yesScript"" width=""0"" height=""0"" data-dart-params=""#imdb2.consumer.title/maindetails;oe=utf-8;u=973136698718;ord=973136698718?"" data-original-width=""0"" data-original-height=""0"" data-config-width=""0"" data-config-height=""0"" data-cookie-width=""null"" data-cookie-height=""null"" marginwidth=""0"" marginheight=""0"" frameborder=""0"" scrolling=""no"" allowtransparency=""true"" onload=""doWithAds.call(this, function(){ ad_utils.on_ad_load(this); });""></iframe> </div>
<script>
doWithAds(function(){
ad_utils.inject_ad.register('injected_billboard');
}, ""ad_utils not defined, unable to render injected ad."");
</script>
<div id=""injected_billboard_reflow_helper""></div>
<!-- end injectable INJECTED_BILLBOARD -->
    <!-- begin NAVBOARD -->
<div id=""navboard_wrapper"" class=""cornerstone_slot"">
<script type=""text/javascript"">
doWithAds(function(){
ad_utils.register_ad('navboard');
});
</script>
<iframe id=""navboard"" name=""navboard"" class=""yesScript"" width=""1008"" height=""377"" data-original-width=""1008"" data-original-height=""377"" data-blank-serverside marginwidth=""0"" marginheight=""0"" frameborder=""0"" scrolling=""no"" allowtransparency=""true"" onload=""doWithAds.call(this, function(){ ad_utils.on_ad_load(this); });"" allowfullscreen=""true""></iframe>
</div>
<div id=""navboard_reflow_helper""></div>
<script>
doWithAds(function(){
ad_utils.inject_serverside_ad('navboard', '');
},""unable to inject serverside ad"");
</script>
<div id=""content-2-wide"" class=""redesign"">
    <div class=""maindetails_center"" id=""maindetails_center_top"">


    <div class=""watchbar2"">
        <div class=""showtime"">
        <section id=""watchbar2"" class=""winner provider amazon "" data-winner=""physical"" data-href=""/offsite/?page-action=watch-amazon&token=BCYsbc4uSjBBW9wDF8WDfEmYBmwJBqAAor_y53ez7TMggI1DlvDuIi3vhkJQEqIWxezbYPnn9hts%0D%0AQs1kj4DRn7Zn0bOSTfS0DaztBFlX85s48odHWlO1jiN22eDYiC4jwIyFPdlKVjK6LFOY_YyTOf9o%0D%0AVoUJbfG6xDgEmdbdbv6R-oGoBEtgChZbVRpUcoUeLAso2CjabxlnA71If_uFvBaBqSv7OwEdXv2-%0D%0AgXfYf0SZ2BE%0D%0A&ref_=tt_wbr_amazon_t2"" title=""Watch on Disc"">
            <div>
            <h2>
<a href=""/offsite/?page-action=watch-amazon&token=BCYsbc4uSjBBW9wDF8WDfEmYBmwJBqAAor_y53ez7TMggI1DlvDuIi3vhkJQEqIWxezbYPnn9hts%0D%0AQs1kj4DRn7Zn0bOSTfS0DaztBFlX85s48odHWlO1jiN22eDYiC4jwIyFPdlKVjK6LFOY_YyTOf9o%0D%0AVoUJbfG6xDgEmdbdbv6R-oGoBEtgChZbVRpUcoUeLAso2CjabxlnA71If_uFvBaBqSv7OwEdXv2-%0D%0AgXfYf0SZ2BE%0D%0A&ref_=tt_wbr_amazon_t2""
class=""segment-link "" target=""_blank""> On Disc
</a>            </h2>
            <p>
            at Amazon
            </p>
            </div>
        </section>
        </div>
    </div>
            <div class=""article title-overview"">
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleOverviewWidget_started');
    }
  </script>
    <div id=""title-overview-widget"">
        <table cellspacing=""0"" cellpadding=""0"" border=""0"" id=""title-overview-widget-layout"">
            <tbody>
                <tr>
                    <td rowspan=""2"" id=""img_primary"">
                            <div class=""image"">
<a href=""/media/rm483232768/tt0446029?ref_=tt_ov_i""
> <img height=""317""
width=""214""
alt=""Scott Pilgrim vs. the World (2010) Poster""
title=""Scott Pilgrim vs. the World (2010) Poster""
src=""http://ia.media-imdb.com/images/M/MV5BMTkwNTczNTMyOF5BMl5BanBnXkFtZTcwNzUxOTUyMw@@._V1_SY317_CR0,0,214,317_AL_.jpg""
itemprop=""image"" />
</a>                            </div>
        <div class=""pro-title-link text-center"">
<a href=""http://pro.imdb.com/title/tt0446029?rf=cons_tt_contact&ref_=cons_tt_contact""
>Contact the Filmmakers on IMDbPro &raquo;</a>
        </div>
                    </td>
                    <td id=""overview-top"">
    <div id=""prometer_container"">
        <div id=""prometer"" class=""meter-collapsed up"">
            <div id=""meterHeaderBox"">
                <div id=""meterTitle"" class=""meterToggleOnHover"">MOVIEmeter</div>
<a href=""http://pro.imdb.com/title/tt0446029?rf=cons_tt_meter&ref_=cons_tt_meter""
id=""meterRank"" >Top 500
</a>            </div>
            <div id=""meterChangeRow"" class=""meterToggleOnHover"">
                    <span>Up</span>
                <span id=""meterChange"">256</span>
                <span>this week</span>
            </div>
            <div id=""meterSeeMoreRow"" class=""meterToggleOnHover"">
<a href=""http://pro.imdb.com/title/tt0446029?rf=cons_tt_meter&ref_=cons_tt_meter""
>View rank on IMDbPro</a>
                <span>&raquo;</span>
            </div>
        </div>
    </div>
<h1 class=""header""> <span class=""itemprop"" itemprop=""name"">Scott Pilgrim vs. the World</span>
            <span class=""nobr"">(<a href=""/year/2010/?ref_=tt_ov_inf""
>2010</a>)</span>
</h1>
    <div class=""infobar"">
            <span itemprop=""contentRating"" content=""PG"" class=""certRating"">PG</span>
            <time itemprop=""duration"" datetime=""PT112M"" >
                112 min
</time>
                &nbsp;-&nbsp;
<a href=""/genre/Action?ref_=tt_ov_inf""
><span class=""itemprop"" itemprop=""genre"">Action</span></a>
 <span class=""ghost"">|</span>
<a href=""/genre/Comedy?ref_=tt_ov_inf""
><span class=""itemprop"" itemprop=""genre"">Comedy</span></a>
 <span class=""ghost"">|</span>
<a href=""/genre/Romance?ref_=tt_ov_inf""
><span class=""itemprop"" itemprop=""genre"">Romance</span></a>
                &nbsp;-&nbsp;
            <span class=""nobr"">
<a href=""/title/tt0446029/releaseinfo?ref_=tt_ov_inf+""
title=""See all release dates"" > 13 August 2010<meta itemprop=""datePublished"" content=""2010-08-13"" />
(Canada)
</a>            </span>
    </div>
<div class=""star-box giga-star"">
        <div class=""titlePageSprite star-box-giga-star""> 7.5 </div>
    <div class=""star-box-rating-widget"">
            <span class=""star-box-rating-label"">Your rating:</span>
<div class=""rating rating-list"" data-starbar-class=""rating-list"" data-auth="""" data-user="""" id=""tt0446029|imdb|0|0|title-maindetails|tt0446029|title|main"" data-ga-identifier=""""
title=""Users rated this 7.5/10 (212,156 votes) - click stars to rate"" >
<span class=""rating-bg"">&nbsp;</span>
<span class=""rating-imdb "" style=""width: 0px"">&nbsp;</span>
<span class=""rating-stars"">
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>1</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>2</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>3</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>4</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>5</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>6</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>7</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>8</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>9</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>10</span></a>
</span>
<span class=""rating-rating ""><span class=""value"">-</span><span class=""grey"">/</span><span class=""grey"">10</span></span>
<span class=""rating-cancel ""><a href=""/title/tt0446029/vote?v=X;k="" title=""Delete"" rel=""nofollow""><span>X</span></a></span>
&nbsp;</div>
    </div>
    <div class=""star-box-details"" itemtype=""http://schema.org/AggregateRating"" itemscope itemprop=""aggregateRating"">
            Ratings:
<strong><span itemprop=""ratingValue"">7.5</span></strong><span class=""mellow"">/<span itemprop=""bestRating"">10</span></span>            from <a href=""ratings?ref_=tt_ov_rt""
title=""212,156 IMDb users have given a weighted average vote of 7.5/10"" > <span itemprop=""ratingCount"">212,156</span> users
</a>&nbsp;
            Metascore: <a href=""criticreviews?ref_=tt_ov_rt""
title=""69 review excerpts provided by Metacritic.com"" > 69/100
</a>            <br/>
            Reviews:
<a href=""reviews?ref_=tt_ov_rt""
title=""494 IMDb user reviews"" > <span itemprop=""reviewCount"">494 user</span>
</a>
                <span class=""ghost"">|</span>
<a href=""externalreviews?ref_=tt_ov_rt""
title=""379 IMDb critic reviews"" > <span itemprop=""reviewCount"">379 critic</span>
</a>
                <span class=""ghost"">|</span>
<a href=""criticreviews?ref_=tt_ov_rt""
title=""38 review excerpts provided by Metacritic.com"" > 38
</a>                from
<a href=""http://www.metacritic.com""
target='_blank'> Metacritic.com
</a>
    </div>
    <div class=""clear""></div>
</div>
                        <p></p>
<p itemprop=""description"">
Scott Pilgrim must defeat his new girlfriend's seven evil exes in order to win her heart.</p>
                        <p></p>
    <div class=""txt-block"" itemprop=""director"" itemscope itemtype=""http://schema.org/Person"">
        <h4 class=""inline"">Director:</h4>
<a href=""/name/nm0942367/?ref_=tt_ov_dr""
itemprop='url'><span class=""itemprop"" itemprop=""name"">Edgar Wright</span></a>
    </div>
    <div class=""txt-block"" itemprop=""creator"" itemscope itemtype=""http://schema.org/Person"">
        <h4 class=""inline"">Writers:</h4>
<a href=""/name/nm0045209/?ref_=tt_ov_wr""
itemprop='url'><span class=""itemprop"" itemprop=""name"">Michael Bacall</span></a>               (screenplay),
<a href=""/name/nm0942367/?ref_=tt_ov_wr""
itemprop='url'><span class=""itemprop"" itemprop=""name"">Edgar Wright</span></a>               (screenplay), <a href=""fullcredits?ref_=tt_ov_wr#writers""
>1 more credit</a>&nbsp;&raquo;
    </div>
                          <div class=""txt-block"" itemprop=""actors"" itemscope itemtype=""http://schema.org/Person"">
                            <h4 class=""inline"">Stars:</h4>
<a href=""/name/nm0148418/?ref_=tt_ov_st""
itemprop='url'><span class=""itemprop"" itemprop=""name"">Michael Cera</span></a>,
<a href=""/name/nm0935541/?ref_=tt_ov_st""
itemprop='url'><span class=""itemprop"" itemprop=""name"">Mary Elizabeth Winstead</span></a>,
<a href=""/name/nm0001085/?ref_=tt_ov_st""
itemprop='url'><span class=""itemprop"" itemprop=""name"">Kieran Culkin</span></a>                          <span class=""ghost"">|</span>
                          <span class=""see-more inline nobr"">
<a href=""fullcredits?ref_=tt_ov_st_sm""
itemprop='url'> See full cast and crew</a> &raquo;
                          </span>
                        </div>
                   </td>
                </tr>
                <tr>
                    <td id=""overview-bottom"">
                        <div class=""wlb_classic_wrapper"">
                          <span class=""wlb_wrapper"">
                            <a class=""wlb_watchlist_btn"" data-tconst=""tt0446029"" data-size=""large"" data-caller-name=""title"" data-type=""primary"" data-show-message=""1"">
                            </a>
                            <a class=""wlb_dropdown_btn"" data-tconst=""tt0446029"" data-size=""large"" data-caller-name=""title"" data-type=""primary"">
                            </a>
                          </span>
                          <div class=""wlb_dropdown_list"" style=""display:none;"">
                          </div>
                          <div class=""wlb_alert"" style=""display:none"">
                          </div>
                        </div>
<a href=""/video/imdb/vi1217070617/?ref_=tt_ov_vi""
class=""btn2 btn2_text_on large title-trailer video-colorbox"" data-type=""recommends"" data-tconst=""tt0446029"" data-video=""vi1217070617"" data-context=""imdb"" itemprop=""trailer""> <span class=""btn2_text"">Watch Trailer</span>
</a>
<div id=""share-checkin"">
<div class=""add_to_checkins"" data-const=""tt0446029"" data-lcn=""title-maindetails"">
<span class=""btn2_wrapper""><a onclick='' class=""btn2 large btn2_text_on disabled checkins_action_btn""><span class=""btn2_glyph"">0</span><span class=""btn2_text"">Check in</span></a></span>    <div class=""popup checkin-dialog"">
        <a class=""small disabled close btn"">X</a>
        <span class=""beta"">Beta</span>
        <span class=""title"">I'm Watching This!</span>
        <div class=""body"">
            <div class=""info"">Keep track of everything you watch; tell your friends.
                <div class=""info_details"">
                    If your account is linked with Facebook and you have turned on sharing, this will show up in your activity feed. If not, you can turn on sharing 
                        <a
onclick=""(new Image()).src='/rg/unknown/unknown/images/b.gif?link=https://secure.imdb.com/register-imdb/sharing?ref=tt_checkin_share';""
href=""https://secure.imdb.com/register-imdb/sharing?ref=tt_checkin_share""
>here</a>
                    .
                </div>
            </div>
            <div class=""small message_box"">
                <div class=""hidden error""><h2>Error</h2> Please try again!</div>
                <div class=""hidden success""><h2>Added to Your Check-Ins.</h2> <a href=""/list/checkins"">View</a></div>
            </div>
            <textarea data-msg=""Enter a comment...""></textarea>
            <div class=""share"">
                <button class=""large primary btn""><span>Check in</span></button>
<!--
                    Check-ins are more fun when<br>
                    you <a href=""/register/sharing"">enable Facebook sharing</a>!
-->
            </div>
        </div>
    </div>
    <input type=""hidden"" name=""49e6c"" value=""4998"">
</div>
</div>
<span class=""btn2_wrapper""><a onclick='' class=""btn2 large btn2_text_on launch-share-popover""><span class=""btn2_glyph"">0</span><span class=""btn2_text"">Share...</span></a></span><div id=""share-popover"">
    <a class=""close-popover"" href=""#"">X</a>
    <h4>Share</h4>
    <a onclick=""window.open(&quot;http://www.facebook.com/sharer.php?u=http%3A%2F%2Fwww.imdb.com%2Frg%2Fs%2F3%2Ftitle%2Ftt0446029%3Fref_%3Dext_shr_fb_tt&quot;, 'newWindow', 'width=626,height=436'); return false;""
       href=""http://www.facebook.com/sharer.php?u=http%3A%2F%2Fwww.imdb.com%2Frg%2Fs%2F3%2Ftitle%2Ftt0446029%3Fref_%3Dext_shr_fb_tt""
       title=""Share on Facebook""
       class=""facebook""
       ref_=""tt_shr_fb""
       target=""_blank""><div class=""option facebook"">
                            <span class=""titlePageSprite share_facebook""></span>
                            <div>Facebook</div>
                        </div></a>
    <a onclick=""window.open(&quot;http://twitter.com/intent/tweet?text=Scott%20Pilgrim%20vs.%20the%20World%20(2010)%20-%20imdb.com%2Frg%2Fs%2F1%2Ftitle%2Ftt0446029%3Fref_%3Dext_shr_tw_tt&quot;, 'newWindow', 'width=815,height=436'); return false;""
       href=""http://twitter.com/intent/tweet?text=Scott%20Pilgrim%20vs.%20the%20World%20(2010)%20-%20imdb.com%2Frg%2Fs%2F1%2Ftitle%2Ftt0446029%3Fref_%3Dext_shr_tw_tt""
       title=""Share on Twitter""
       class=""twitter""
       ref_=""tt_shr_tw""
       target=""_blank""><div class=""option twitter"">
                            <span class=""titlePageSprite share_twitter""></span>
                            <div>Twitter</div>
                        </div></a>
    <a href=""mailto:?subject=IMDb%3A%20Scott%20Pilgrim%20vs.%20the%20World%20(2010)&body=IMDb%3A%20Scott%20Pilgrim%20vs.%20the%20World%20(2010)%0AScott%20Pilgrim%20must%20defeat%20his%20new%20girlfriend's%20seven%20evil%20exes%20in%20order%20to%20win%20her%20heart.%0Ahttp%3A%2F%2Fwww.imdb.com%2Frg%2Fem_share%2Ftitle_web%2Ftitle%2Ftt0446029%3Fref%3Dext_shr_eml_tt"" 
       title=""Share by e-mail""
       class=""""
       ref=""tt_shr_eml""><div class='option email'>
                        <span class='titlePageSprite share_email'></span>
                        <div>E-mail</div>
                    </div></a>

        <a href=""#"" class=""open-checkin-popover"">
            <div class=""option checkin"">
                <span class=""titlePageSprite share_checkin""></span>
                <div>Check in</div>
            </div>
        </a>
</div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleOverviewWidget_finished');
    }
  </script>
            </div>
  <script>
    if ('csm' in window) {
      csm.measure('csm_atf_main');
    }
  </script>
    </div>
<script>
    if (typeof uet == 'function') {
      uet(""cf"");
    }
</script>
<script>
    if (typeof uet == 'function') {
      uet(""af"");
    }
</script>

    <div id=""maindetails_sidebar_bottom"" class=""maindetails_sidebar"">
    <!-- begin TOP_RHS -->
<div id=""top_rhs_wrapper"" class=""dfp_slot"">
<script type=""text/javascript"">
doWithAds(function(){
ad_utils.register_ad('top_rhs');
});
</script>
<iframe data-dart-params=""#imdb2.consumer.title/maindetails;!TILE!;sz=300x250,300x600,300x300,11x1;p=tr;g=ro;g=co;g=brc;g=ac;tt=f;m=PG13;mh=PG13;ml=PG13;coo=us;coo=gb;coo=ca;coo=jp;fv=1;id=tt0446029;ab=a;bpx=2;md=tt0446029;s=3075;s=32;oe=utf-8;[CLIENT_SIDE_KEYVALUES];u=973136698718;ord=973136698718?"" id=""top_rhs"" name=""top_rhs"" class=""yesScript"" width=""300"" height=""250"" data-original-width=""300"" data-original-height=""250"" data-config-width=""300"" data-config-height=""250"" data-cookie-width=""null"" data-cookie-height=""null"" marginwidth=""0"" marginheight=""0"" frameborder=""0"" scrolling=""no"" allowtransparency=""true"" onload=""doWithAds.call(this, function(){ ad_utils.on_ad_load(this); });""></iframe>
<noscript><a href=""http://ad.doubleclick.net/N4215/jump/imdb2.consumer.title/maindetails;tile=0;sz=300x250,300x600,300x300,11x1;p=tr;g=ro;g=co;g=brc;g=ac;tt=f;m=PG13;mh=PG13;ml=PG13;coo=us;coo=gb;coo=ca;coo=jp;fv=1;id=tt0446029;ab=a;bpx=2;md=tt0446029;s=3075;s=32;ord=973136698718?"" target=""_blank""><img src=""http://ad.doubleclick.net/N4215/ad/imdb2.consumer.title/maindetails;tile=0;sz=300x250,300x600,300x300,11x1;p=tr;g=ro;g=co;g=brc;g=ac;tt=f;m=PG13;mh=PG13;ml=PG13;coo=us;coo=gb;coo=ca;coo=jp;fv=1;id=tt0446029;ab=a;bpx=2;md=tt0446029;s=3075;s=32;ord=973136698718?"" border=""0"" alt=""advertisement"" /></a></noscript>
</div>
<div id=""top_rhs_reflow_helper""></div>
<div id=""top_rhs_after"" class=""after_ad"" style=""visibility:hidden;"">
<a class=""yesScript"" href=""#"" onclick=""ad_utils.show_ad_feedback('top_rhs');return false;"" id=""ad_feedback_top_rhs"">ad feedback</a>
</div>
<script>
doWithAds(function(){
ad_utils.gpt.render_ad('top_rhs');
}, ""ad_utils not defined, unable to render client-side GPT ad."");
</script>
<!-- End TOP_RHS -->
  <script>
    if ('csm' in window) {
      csm.measure('csm_atf_sidebar');
    }
  </script>
    <div class=""aux-content-widget-3 links subnav"" div=""quicklinks"">
            <h3>Quick Links</h3>
        <div id=""maindetails_quicklinks"">
                <div class=""split_0"">    <ul class=""quicklinks"">
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/fullcredits?ref_=tt_ql_1""
class=""link"" >Full Cast and Crew</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/trivia?ref_=tt_ql_2""
class=""link"" >Trivia</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/quotes?ref_=tt_ql_3""
class=""link"" >Quotes</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/awards?ref_=tt_ql_4""
class=""link"" >Awards</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/board/?ref_=tt_ql_5""
class=""link"" >Message Board</a>
                </li>
    </ul>
</div>
                <div class=""split_1"">    <ul class=""quicklinks"">
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/plotsummary?ref_=tt_ql_6""
class=""link"" >Plot Summary</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/parentalguide?ref_=tt_ql_7""
class=""link"" >Parents Guide</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/reviews?ref_=tt_ql_8""
class=""link"" >User Reviews</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/releaseinfo?ref_=tt_ql_9""
class=""link"" >Release Dates</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/companycredits?ref_=tt_ql_10""
class=""link"" >Company Credits</a>
                </li>
    </ul>
</div>
        </div>
        <hr/>
        <div id=""full_subnav"">
        <h4>Details</h4>
    <ul class=""quicklinks"">
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/fullcredits?ref_=tt_ql_dt_1""
class=""link"" >Full Cast and Crew</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/releaseinfo?ref_=tt_ql_dt_2""
class=""link"" >Release Dates</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/officialsites?ref_=tt_ql_dt_3""
class=""link"" >Official Sites</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/business?ref_=tt_ql_dt_4""
class=""link"" >Box Office/Business</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/companycredits?ref_=tt_ql_dt_5""
class=""link"" >Company Credits</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/locations?ref_=tt_ql_dt_6""
class=""link"" >Filming Locations</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/technical?ref_=tt_ql_dt_7""
class=""link"" >Technical Specs</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/literature?ref_=tt_ql_dt_8""
class=""link ghost"" >Literature</a>
                </li>
    </ul>
        <h4>Storyline</h4>
    <ul class=""quicklinks"">
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/taglines?ref_=tt_ql_stry_1""
class=""link"" >Taglines</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/plotsummary?ref_=tt_ql_stry_2""
class=""link"" >Plot Summary</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/synopsis?ref_=tt_ql_stry_3""
class=""link"" >Synopsis</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/keywords?ref_=tt_ql_stry_4""
class=""link"" >Plot Keywords</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/parentalguide?ref_=tt_ql_stry_5""
class=""link"" >Parents Guide</a>
                </li>
    </ul>
        <h4>Did You Know?</h4>
    <ul class=""quicklinks"">
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/trivia?ref_=tt_ql_trv_1""
class=""link"" >Trivia</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/goofs?ref_=tt_ql_trv_2""
class=""link"" >Goofs</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/crazycredits?ref_=tt_ql_trv_3""
class=""link"" >Crazy Credits</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/quotes?ref_=tt_ql_trv_4""
class=""link"" >Quotes</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/alternateversions?ref_=tt_ql_trv_5""
class=""link"" >Alternate Versions</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/movieconnections?ref_=tt_ql_trv_6""
class=""link"" >Connections</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/soundtrack?ref_=tt_ql_trv_7""
class=""link"" >Soundtracks</a>
                </li>
    </ul>
        <h4>Photo & Video</h4>
    <ul class=""quicklinks"">
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/mediaindex?ref_=tt_ql_pv_1""
class=""link"" >Photo Gallery</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/videogallery?ref_=tt_ql_pv_2""
class=""link"" >Trailers and Videos</a>
                </li>
    </ul>
        <h4>Opinion</h4>
    <ul class=""quicklinks"">
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/awards?ref_=tt_ql_op_1""
class=""link"" >Awards</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/faq?ref_=tt_ql_op_2""
class=""link"" >FAQ</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/reviews?ref_=tt_ql_op_3""
class=""link"" >User Reviews</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/ratings?ref_=tt_ql_op_4""
class=""link"" >User Ratings</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/externalreviews?ref_=tt_ql_op_5""
class=""link"" >External Reviews</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/criticreviews?ref_=tt_ql_op_6""
class=""link"" >Metacritic Reviews</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/board/?ref_=tt_ql_op_7""
class=""link"" >Message Board</a>
                </li>
    </ul>
        <h4>TV</h4>
    <ul class=""quicklinks"">
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/tvschedule?ref_=tt_ql_tv_1""
class=""link ghost"" >TV Schedule</a>
                </li>
    </ul>
        <h4>Related Items</h4>
    <ul class=""quicklinks"">
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/news?ref_=tt_ql_rel_1""
class=""link"" >NewsDesk</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/showtimes/title/tt0446029?ref_=tt_ql_rel_2""
class=""link ghost"" >Showtimes</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""/title/tt0446029/externalsites?ref_=tt_ql_rel_3""
class=""link"" >External Sites</a>
                </li>
    </ul>
        <h4>Professional Services</h4>
    <ul class=""quicklinks"">
                <li class=""subnav_item_main"">
<a href=""http://pro.imdb.com/title/tt0446029?ref_=tt_ql_pro_1""
class=""link"" >Get more at IMDbPro</a>
                </li>
                <li class=""subnav_item_main"">
<a href=""https://secure.imdb.com/store/photos/?ref_=tt_ql_pro_2""
class=""link"" >Add posters & stills to this title</a>
                </li>
    </ul>
            <hr/>
        </div>
        <div class=""show_more""><span class=""titlePageSprite arrows show""></span>Explore More</div>
        <div class=""show_less""><span class=""titlePageSprite arrows hide""></span>Show Less</div>
    </div>
  <div class=""aux-content-widget-2"">
    <div class=""social"">
  <script type=""text/javascript"">generic.monitoring.start_timing(""facebook_like_iframe"");</script>
  <div class=""social_networking_like"">
    <iframe
      id=""iframe_like""
      name=""fbLikeIFrame_0""
      class=""social-iframe""
      scrolling=""no""
      frameborder=""0""
      allowTransparency=""allowTransparency""
      ref=""http://www.imdb.com/title/tt0446029/""
      width=280
      height=65></iframe>
  </div>
    </div>
  </div>
    <!-- begin RHS_CORNERSTONE -->
<div id=""rhs_cornerstone_wrapper"" class=""cornerstone_slot"">
<script type=""text/javascript"">
doWithAds(function(){
ad_utils.register_ad('rhs_cornerstone');
});
</script>
<iframe id=""rhs_cornerstone"" name=""rhs_cornerstone"" class=""yesScript"" width=""300"" height=""125"" data-original-width=""300"" data-original-height=""125"" data-blank-serverside marginwidth=""0"" marginheight=""0"" frameborder=""0"" scrolling=""no"" allowtransparency=""true"" onload=""doWithAds.call(this, function(){ ad_utils.on_ad_load(this); });"" allowfullscreen=""true""></iframe>
</div>
<div id=""rhs_cornerstone_reflow_helper""></div>
<script>
doWithAds(function(){
ad_utils.inject_serverside_ad('rhs_cornerstone', '');
},""unable to inject serverside ad"");
</script>
      <div class=""aux-content-widget-2"" >
        <h3>Related News</h3>
                    <div class=""news_item odd"" >
                        <span itemprop=""headline"" >
                            <a href=""/title/tt0446029/news?ref_=tt_nwr_1#ni57565711""
>The 'Harry Potter' Franchise Gets the 'Scott Pilgrim' Treatment in Trailer Mashup</a>
                        </span>
                        <br /><small>
                                <span itemprop=""datePublished"">
                                  5 August 2014
                                </span>
                                <span class=""ghost"">|</span><span itemprop=""provider"" >
                                        <a href=""/news/ns0000055?ref_=tt_nwr_1""
>Rope of Silicon</a>
                                </span>
                        </small>
                    </div>
                    <div class=""news_item even"" >
                        <span itemprop=""headline"" >
                            <a href=""/title/tt0446029/news?ref_=tt_nwr_2#ni57560740""
>Movie News Wrap Up: ‘Blackhat’, ‘Grasshopper Jungle’ & More</a>
                        </span>
                        <br /><small>
                                <span itemprop=""datePublished"">
                                  4 August 2014
                                </span>
                                <span class=""ghost"">|</span><span itemprop=""provider"" >
                                        <a href=""/news/ns0000040?ref_=tt_nwr_2""
>ScreenRant.com</a>
                                </span>
                        </small>
                    </div>
                    <div class=""news_item odd"" >
                        <span itemprop=""headline"" >
                            <a href=""/title/tt0446029/news?ref_=tt_nwr_3#ni57559058""
>Watch: 'Harry Potter' Cut in the Style of 'Scott Pilgrim vs. the World'</a>
                        </span>
                        <br /><small>
                                <span itemprop=""datePublished"">
                                  3 August 2014
                                </span>
                                <span class=""ghost"">|</span><span itemprop=""provider"" >
                                        <a href=""/news/ns0000034?ref_=tt_nwr_3""
>firstshowing.net</a>
                                </span>
                        </small>
                    </div>
            <div class=""see-more"">
                <a href=""/title/tt0446029/news?ref_=tt_nwr_sm""
>See all 3933 related articles</a>&nbsp;&raquo;
            </div>
      </div>
    <!-- no content received for slot: middle_rhs -->
        <div class=""aux-content-widget-2"">
            <div id=""relatedListsWidget"">
                <div class=""rightcornerlink"">
                    <a href=""/list/create?ref_=tt_rls""
>Create a list</a>&nbsp;&raquo;
                </div>
                <h3>User Lists</h3>
                <p>Related lists from IMDb users</p>
    <div class=""list-preview even"">
        <div class=""list-preview-item-narrow"">
<a href=""/list/ls000256938?ref_=tt_rls_1""
><img height=""86"" width=""86"" alt=""list image"" title=""list image""src=""/images/nopicture/medium/film.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SX86_CR0,0,86,86_AL_.jpg"" /></a>        </div>
        <div class=""list_name"">
            <strong><a href=""/list/ls000256938?ref_=tt_rls_1""
>Best Of 2010</a></strong>
        </div>
        <div class=""list_meta"">
            a list of 42 titles
            <br />created 22&nbsp;May&nbsp;2011
        </div>
        <div class=""clear"">&nbsp;</div>
    </div>
    <div class=""list-preview odd"">
        <div class=""list-preview-item-narrow"">
<a href=""/list/ls006069112?ref_=tt_rls_2""
><img height=""86"" width=""86"" alt=""list image"" title=""list image""src=""/images/nopicture/medium/film.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTUzMjM0MTc3MF5BMl5BanBnXkFtZTcwNzU0ODMyMw@@._V1_SX86_CR0,0,86,86_AL_.jpg"" /></a>        </div>
        <div class=""list_name"">
            <strong><a href=""/list/ls006069112?ref_=tt_rls_2""
>Quero ver</a></strong>
        </div>
        <div class=""list_meta"">
            a list of 24 titles
            <br />created 26&nbsp;Nov&nbsp;2011
        </div>
        <div class=""clear"">&nbsp;</div>
    </div>
    <div class=""list-preview even"">
        <div class=""list-preview-item-narrow"">
<a href=""/list/ls008149319?ref_=tt_rls_3""
><img height=""86"" width=""86"" alt=""list image"" title=""list image""src=""/images/nopicture/medium/film.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTkzMDgyNjQwM15BMl5BanBnXkFtZTgwNTg2Mjc1MDE@._V1_SX86_CR0,0,86,86_AL_.jpg"" /></a>        </div>
        <div class=""list_name"">
            <strong><a href=""/list/ls008149319?ref_=tt_rls_3""
>My Favourite Movies</a></strong>
        </div>
        <div class=""list_meta"">
            a list of 48 titles
            <br />created 25&nbsp;Aug&nbsp;2012
        </div>
        <div class=""clear"">&nbsp;</div>
    </div>
    <div class=""list-preview odd"">
        <div class=""list-preview-item-narrow"">
<a href=""/list/ls056715981?ref_=tt_rls_4""
><img height=""86"" width=""86"" alt=""list image"" title=""list image""src=""/images/nopicture/medium/film.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMjA5NTYzMDMyM15BMl5BanBnXkFtZTgwNjU3NDU2MTE@._V1_SX86_CR0,0,86,86_AL_.jpg"" /></a>        </div>
        <div class=""list_name"">
            <strong><a href=""/list/ls056715981?ref_=tt_rls_4""
>the best</a></strong>
        </div>
        <div class=""list_meta"">
            a list of 42 titles
            <br />created 01&nbsp;Aug&nbsp;2013
        </div>
        <div class=""clear"">&nbsp;</div>
    </div>
    <div class=""list-preview even"">
        <div class=""list-preview-item-narrow"">
<a href=""/list/ls059483639?ref_=tt_rls_5""
><img height=""86"" width=""86"" alt=""list image"" title=""list image""src=""/images/nopicture/medium/film.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTY0NTQ1NjA0OV5BMl5BanBnXkFtZTgwMDg5NjkzMTE@._V1_SX86_CR0,0,86,86_AL_.jpg"" /></a>        </div>
        <div class=""list_name"">
            <strong><a href=""/list/ls059483639?ref_=tt_rls_5""
>22.02.2014</a></strong>
        </div>
        <div class=""list_meta"">
            a list of 42 titles
            <br />created 5&nbsp;months&nbsp;ago
        </div>
        <div class=""clear"">&nbsp;</div>
    </div>
                <div class=""see-more"">
                    <a href=""/lists/tt0446029?ref_=tt_rls_sm""
>See all related lists</a>&nbsp;&raquo;
                </div>
            </div>
        </div>
    <!-- no content received for slot: btf_rhs1 -->
    <div class=""aux-content-widget-2"">
        <h3>Connect with IMDb</h3>
        <div id=""facebookWrapper"">
            <iframe
                scrolling=""no""
                frameborder=""0""
                id=""facebookIframe""
                allowTransparency=""true""></iframe>
        </div>
        <hr>
        <iframe allowtransparency=""true""
            frameborder=""0""
            role=""presentation""
            scrolling=""no""
            id=""twitterIframe""></iframe>
    </div>
    <div class=""aux-content-widget-2"">
        <div id=""ratingWidget"">
            <h3>Share this Rating</h3>
            <p>
                Title:
                <strong>Scott Pilgrim vs. the World</strong>
                (2010)
            </p>
            <span class=""imdbRatingPlugin imdbRatingStyle1"" data-user="""" data-title=""tt0446029"" data-style=""t1"">
<a href=""/title/tt0446029/?ref_=tt_plg_rt""
> <img alt=""Scott Pilgrim vs. the World (2010) on IMDb""
src=""http://ia.media-imdb.com/images/G/01/imdb/images/plugins/imdb_46x22-2264473254._CB379390954_.png"">
</a>                <span class=""rating"">7.5<span class=""ofTen"">/10</span></span>
<img src=""http://ia.media-imdb.com/images/G/01/imdb/images/plugins/imdb_star_22x21-2889147855._CB379391454_.png"" class=""star"">
            </span>
            <p>Want to share IMDb's rating on your own site? Use the HTML below.</p>
            <div id=""ratingPluginHTML"" class=""hidden"">
                <div class=""message_box small"">
                    <div class=""error"">
                        <p>
                        You must be a registered user to use the IMDb rating plugin.
                        </p>
                        <a href=""/register/login?ref_=tt_plg_rt""
class=""cboxElement"" rel='login'>Login</a>
                    </div>
                </div>
            </div>
            <div id=""ratingWidgetLinks"">
                <span class=""titlePageSprite arrows show""></span>
                <a href=""/plugins?titleId=tt0446029&ref_=tt_plg_rt""
id=""toggleRatingPluginHTML"" itemprop='url' >Show HTML</a>
                <a href=""/plugins?titleId=tt0446029&ref_=tt_plg_rt""
itemprop='url'>View more styles</a>
            </div>
        </div>
    </div>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitlePlayQuizWidget_started');
    }
  </script>
<div class=""aux-content-widget-2 play_quiz_widget"">
    <h3>Take The Quiz!</h3>
<a href=""/games/guess/tt0446029?ref_=tt_qz""
class=""icon"" ></a><span>Test your knowledge of <a href=""/games/guess/tt0446029?ref_=tt_qz""
>Scott Pilgrim vs. the World</a>.</span>
</div>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitlePlayQuizWidget_finished');
    }
  </script>
<div class=""aux-content-widget-2 poll-widget-rhs "">
    <style>
        .aux-content-widget-2.poll-widget-rhs ul li { margin-bottom: 0.5em; clear: left; font-weight: bold;}
        .aux-content-widget-2.poll-widget-rhs span { margin-bottom: 0.5em; clear: left;}
        .aux-content-widget-2.poll-widget-rhs img { float: left; padding: 0 5px 5px 0; height: 86px; width: 86px;}
    </style>
    <h3>User Polls</h3>
    <ul>
        <li>
<a href=""/poll/nOuMQkmyOuI/?ref_=tt_po_i1""
><img height=""86"" width=""86"" alt=""poll image"" title=""poll image""src=""http://i.imdb.com/images/nopicture/140x209/unknown.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTQxMDcyNjU1MF5BMl5BanBnXkFtZTcwMzU4NDAyMw@@._V1_SY86_CR21,0,86,86_.jpg"" /></a>        <a href=""/poll/nOuMQkmyOuI/?ref_=tt_po_q1""
>Best looking Emo/Gothic Girl Character</a>
        <li>
<a href=""/poll/stUPQUks8Gc/?ref_=tt_po_i2""
><img height=""86"" width=""86"" alt=""poll image"" title=""poll image""src=""http://i.imdb.com/images/nopicture/140x209/unknown.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTk3OTAwNDQwOF5BMl5BanBnXkFtZTgwOTE0MzQxMDE@._V1_SX86_CR0,0,86,86_.jpg"" /></a>        <a href=""/poll/stUPQUks8Gc/?ref_=tt_po_q2""
>Best fake movie band?</a>
        <li>
<a href=""/poll/SAJJMdPau7o/?ref_=tt_po_i3""
><img height=""86"" width=""86"" alt=""poll image"" title=""poll image""src=""http://i.imdb.com/images/nopicture/140x209/unknown.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTQ5NzAxODU4NV5BMl5BanBnXkFtZTcwMTcxNDc0NA@@._V1_SY86_CR22,0,86,86_.jpg"" /></a>        <a href=""/poll/SAJJMdPau7o/?ref_=tt_po_q3""
>Better Homework Excuse Than &quot;My Dog Ate It&quot;?</a>
        <li>
<a href=""/poll/sknIQojVA9Y/?ref_=tt_po_i4""
><img height=""86"" width=""86"" alt=""poll image"" title=""poll image""src=""http://i.imdb.com/images/nopicture/140x209/unknown.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BODcxOTA0Mzg4Nl5BMl5BanBnXkFtZTcwODkyOTQ1Mw@@._V1_SX86_CR0,0,86,86_.jpg"" /></a>        <a href=""/poll/sknIQojVA9Y/?ref_=tt_po_q4""
>Colourful Hair</a>
        <li>
<a href=""/poll/oVMD2inhOtI/?ref_=tt_po_i5""
><img height=""86"" width=""86"" alt=""poll image"" title=""poll image""src=""http://i.imdb.com/images/nopicture/140x209/unknown.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTY4NjI0NzExOV5BMl5BanBnXkFtZTcwOTExNTAyNw@@._V1_SY86_CR21,0,86,86_.jpg"" /></a>        <a href=""/poll/oVMD2inhOtI/?ref_=tt_po_q5""
>Favorite Portrayal of a Rock Star?</a>
    </ul>
    <div class=""see-more""><a href=""/poll/?ref_=tt_po_sm""
>See more polls &raquo;</a></div>
</div>
    <!-- no content received for slot: bottom_rhs -->
    <!-- begin BTF_RHS2 -->
<div id=""btf_rhs2_wrapper"" class=""cornerstone_slot"">
<script type=""text/javascript"">
doWithAds(function(){
ad_utils.register_ad('btf_rhs2');
});
</script>
<iframe id=""btf_rhs2"" name=""btf_rhs2"" class=""yesScript"" width=""300"" height=""250"" data-original-width=""300"" data-original-height=""250"" marginwidth=""0"" marginheight=""0"" frameborder=""0"" scrolling=""no"" allowtransparency=""true"" onload=""doWithAds.call(this, function(){ ad_utils.on_ad_load(this); });"" allowfullscreen=""true""></iframe>
</div>
<div id=""btf_rhs2_reflow_helper""></div>
<script>
doWithAds(function(){
ad_utils.inject_serverside_ad('btf_rhs2', ' \r\n\r\n<a target=\""_blank\"" href=\""http://aax-us-east.amazon-adsystem.com/x/c/QbB9PZdWkWvqwecyFgUhcG8AAAFHyAfhCwEAAADKu-p1cQ/http://pda-bes.amazon.com/c?i=1$AgAAAAAAAAAEAAAAAAAAAAMAAAAA2TZhzI4NeyZadgxN6l-hUaMfhqVmAWehSC5dVEUMU.mUhu7UGfIYDZySa4Sugexc11RvH28cGZX09dS9vnpnwlg296sc6A99GfqVkWmNwABauDE7pDqUdZ5YOeqR0PkSpHymA3vi.vZ04fj8-jShMyQ7zaftFphE1s2t6auNwnwtYOSxmOGXrQUy6ipTN2NgCWBNqrWs2jjcjo6YpdkyCheW54ZIFPqChPuA2v5qpXDJCVLZrZ90Dg5b1tmZ7GQS.R3Nq2ZZD4WhMqPRt26-TOsLRGn5yn4T-Vw.ZejilC8zF.2f6D45GNLPr3Oj8DYVD17G3hqApiTYHye3olCCUmHcFQbK-LNoC8PPC8geYueYnp6AJ6L6Sv5-pVJOHN72yh6C.uH.CFy96-XKHOU2TftgTe44pdx28Ii05lJY9MIqpMIYiTHNB5De.PyoNWkD7DLXz7M12N9KC5TA5uWVZSkiWFdDpKNU89e8znHj.LRJ9VMynQfdwlph2b8vqjmHN6RAzBmKCTCoS5PQXA1IFqgUbdpaIVheuoelb2bIlscIbiMKZfvEanl6ZzTMW6VUkIAfi1phc8e4z.5IykqcSeteXSzRhrCM-faa3NWnTe-0JVUQmP-KnDoXhSgwg.7qTPz8MiK2mlflQyeNt5v1dfMb1q2XEz26VndJmIyQr-iWEXIBwVIq7JwHSto7Pwh-WmApP4sMNqYDLJzGfA.5qgnxICAywJfmkGlFZm3Tv20-m.TqZDeggk.rPl61yShxykzJuD2Vvu2dsoKkMdmfy2brHrn5k7H8ass-AEbyqthrJQmUQaT47UbXy4bjGJNpOic765vQDVRQwTWG9DgWSO7vLSuWfCxx4cAhaXd03krq6zjCZAvSkysUhGtRuPdTaapRf9eA5oZd9Iy9ZxpZobzK0kM4.sfINfszhXpa0TBL5DnFTE9V7ccmFQxbJtVsqZkFtUlWQWZo7yC4IGg8wi248n8GjPzcdykfmbdJhvnlTATHWFZ50I-j5A8EpOjILTLuZ1.KhDqxmVmjzKh-AkoH.IFT2WwLgjQT0H184TIbSQ.XbV1v7k9YjS-ilaZ8wLUNmBwW7srKSOgemOhUv9gPDrLtYvkX8mLz-VZ-P0-CcMihFxv3Obb9Jlv.Oeu7gvsA4alDZjNuJaepz9q3EeIeQCXA9Mj5iGODYtnGXFWM-HABKJ6mh072Ym4iHGtqaKlKFAD-VKwOQCCFwFwExpcbu2wGz858FVdBmWWfmHdQPL9RTffirty3vsjEZAYkKbcQO-PjHsj05RPOmrpxxKkL7EKOoHe1Wb46CVWu11M4CC3TosOgA76vrAyKe2lVGDaMie.SgKfhsyOfHrZ8i-tiO7ag-DQNydU3vIYDOyWP2nenGpHPmvU-3.4BV-DdCSTjP0dO0fuKr1ysu57AzOnxKdGnP-ySnSqqsCisHD9.9HLnv-H09bsDnCcGdiX39dPFfQ__\""><img src=\""//d2o307dm5mqftz.cloudfront.net/1505855001/1395677029443/ca_imdb_300.gif\"" alt=\""\"" title=\""\"" width=\""300\"" height=\""250\"" border=\""0\""></a>\r\n\r\n<\!-- creativeModDate = 1407807370000 --\>\n <div id=\""btf_rhs2_webbug\"" style=\""display:none;\"">\n <img src=\""http://aax-us-east.amazon-adsystem.com/e/loi/imp?b=fc7b3273-29ef-4e8f-b184-b50ec68b3333\"" border=\""0\"" height=\""1\"" width=\""1\"" alt=\""\""/>\n </div>\n');
},""unable to inject serverside ad"");
</script>
    </div>
    <div id=""maindetails_center_bottom"" class=""maindetails_center"">
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleEpisodesWidget_started');
    }
  </script>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleEpisodesWidget_finished');
    }
  </script>
          <div class=""article highlighted"" id=""titleAwardsRanks"">
        <span itemprop=""awards""><b></b></span>
        <span itemprop=""awards"">11 wins & 43 nominations.</span>
    <span class=""see-more inline"">
<a href=""/title/tt0446029/awards?ref_=tt_awd""
>See more awards</a>&nbsp;&raquo;    </span>
          </div>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleMediaStripWidget_started');
    }
  </script>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleMediaStripWidget_started');
    }
  </script>
      <div class = ""article"" id=""titleMediaStrip"">
        <div class=""mediastrip_container combined"">
                <div id=""combined-videos"">
                    <h2>Videos</h2>
    <div class=""mediastrip_big"">
                <span class=""video_slate"" itemscope itemtype=""http://schema.org/videoObject"">
                <meta itemprop=""duration"" content=""T1M15S"" />
<a href=""/video/imdb/vi3041068825?ref_=tt_pv_vi_1""
title=""Scott Pilgrim vs. the World -- Scott Pilgrim vs. the World: MTV Movie Awards Clip"" alt=""Scott Pilgrim vs. the World -- Scott Pilgrim vs. the World: MTV Movie Awards Clip"" class=""video-colorbox"" data-video=""vi3041068825"" data-context=""imdb"" data-rid=""15VE9X8Y818EAKHK5QRX"" widget-context=""titleMaindetails"" itemprop=""url"" ><img height=""105"" width=""139"" alt=""Scott Pilgrim vs. the World -- Scott Pilgrim vs. the World: MTV Movie Awards Clip"" title=""Scott Pilgrim vs. the World -- Scott Pilgrim vs. the World: MTV Movie Awards Clip""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/no-video-slate-856072904._CB379390253_.png""class=""loadlate hidden video"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTQ4NjEwODk3MF5BMl5BanBnXkFtZTcwODE3MTU1Mw@@._V1_SP229,229,0,C,0,0,0_CR45,62,139,105_PIimdb-blackband-204-14,TopLeft,0,0_PIimdb-blackband-204-28,BottomLeft,0,1_CR0,0,139,105_PIimdb-bluebutton-big,BottomRight,-1,-1_ZAClip,2,76,16,137,verdenab,8,255,255,255,1_ZAon%2520IMDb,2,1,14,137,verdenab,7,255,255,255,1_ZA01:15,103,1,14,36,verdenab,7,255,255,255,1_.jpg"" itemprop='image' viconst=""vi3041068825"" /></a>            </span>
                <span class=""video_slate_last"" itemscope itemtype=""http://schema.org/videoObject"">
                <meta itemprop=""duration"" content=""T2M26S"" />
<a href=""/video/screenplay/vi1575487001?ref_=tt_pv_vi_2""
title=""Scott Pilgrim vs. the World -- Featurette: A look inside"" alt=""Scott Pilgrim vs. the World -- Featurette: A look inside"" class=""video-colorbox"" data-video=""vi1575487001"" data-context=""screenplay"" data-rid=""15VE9X8Y818EAKHK5QRX"" widget-context=""titleMaindetails"" itemprop=""url"" ><img height=""105"" width=""139"" alt=""Scott Pilgrim vs. the World -- Featurette: A look inside"" title=""Scott Pilgrim vs. the World -- Featurette: A look inside""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/no-video-slate-856072904._CB379390253_.png""class=""loadlate hidden video"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTk5Nzc0OTI4N15BMl5BanBnXkFtZTcwMzA0NzI3Mw@@._V1_SP229,229,0,C,0,0,0_CR45,62,139,105_PIimdb-blackband-204-14,TopLeft,0,0_PIimdb-blackband-204-28,BottomLeft,0,1_CR0,0,139,105_PIimdb-bluebutton-big,BottomRight,-1,-1_ZAFeaturette,2,76,16,137,verdenab,8,255,255,255,1_ZAon%2520IMDb,2,1,14,137,verdenab,7,255,255,255,1_ZA02:26,103,1,14,36,verdenab,7,255,255,255,1_.jpg"" itemprop='image' viconst=""vi1575487001"" /></a>            </span>
    </div>
                </div>
                <div id=""combined-photos"">
                    <h2>Photos</h2>
        <div class=""mediastrip"">
<a href=""/media/rm1522171904/tt0446029?ref_=tt_pv_md_1""
itemprop='thumbnailUrl'><img height=""105"" width=""105"" alt=""Michael Cera at event of Scott Pilgrim vs. the World (2010)"" title=""Michael Cera at event of Scott Pilgrim vs. the World (2010)""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/unknown-1394846836._CB379391227_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BODcyOTg3NjcxOF5BMl5BanBnXkFtZTcwNTI0ODk2Mw@@._V1_SX105_CR0,0,105,105_AL_.jpg"" itemprop='image' /></a>                
<a href=""/media/rm1488617472/tt0446029?ref_=tt_pv_md_2""
itemprop='thumbnailUrl'><img height=""105"" width=""105"" alt=""Michael Cera at event of Scott Pilgrim vs. the World (2010)"" title=""Michael Cera at event of Scott Pilgrim vs. the World (2010)""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/unknown-1394846836._CB379391227_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BNDAwNTMyNzMzMF5BMl5BanBnXkFtZTcwNzI0ODk2Mw@@._V1_SY105_CR26,0,105,105_AL_.jpg"" itemprop='image' /></a>                
<a href=""/media/rm2797240320/tt0446029?ref_=tt_pv_md_3""
itemprop='thumbnailUrl'><img height=""105"" width=""105"" alt=""Michael Cera at event of Scott Pilgrim vs. the World (2010)"" title=""Michael Cera at event of Scott Pilgrim vs. the World (2010)""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/unknown-1394846836._CB379391227_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMjA5Nzc0NTE5OV5BMl5BanBnXkFtZTcwOTI0ODk2Mw@@._V1_SX105_CR0,0,105,105_AL_.jpg"" itemprop='image' /></a>        </div>
                </div>
            <div class=""combined-see-more see-more"">
<a href=""/title/tt0446029/mediaindex?ref_=tt_pv_mi_sm""
><span class=""titlePageSprite showAllVidsAndPics""></span></a>
<a href=""/title/tt0446029/mediaindex?ref_=tt_pv_mi_sm""
>123 photos</a>
<span class=""ghost"">|</span>
<a href=""/title/tt0446029/videogallery?ref_=tt_pv_vi_sm""
>12 videos</a>
<span class=""ghost"">|</span>
<a href=""/title/tt0446029/news?ref_=tt_pv_nw_sm""
>3933 news articles</a> &raquo;            </div>
        </div>
      </div>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleMediaStripWidget_finished');
    }
  </script>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleMediaStripWidget_finished');
    }
  </script>

  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleRecsWidget_started');
    }
  </script>
        <div class=""article"" id=""titleRecs"">
            <span class=""rightcornerlink"">
            <a href=""/help/show_leaf?personalrecommendations&ref_=tt_rec_lm""
>Learn more</a>
            </span>
            <h2 class=""rec_heading_wrapper"">
                <span class=""rec_heading"" data-spec=""p13nsims:tt0446029"">People who liked this also liked...&nbsp;</span>
            </h2>

            <div class=""rec_wrapper"" id=""title_recs""
                data-items-per-request=""24""
                data-items-per-page=""6""
                data-specs=""p13nsims:tt0446029""
                data-caller-name=""p13nsims-title"">
    <div class=""rec_const_picker"">
        <div class=""rec_view"">
            <div class=""rec_grave"" style=""display:none""></div>
            <div class=""rec_slide"">
                        <div class=""rec_page"">
    <div class=""rec_item"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0090728"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0090728/?ref_=tt_rec_tti""
><img height=""113"" width=""76"" alt=""Big Trouble in Little China"" title=""Big Trouble in Little China""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/film-293970583._CB379390468_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTk5MjI4MzIxMl5BMl5BanBnXkFtZTYwODU1MDQ5._V1_SY113_CR3,0,76,113_AL_.jpg"" /> <br/>
</a>    </div>
    <div class=""rec_item"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0865556"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0865556/?ref_=tt_rec_tti""
><img height=""113"" width=""76"" alt=""The Forbidden Kingdom"" title=""The Forbidden Kingdom""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/film-293970583._CB379390468_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTUwNTExMTg3NF5BMl5BanBnXkFtZTcwNDYyMTM2MQ@@._V1_SX76_CR0,0,76,113_AL_.jpg"" /> <br/>
</a>    </div>
    <div class=""rec_item"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0473075"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0473075/?ref_=tt_rec_tti""
><img height=""113"" width=""76"" alt=""Prince of Persia: The Sands of Time"" title=""Prince of Persia: The Sands of Time""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/film-293970583._CB379390468_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTMwNDg0NzcyMV5BMl5BanBnXkFtZTcwNjg4MjQyMw@@._V1_SY113_CR0,0,76,113_AL_.jpg"" /> <br/>
</a>    </div>
    <div class=""rec_item"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0107362"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0107362/?ref_=tt_rec_tti""
><img height=""113"" width=""76"" alt=""Last Action Hero"" title=""Last Action Hero""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/film-293970583._CB379390468_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BNDg4OTg5MTc0NV5BMl5BanBnXkFtZTcwOTUxMzgxMQ@@._V1_SY113_CR2,0,76,113_AL_.jpg"" /> <br/>
</a>    </div>

    <div class=""rec_item"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0088011"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0088011/?ref_=tt_rec_tti""
><img height=""113"" width=""76"" alt=""Romancing the Stone"" title=""Romancing the Stone""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/film-293970583._CB379390468_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMjEyMTYyNjcwMV5BMl5BanBnXkFtZTcwOTEyNjQzMQ@@._V1_SY113_CR4,0,76,113_AL_.jpg"" /> <br/>
</a>    </div>
    <div class=""rec_item"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0347149"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0347149/?ref_=tt_rec_tti""
><img height=""113"" width=""76"" alt=""Hauru no ugoku shiro"" title=""Hauru no ugoku shiro""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/film-293970583._CB379390468_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTY1OTg0MjE3MV5BMl5BanBnXkFtZTcwNTUxMTkyMQ@@._V1_SY113_CR0,0,76,113_AL_.jpg"" /> <br/>
</a>    </div>
                        </div>
                        <div class=""rec_page"">
    <div class=""rec_item"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0093779"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0093779/?ref_=tt_rec_tti""
><img height=""113"" width=""76"" alt=""The Princess Bride"" title=""The Princess Bride""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/film-293970583._CB379390468_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTkzMDgyNjQwM15BMl5BanBnXkFtZTgwNTg2Mjc1MDE@._V1_SY113_CR0,0,76,113_AL_.jpg"" /> <br/>
</a>    </div>
    <div class=""rec_item"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0438097"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0438097/?ref_=tt_rec_tti""
><img height=""113"" width=""76"" alt=""Ice Age: The Meltdown"" title=""Ice Age: The Meltdown""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/film-293970583._CB379390468_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMjAwODg3OTAxMl5BMl5BanBnXkFtZTcwMjg2NjYyMw@@._V1_SY113_CR0,0,76,113_AL_.jpg"" /> <br/>
</a>    </div>
    <div class=""rec_item"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0190332"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0190332/?ref_=tt_rec_tti""
><img height=""113"" width=""76"" alt=""Wo hu cang long"" title=""Wo hu cang long""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/film-293970583._CB379390468_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTY5MjM4NjIxOF5BMl5BanBnXkFtZTcwNDg5NzU2OQ@@._V1_SX76_CR0,0,76,113_AL_.jpg"" /> <br/>
</a>    </div>
    <div class=""rec_item"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0110475"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0110475/?ref_=tt_rec_tti""
><img height=""113"" width=""76"" alt=""The Mask"" title=""The Mask""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/film-293970583._CB379390468_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMjM3NDI5OTA5Nl5BMl5BanBnXkFtZTgwNzE4ODYxMTE@._V1_SX76_CR0,0,76,113_AL_.jpg"" /> <br/>
</a>    </div>
    <div class=""rec_item"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0385004"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0385004/?ref_=tt_rec_tti""
><img height=""113"" width=""76"" alt=""Shi mian mai fu"" title=""Shi mian mai fu""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/film-293970583._CB379390468_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMzg4MDE0NzIwNl5BMl5BanBnXkFtZTcwMDI2NDcyMQ@@._V1_SY113_CR0,0,76,113_AL_.jpg"" /> <br/>
</a>    </div>
    <div class=""rec_item"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0477347"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0477347/?ref_=tt_rec_tti""
><img height=""113"" width=""76"" alt=""Night at the Museum"" title=""Night at the Museum""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/small/film-293970583._CB379390468_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTQyOTM4MDMxN15BMl5BanBnXkFtZTcwODg5NTQzMw@@._V1_SY113_CR0,0,76,113_AL_.jpg"" /> <br/>
</a>    </div>
                        </div>
            </div>
            <div class=""rec_nav"">
                <div class=""rec_nav_page_num""></div>
                <a class=""rec_nav_left"">&#9668; Prev 6</a>
                <a class=""rec_nav_right"">Next 6 &#9658;</a>
            </div>
        </div>
    </div>
   <div class=""rec_overviews"">
      <div class=""rec_overview"" data-tconst=""tt0090728"">
    <div class=""rec_poster"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0090728"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0090728/?ref_=tt_rec_tti""
><img height=""190"" width=""128"" alt=""Big Trouble in Little China"" title=""Big Trouble in Little China""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/large/film-184890147._CB379391879_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTk5MjI4MzIxMl5BMl5BanBnXkFtZTYwODU1MDQ5._V1_SY190_CR5,0,128,190_AL_.jpg"" /> <br/>
</a>    </div>
       <div class=""rec_actions"">
         <div class=""rec_action_divider"">
           <div class=""wlb_classic_wrapper"">
             <span class=""wlb_wrapper"">
               <a class=""rec_wlb_watchlist_btn"" data-tconst=""tt0090728"" data-size=""medium"" data-caller-name=""p13nsims-title"" data-type=""primary""></a>
             </span>
           </div>
         </div>
         <div class=""rec_action_divider"">
           <span class=""btn2_wrapper"">
             <a class=""rec_next rec_half_button btn2 medium btn2_text_on"" title=""Show me the next title"" onclick="""">
               <span class=""btn2_glyph"">0</span>
               <span class=""btn2_text"">Next &raquo;</span>
             </a>
           </span>
         </div>
             <input type=""hidden"" name=""49e6c"" value=""4998"">
       </div>
       <div class=""rec_details"">
         <div class=""rec-info"">
           <div class=""rec-jaw-upper"">
     <div class=""rec-title"">
       <a href=""/title/tt0090728/?ref_=tt_rec_tt""
><b>Big Trouble in Little China</b></a>
            <span class=""nobr"">(1986)</span>
   </div>
    <div class=""rec-cert-genre rec-elipsis"">
                    Certificate: 14A
                     Action
 <span class=""ghost"">|</span>
                     Adventure
 <span class=""ghost"">|</span>
                     Comedy
    </div>
             <div class=""rec-rating"">
<div class=""rating rating-list"" data-starbar-class=""rating-list"" data-auth="""" data-user="""" id=""tt0090728|imdb|7.3|7.3|p13nsims-title|tt0446029|title|main"" data-ga-identifier=""""
title=""Users rated this 7.3/10 (73,910 votes) - click stars to rate"" >
<span class=""rating-bg"">&nbsp;</span>
<span class=""rating-imdb "" style=""width: 102.2px"">&nbsp;</span>
<span class=""rating-stars"">
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>1</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>2</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>3</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>4</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>5</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>6</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>7</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>8</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>9</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>10</span></a>
</span>
<span class=""rating-rating ""><span class=""value"">7.3</span><span class=""grey"">/</span><span class=""grey"">10</span></span>
<span class=""rating-cancel ""><a href=""/title/tt0090728/vote?v=X;k="" title=""Delete"" rel=""nofollow""><span>X</span></a></span>
&nbsp;</div>
               <div class=""rec-outline"">
    <p>
An All-American trucker gets dragged into a centuries-old mystical battle in Chinatown.    </p>
               </div>
             </div>
           </div>
           <div class=""rec-jaw-lower"">
             <div class=""rec-jaw-teeth""></div>
 <div class=""rec-director rec-ellipsis"">
      <b>Director:</b>
John Carpenter  </div>
<div class=""rec-actor rec-ellipsis""> <span>
    <b>Stars:</b>
Kurt Russell,
Kim Cattrall,
Dennis Dun</span></div>
           </div>
         </div>
       </div>
      </div>
      <div class=""rec_overview"" data-tconst=""tt0865556"">
    <div class=""rec_poster"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0865556"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0865556/?ref_=tt_rec_tti""
><img height=""190"" width=""128"" alt=""The Forbidden Kingdom"" title=""The Forbidden Kingdom""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/large/film-184890147._CB379391879_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTUwNTExMTg3NF5BMl5BanBnXkFtZTcwNDYyMTM2MQ@@._V1_SX128_CR0,0,128,190_AL_.jpg"" /> <br/>
</a>    </div>
       <div class=""rec_actions"">
         <div class=""rec_action_divider"">
           <div class=""wlb_classic_wrapper"">
             <span class=""wlb_wrapper"">
               <a class=""rec_wlb_watchlist_btn"" data-tconst=""tt0865556"" data-size=""medium"" data-caller-name=""p13nsims-title"" data-type=""primary""></a>
             </span>
           </div>
         </div>
         <div class=""rec_action_divider"">
           <span class=""btn2_wrapper"">
             <a class=""rec_next rec_half_button btn2 medium btn2_text_on"" title=""Show me the next title"" onclick="""">
               <span class=""btn2_glyph"">0</span>
               <span class=""btn2_text"">Next &raquo;</span>
             </a>
           </span>
         </div>
             <input type=""hidden"" name=""49e6c"" value=""4998"">
       </div>
       <div class=""rec_details"">
         <div class=""rec-info"">
           <div class=""rec-jaw-upper"">
     <div class=""rec-title"">
       <a href=""/title/tt0865556/?ref_=tt_rec_tt""
><b>The Forbidden Kingdom</b></a>
            <span class=""nobr"">(2008)</span>
   </div>
    <div class=""rec-cert-genre rec-elipsis"">
                    Certificate: PG
                     Action
 <span class=""ghost"">|</span>
                     Adventure
 <span class=""ghost"">|</span>
                     Fantasy
    </div>
             <div class=""rec-rating"">
<div class=""rating rating-list"" data-starbar-class=""rating-list"" data-auth="""" data-user="""" id=""tt0865556|imdb|6.6|6.6|p13nsims-title|tt0446029|title|main"" data-ga-identifier=""""
title=""Users rated this 6.6/10 (77,348 votes) - click stars to rate"" >
<span class=""rating-bg"">&nbsp;</span>
<span class=""rating-imdb "" style=""width: 92.4px"">&nbsp;</span>
<span class=""rating-stars"">
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>1</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>2</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>3</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>4</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>5</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>6</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>7</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>8</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>9</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>10</span></a>
</span>
<span class=""rating-rating ""><span class=""value"">6.6</span><span class=""grey"">/</span><span class=""grey"">10</span></span>
<span class=""rating-cancel ""><a href=""/title/tt0865556/vote?v=X;k="" title=""Delete"" rel=""nofollow""><span>X</span></a></span>
&nbsp;</div>
               <div class=""rec-outline"">
    <p>
A discovery made by a kung fu obsessed American teen sends him on an adventure to China, where he joins up with a band of martial arts warriors in order to free the imprisoned Monkey King.    </p>
               </div>
             </div>
           </div>
           <div class=""rec-jaw-lower"">
             <div class=""rec-jaw-teeth""></div>
 <div class=""rec-director rec-ellipsis"">
      <b>Director:</b>
Rob Minkoff  </div>
<div class=""rec-actor rec-ellipsis""> <span>
    <b>Stars:</b>
Jackie Chan,
Jet Li,
Michael Angarano</span></div>
           </div>
         </div>
       </div>
      </div>
      <div class=""rec_overview"" data-tconst=""tt0473075"">
    <div class=""rec_poster"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0473075"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0473075/?ref_=tt_rec_tti""
><img height=""190"" width=""128"" alt=""Prince of Persia: The Sands of Time"" title=""Prince of Persia: The Sands of Time""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/large/film-184890147._CB379391879_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTMwNDg0NzcyMV5BMl5BanBnXkFtZTcwNjg4MjQyMw@@._V1_SY190_CR0,0,128,190_AL_.jpg"" /> <br/>
</a>    </div>
       <div class=""rec_actions"">
         <div class=""rec_action_divider"">
           <div class=""wlb_classic_wrapper"">
             <span class=""wlb_wrapper"">
               <a class=""rec_wlb_watchlist_btn"" data-tconst=""tt0473075"" data-size=""medium"" data-caller-name=""p13nsims-title"" data-type=""primary""></a>
             </span>
           </div>
         </div>
         <div class=""rec_action_divider"">
           <span class=""btn2_wrapper"">
             <a class=""rec_next rec_half_button btn2 medium btn2_text_on"" title=""Show me the next title"" onclick="""">
               <span class=""btn2_glyph"">0</span>
               <span class=""btn2_text"">Next &raquo;</span>
             </a>
           </span>
         </div>
             <input type=""hidden"" name=""49e6c"" value=""4998"">
       </div>
       <div class=""rec_details"">
         <div class=""rec-info"">
           <div class=""rec-jaw-upper"">
     <div class=""rec-title"">
       <a href=""/title/tt0473075/?ref_=tt_rec_tt""
><b>Prince of Persia: The Sands of Time</b></a>
            <span class=""nobr"">(2010)</span>
   </div>
    <div class=""rec-cert-genre rec-elipsis"">
                    Certificate: PG
                     Action
 <span class=""ghost"">|</span>
                     Adventure
 <span class=""ghost"">|</span>
                     Fantasy
    </div>
             <div class=""rec-rating"">
<div class=""rating rating-list"" data-starbar-class=""rating-list"" data-auth="""" data-user="""" id=""tt0473075|imdb|6.6|6.6|p13nsims-title|tt0446029|title|main"" data-ga-identifier=""""
title=""Users rated this 6.6/10 (176,011 votes) - click stars to rate"" >
<span class=""rating-bg"">&nbsp;</span>
<span class=""rating-imdb "" style=""width: 92.4px"">&nbsp;</span>
<span class=""rating-stars"">
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>1</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>2</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>3</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>4</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>5</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>6</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>7</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>8</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>9</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>10</span></a>
</span>
<span class=""rating-rating ""><span class=""value"">6.6</span><span class=""grey"">/</span><span class=""grey"">10</span></span>
<span class=""rating-cancel ""><a href=""/title/tt0473075/vote?v=X;k="" title=""Delete"" rel=""nofollow""><span>X</span></a></span>
&nbsp;</div>
               <div class=""rec-outline"">
    <p>
A young fugitive prince and princess must stop a villain who unknowingly threatens to destroy the world with a special dagger that enables the magic sand inside to reverse time.    </p>
               </div>
             </div>
           </div>
           <div class=""rec-jaw-lower"">
             <div class=""rec-jaw-teeth""></div>
 <div class=""rec-director rec-ellipsis"">
      <b>Director:</b>
Mike Newell  </div>
<div class=""rec-actor rec-ellipsis""> <span>
    <b>Stars:</b>
Jake Gyllenhaal,
Gemma Arterton,
Ben Kingsley</span></div>
           </div>
         </div>
       </div>
      </div>
      <div class=""rec_overview"" data-tconst=""tt0107362"">
    <div class=""rec_poster"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0107362"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0107362/?ref_=tt_rec_tti""
><img height=""190"" width=""128"" alt=""Last Action Hero"" title=""Last Action Hero""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/large/film-184890147._CB379391879_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BNDg4OTg5MTc0NV5BMl5BanBnXkFtZTcwOTUxMzgxMQ@@._V1_SY190_CR3,0,128,190_AL_.jpg"" /> <br/>
</a>    </div>
       <div class=""rec_actions"">
         <div class=""rec_action_divider"">
           <div class=""wlb_classic_wrapper"">
             <span class=""wlb_wrapper"">
               <a class=""rec_wlb_watchlist_btn"" data-tconst=""tt0107362"" data-size=""medium"" data-caller-name=""p13nsims-title"" data-type=""primary""></a>
             </span>
           </div>
         </div>
         <div class=""rec_action_divider"">
           <span class=""btn2_wrapper"">
             <a class=""rec_next rec_half_button btn2 medium btn2_text_on"" title=""Show me the next title"" onclick="""">
               <span class=""btn2_glyph"">0</span>
               <span class=""btn2_text"">Next &raquo;</span>
             </a>
           </span>
         </div>
             <input type=""hidden"" name=""49e6c"" value=""4998"">
       </div>
       <div class=""rec_details"">
         <div class=""rec-info"">
           <div class=""rec-jaw-upper"">
     <div class=""rec-title"">
       <a href=""/title/tt0107362/?ref_=tt_rec_tt""
><b>Last Action Hero</b></a>
            <span class=""nobr"">(1993)</span>
   </div>
    <div class=""rec-cert-genre rec-elipsis"">
                    Certificate: 14A
                     Action
 <span class=""ghost"">|</span>
                     Adventure
 <span class=""ghost"">|</span>
                     Comedy
    </div>
             <div class=""rec-rating"">
<div class=""rating rating-list"" data-starbar-class=""rating-list"" data-auth="""" data-user="""" id=""tt0107362|imdb|6.1|6.1|p13nsims-title|tt0446029|title|main"" data-ga-identifier=""""
title=""Users rated this 6.1/10 (89,215 votes) - click stars to rate"" >
<span class=""rating-bg"">&nbsp;</span>
<span class=""rating-imdb "" style=""width: 85.4px"">&nbsp;</span>
<span class=""rating-stars"">
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>1</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>2</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>3</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>4</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>5</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>6</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>7</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>8</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>9</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>10</span></a>
</span>
<span class=""rating-rating ""><span class=""value"">6.1</span><span class=""grey"">/</span><span class=""grey"">10</span></span>
<span class=""rating-cancel ""><a href=""/title/tt0107362/vote?v=X;k="" title=""Delete"" rel=""nofollow""><span>X</span></a></span>
&nbsp;</div>
               <div class=""rec-outline"">
    <p>
With the help of a magic ticket, a young film fan is transported into the fictional world of his favorite action film character.    </p>
               </div>
             </div>
           </div>
           <div class=""rec-jaw-lower"">
             <div class=""rec-jaw-teeth""></div>
 <div class=""rec-director rec-ellipsis"">
      <b>Director:</b>
John McTiernan  </div>
<div class=""rec-actor rec-ellipsis""> <span>
    <b>Stars:</b>
Arnold Schwarzenegger,
F. Murray Abraham,
Art Carney</span></div>
           </div>
         </div>
       </div>
      </div>
      <div class=""rec_overview"" data-tconst=""tt0088011"">
    <div class=""rec_poster"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0088011"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0088011/?ref_=tt_rec_tti""
><img height=""190"" width=""128"" alt=""Romancing the Stone"" title=""Romancing the Stone""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/large/film-184890147._CB379391879_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMjEyMTYyNjcwMV5BMl5BanBnXkFtZTcwOTEyNjQzMQ@@._V1_SY190_CR6,0,128,190_AL_.jpg"" /> <br/>
</a>    </div>
       <div class=""rec_actions"">
         <div class=""rec_action_divider"">
           <div class=""wlb_classic_wrapper"">
             <span class=""wlb_wrapper"">
               <a class=""rec_wlb_watchlist_btn"" data-tconst=""tt0088011"" data-size=""medium"" data-caller-name=""p13nsims-title"" data-type=""primary""></a>
             </span>
           </div>
         </div>
         <div class=""rec_action_divider"">
           <span class=""btn2_wrapper"">
             <a class=""rec_next rec_half_button btn2 medium btn2_text_on"" title=""Show me the next title"" onclick="""">
               <span class=""btn2_glyph"">0</span>
               <span class=""btn2_text"">Next &raquo;</span>
             </a>
           </span>
         </div>
             <input type=""hidden"" name=""49e6c"" value=""4998"">
       </div>
       <div class=""rec_details"">
         <div class=""rec-info"">
           <div class=""rec-jaw-upper"">
     <div class=""rec-title"">
       <a href=""/title/tt0088011/?ref_=tt_rec_tt""
><b>Romancing the Stone</b></a>
            <span class=""nobr"">(1984)</span>
   </div>
    <div class=""rec-cert-genre rec-elipsis"">
                    Certificate: PA
                     Action
 <span class=""ghost"">|</span>
                     Adventure
 <span class=""ghost"">|</span>
                     Comedy
    </div>
             <div class=""rec-rating"">
<div class=""rating rating-list"" data-starbar-class=""rating-list"" data-auth="""" data-user="""" id=""tt0088011|imdb|6.9|6.9|p13nsims-title|tt0446029|title|main"" data-ga-identifier=""""
title=""Users rated this 6.9/10 (53,570 votes) - click stars to rate"" >
<span class=""rating-bg"">&nbsp;</span>
<span class=""rating-imdb "" style=""width: 96.6px"">&nbsp;</span>
<span class=""rating-stars"">
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>1</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>2</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>3</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>4</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>5</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>6</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>7</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>8</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>9</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>10</span></a>
</span>
<span class=""rating-rating ""><span class=""value"">6.9</span><span class=""grey"">/</span><span class=""grey"">10</span></span>
<span class=""rating-cancel ""><a href=""/title/tt0088011/vote?v=X;k="" title=""Delete"" rel=""nofollow""><span>X</span></a></span>
&nbsp;</div>
               <div class=""rec-outline"">
    <p>
A romance writer sets off to Colombia to ransom her kidnapped sister, and soon finds herself in the middle of a dangerous adventure.    </p>
               </div>
             </div>
           </div>
           <div class=""rec-jaw-lower"">
             <div class=""rec-jaw-teeth""></div>
 <div class=""rec-director rec-ellipsis"">
      <b>Director:</b>
Robert Zemeckis  </div>
<div class=""rec-actor rec-ellipsis""> <span>
    <b>Stars:</b>
Michael Douglas,
Kathleen Turner,
Danny DeVito</span></div>
           </div>
         </div>
       </div>
      </div>
      <div class=""rec_overview"" data-tconst=""tt0347149"">
    <div class=""rec_poster"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0347149"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0347149/?ref_=tt_rec_tti""
><img height=""190"" width=""128"" alt=""Hauru no ugoku shiro"" title=""Hauru no ugoku shiro""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/large/film-184890147._CB379391879_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTY1OTg0MjE3MV5BMl5BanBnXkFtZTcwNTUxMTkyMQ@@._V1_SY190_CR0,0,128,190_AL_.jpg"" /> <br/>
</a>    </div>
       <div class=""rec_actions"">
         <div class=""rec_action_divider"">
           <div class=""wlb_classic_wrapper"">
             <span class=""wlb_wrapper"">
               <a class=""rec_wlb_watchlist_btn"" data-tconst=""tt0347149"" data-size=""medium"" data-caller-name=""p13nsims-title"" data-type=""primary""></a>
             </span>
           </div>
         </div>
         <div class=""rec_action_divider"">
           <span class=""btn2_wrapper"">
             <a class=""rec_next rec_half_button btn2 medium btn2_text_on"" title=""Show me the next title"" onclick="""">
               <span class=""btn2_glyph"">0</span>
               <span class=""btn2_text"">Next &raquo;</span>
             </a>
           </span>
         </div>
             <input type=""hidden"" name=""49e6c"" value=""4998"">
       </div>
       <div class=""rec_details"">
         <div class=""rec-info"">
           <div class=""rec-jaw-upper"">
     <div class=""rec-title"">
       <a href=""/title/tt0347149/?ref_=tt_rec_tt""
><b>Hauru no ugoku shiro</b></a>
            <span class=""nobr"">(2004)</span>
   </div>
    <div class=""rec-cert-genre rec-elipsis"">
                    Certificate: PG
                     Animation
 <span class=""ghost"">|</span>
                     Adventure
 <span class=""ghost"">|</span>
                     Family
    </div>
             <div class=""rec-rating"">
<div class=""rating rating-list"" data-starbar-class=""rating-list"" data-auth="""" data-user="""" id=""tt0347149|imdb|8.2|8.2|p13nsims-title|tt0446029|title|main"" data-ga-identifier=""""
title=""Users rated this 8.2/10 (146,919 votes) - click stars to rate"" >
<span class=""rating-bg"">&nbsp;</span>
<span class=""rating-imdb "" style=""width: 114.8px"">&nbsp;</span>
<span class=""rating-stars"">
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>1</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>2</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>3</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>4</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>5</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>6</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>7</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>8</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>9</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>10</span></a>
</span>
<span class=""rating-rating ""><span class=""value"">8.2</span><span class=""grey"">/</span><span class=""grey"">10</span></span>
<span class=""rating-cancel ""><a href=""/title/tt0347149/vote?v=X;k="" title=""Delete"" rel=""nofollow""><span>X</span></a></span>
&nbsp;</div>
               <div class=""rec-outline"">
    <p>
When an unconfident young woman is cursed with an old body by a spiteful witch, her only chance of breaking the spell lies with a self-indulgent yet insecure young wizard and his companions in his legged, walking home.    </p>
               </div>
             </div>
           </div>
           <div class=""rec-jaw-lower"">
             <div class=""rec-jaw-teeth""></div>
 <div class=""rec-director rec-ellipsis"">
      <b>Director:</b>
Hayao Miyazaki  </div>
<div class=""rec-actor rec-ellipsis""> <span>
    <b>Stars:</b>
Chieko Baishô,
Takuya Kimura,
Tatsuya Gashûin</span></div>
           </div>
         </div>
       </div>
      </div>
      <div class=""rec_overview"" data-tconst=""tt0093779"">
    <div class=""rec_poster"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0093779"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0093779/?ref_=tt_rec_tti""
><img height=""190"" width=""128"" alt=""The Princess Bride"" title=""The Princess Bride""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/large/film-184890147._CB379391879_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTkzMDgyNjQwM15BMl5BanBnXkFtZTgwNTg2Mjc1MDE@._V1_SY190_CR0,0,128,190_AL_.jpg"" /> <br/>
</a>    </div>
       <div class=""rec_actions"">
         <div class=""rec_action_divider"">
           <div class=""wlb_classic_wrapper"">
             <span class=""wlb_wrapper"">
               <a class=""rec_wlb_watchlist_btn"" data-tconst=""tt0093779"" data-size=""medium"" data-caller-name=""p13nsims-title"" data-type=""primary""></a>
             </span>
           </div>
         </div>
         <div class=""rec_action_divider"">
           <span class=""btn2_wrapper"">
             <a class=""rec_next rec_half_button btn2 medium btn2_text_on"" title=""Show me the next title"" onclick="""">
               <span class=""btn2_glyph"">0</span>
               <span class=""btn2_text"">Next &raquo;</span>
             </a>
           </span>
         </div>
             <input type=""hidden"" name=""49e6c"" value=""4998"">
       </div>
       <div class=""rec_details"">
         <div class=""rec-info"">
           <div class=""rec-jaw-upper"">
     <div class=""rec-title"">
       <a href=""/title/tt0093779/?ref_=tt_rec_tt""
><b>The Princess Bride</b></a>
            <span class=""nobr"">(1987)</span>
   </div>
    <div class=""rec-cert-genre rec-elipsis"">
                    Certificate: PG
                     Adventure
 <span class=""ghost"">|</span>
                     Comedy
 <span class=""ghost"">|</span>
                     Family
    </div>
             <div class=""rec-rating"">
<div class=""rating rating-list"" data-starbar-class=""rating-list"" data-auth="""" data-user="""" id=""tt0093779|imdb|8.2|8.2|p13nsims-title|tt0446029|title|main"" data-ga-identifier=""""
title=""Users rated this 8.2/10 (233,701 votes) - click stars to rate"" >
<span class=""rating-bg"">&nbsp;</span>
<span class=""rating-imdb "" style=""width: 114.8px"">&nbsp;</span>
<span class=""rating-stars"">
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>1</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>2</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>3</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>4</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>5</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>6</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>7</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>8</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>9</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>10</span></a>
</span>
<span class=""rating-rating ""><span class=""value"">8.2</span><span class=""grey"">/</span><span class=""grey"">10</span></span>
<span class=""rating-cancel ""><a href=""/title/tt0093779/vote?v=X;k="" title=""Delete"" rel=""nofollow""><span>X</span></a></span>
&nbsp;</div>
               <div class=""rec-outline"">
    <p>
A classic fairy tale, with swordplay, giants, an evil prince, a beautiful princess, and yes, some kissing (as read by a kindly grandfather).    </p>
               </div>
             </div>
           </div>
           <div class=""rec-jaw-lower"">
             <div class=""rec-jaw-teeth""></div>
 <div class=""rec-director rec-ellipsis"">
      <b>Director:</b>
Rob Reiner  </div>
<div class=""rec-actor rec-ellipsis""> <span>
    <b>Stars:</b>
Cary Elwes,
Mandy Patinkin,
Robin Wright</span></div>
           </div>
         </div>
       </div>
      </div>
      <div class=""rec_overview"" data-tconst=""tt0438097"">
    <div class=""rec_poster"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0438097"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0438097/?ref_=tt_rec_tti""
><img height=""190"" width=""128"" alt=""Ice Age: The Meltdown"" title=""Ice Age: The Meltdown""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/large/film-184890147._CB379391879_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMjAwODg3OTAxMl5BMl5BanBnXkFtZTcwMjg2NjYyMw@@._V1_SY190_CR0,0,128,190_AL_.jpg"" /> <br/>
</a>    </div>
       <div class=""rec_actions"">
         <div class=""rec_action_divider"">
           <div class=""wlb_classic_wrapper"">
             <span class=""wlb_wrapper"">
               <a class=""rec_wlb_watchlist_btn"" data-tconst=""tt0438097"" data-size=""medium"" data-caller-name=""p13nsims-title"" data-type=""primary""></a>
             </span>
           </div>
         </div>
         <div class=""rec_action_divider"">
           <span class=""btn2_wrapper"">
             <a class=""rec_next rec_half_button btn2 medium btn2_text_on"" title=""Show me the next title"" onclick="""">
               <span class=""btn2_glyph"">0</span>
               <span class=""btn2_text"">Next &raquo;</span>
             </a>
           </span>
         </div>
             <input type=""hidden"" name=""49e6c"" value=""4998"">
       </div>
       <div class=""rec_details"">
         <div class=""rec-info"">
           <div class=""rec-jaw-upper"">
     <div class=""rec-title"">
       <a href=""/title/tt0438097/?ref_=tt_rec_tt""
><b>Ice Age: The Meltdown</b></a>
            <span class=""nobr"">(2006)</span>
   </div>
    <div class=""rec-cert-genre rec-elipsis"">
                    Certificate: G
                     Animation
 <span class=""ghost"">|</span>
                     Action
 <span class=""ghost"">|</span>
                     Adventure
    </div>
             <div class=""rec-rating"">
<div class=""rating rating-list"" data-starbar-class=""rating-list"" data-auth="""" data-user="""" id=""tt0438097|imdb|6.9|6.9|p13nsims-title|tt0446029|title|main"" data-ga-identifier=""""
title=""Users rated this 6.9/10 (136,988 votes) - click stars to rate"" >
<span class=""rating-bg"">&nbsp;</span>
<span class=""rating-imdb "" style=""width: 96.6px"">&nbsp;</span>
<span class=""rating-stars"">
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>1</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>2</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>3</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>4</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>5</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>6</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>7</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>8</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>9</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>10</span></a>
</span>
<span class=""rating-rating ""><span class=""value"">6.9</span><span class=""grey"">/</span><span class=""grey"">10</span></span>
<span class=""rating-cancel ""><a href=""/title/tt0438097/vote?v=X;k="" title=""Delete"" rel=""nofollow""><span>X</span></a></span>
&nbsp;</div>
               <div class=""rec-outline"">
    <p>
Manny, Sid, and Diego discover that the Ice Age is coming to an end, and join everybody for a journey to higher ground. On the trip, they discover that Manny, in fact, is not the last of the wooly mammoths.    </p>
               </div>
             </div>
           </div>
           <div class=""rec-jaw-lower"">
             <div class=""rec-jaw-teeth""></div>
 <div class=""rec-director rec-ellipsis"">
      <b>Director:</b>
Carlos Saldanha  </div>
<div class=""rec-actor rec-ellipsis""> <span>
    <b>Stars:</b>
Ray Romano,
John Leguizamo,
Denis Leary</span></div>
           </div>
         </div>
       </div>
      </div>
      <div class=""rec_overview"" data-tconst=""tt0190332"">
    <div class=""rec_poster"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0190332"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0190332/?ref_=tt_rec_tti""
><img height=""190"" width=""128"" alt=""Wo hu cang long"" title=""Wo hu cang long""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/large/film-184890147._CB379391879_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTY5MjM4NjIxOF5BMl5BanBnXkFtZTcwNDg5NzU2OQ@@._V1_SX128_CR0,0,128,190_AL_.jpg"" /> <br/>
</a>    </div>
       <div class=""rec_actions"">
         <div class=""rec_action_divider"">
           <div class=""wlb_classic_wrapper"">
             <span class=""wlb_wrapper"">
               <a class=""rec_wlb_watchlist_btn"" data-tconst=""tt0190332"" data-size=""medium"" data-caller-name=""p13nsims-title"" data-type=""primary""></a>
             </span>
           </div>
         </div>
         <div class=""rec_action_divider"">
           <span class=""btn2_wrapper"">
             <a class=""rec_next rec_half_button btn2 medium btn2_text_on"" title=""Show me the next title"" onclick="""">
               <span class=""btn2_glyph"">0</span>
               <span class=""btn2_text"">Next &raquo;</span>
             </a>
           </span>
         </div>
             <input type=""hidden"" name=""49e6c"" value=""4998"">
       </div>
       <div class=""rec_details"">
         <div class=""rec-info"">
           <div class=""rec-jaw-upper"">
     <div class=""rec-title"">
       <a href=""/title/tt0190332/?ref_=tt_rec_tt""
><b>Wo hu cang long</b></a>
            <span class=""nobr"">(2000)</span>
   </div>
    <div class=""rec-cert-genre rec-elipsis"">
                    Certificate: PG
                     Action
 <span class=""ghost"">|</span>
                     Drama
 <span class=""ghost"">|</span>
                     Romance
    </div>
             <div class=""rec-rating"">
<div class=""rating rating-list"" data-starbar-class=""rating-list"" data-auth="""" data-user="""" id=""tt0190332|imdb|7.9|7.9|p13nsims-title|tt0446029|title|main"" data-ga-identifier=""""
title=""Users rated this 7.9/10 (192,347 votes) - click stars to rate"" >
<span class=""rating-bg"">&nbsp;</span>
<span class=""rating-imdb "" style=""width: 110.6px"">&nbsp;</span>
<span class=""rating-stars"">
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>1</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>2</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>3</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>4</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>5</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>6</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>7</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>8</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>9</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>10</span></a>
</span>
<span class=""rating-rating ""><span class=""value"">7.9</span><span class=""grey"">/</span><span class=""grey"">10</span></span>
<span class=""rating-cancel ""><a href=""/title/tt0190332/vote?v=X;k="" title=""Delete"" rel=""nofollow""><span>X</span></a></span>
&nbsp;</div>
               <div class=""rec-outline"">
    <p>
Two warriors in pursuit of a stolen sword and a notorious fugitive are led to an impetuous, physically skilled, adolescent nobleman's daughter, who is at a crossroads in her life.    </p>
               </div>
             </div>
           </div>
           <div class=""rec-jaw-lower"">
             <div class=""rec-jaw-teeth""></div>
 <div class=""rec-director rec-ellipsis"">
      <b>Director:</b>
Ang Lee  </div>
<div class=""rec-actor rec-ellipsis""> <span>
    <b>Stars:</b>
Yun-Fat Chow,
Michelle Yeoh,
Ziyi Zhang</span></div>
           </div>
         </div>
       </div>
      </div>
      <div class=""rec_overview"" data-tconst=""tt0110475"">
    <div class=""rec_poster"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0110475"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0110475/?ref_=tt_rec_tti""
><img height=""190"" width=""128"" alt=""The Mask"" title=""The Mask""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/large/film-184890147._CB379391879_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMjM3NDI5OTA5Nl5BMl5BanBnXkFtZTgwNzE4ODYxMTE@._V1_SX128_CR0,0,128,190_AL_.jpg"" /> <br/>
</a>    </div>
       <div class=""rec_actions"">
         <div class=""rec_action_divider"">
           <div class=""wlb_classic_wrapper"">
             <span class=""wlb_wrapper"">
               <a class=""rec_wlb_watchlist_btn"" data-tconst=""tt0110475"" data-size=""medium"" data-caller-name=""p13nsims-title"" data-type=""primary""></a>
             </span>
           </div>
         </div>
         <div class=""rec_action_divider"">
           <span class=""btn2_wrapper"">
             <a class=""rec_next rec_half_button btn2 medium btn2_text_on"" title=""Show me the next title"" onclick="""">
               <span class=""btn2_glyph"">0</span>
               <span class=""btn2_text"">Next &raquo;</span>
             </a>
           </span>
         </div>
             <input type=""hidden"" name=""49e6c"" value=""4998"">
       </div>
       <div class=""rec_details"">
         <div class=""rec-info"">
           <div class=""rec-jaw-upper"">
     <div class=""rec-title"">
       <a href=""/title/tt0110475/?ref_=tt_rec_tt""
><b>The Mask</b></a>
            <span class=""nobr"">(1994)</span>
   </div>
    <div class=""rec-cert-genre rec-elipsis"">
                    Certificate: PG
                     Comedy
 <span class=""ghost"">|</span>
                     Crime
 <span class=""ghost"">|</span>
                     Fantasy
    </div>
             <div class=""rec-rating"">
<div class=""rating rating-list"" data-starbar-class=""rating-list"" data-auth="""" data-user="""" id=""tt0110475|imdb|6.8|6.8|p13nsims-title|tt0446029|title|main"" data-ga-identifier=""""
title=""Users rated this 6.8/10 (197,726 votes) - click stars to rate"" >
<span class=""rating-bg"">&nbsp;</span>
<span class=""rating-imdb "" style=""width: 95.2px"">&nbsp;</span>
<span class=""rating-stars"">
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>1</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>2</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>3</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>4</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>5</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>6</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>7</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>8</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>9</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>10</span></a>
</span>
<span class=""rating-rating ""><span class=""value"">6.8</span><span class=""grey"">/</span><span class=""grey"">10</span></span>
<span class=""rating-cancel ""><a href=""/title/tt0110475/vote?v=X;k="" title=""Delete"" rel=""nofollow""><span>X</span></a></span>
&nbsp;</div>
               <div class=""rec-outline"">
    <p>
Bank clerk Stanley Ipkiss is transformed into a manic super-hero when he wears a mysterious mask.    </p>
               </div>
             </div>
           </div>
           <div class=""rec-jaw-lower"">
             <div class=""rec-jaw-teeth""></div>
 <div class=""rec-director rec-ellipsis"">
      <b>Director:</b>
Chuck Russell  </div>
<div class=""rec-actor rec-ellipsis""> <span>
    <b>Stars:</b>
Jim Carrey,
Cameron Diaz,
Peter Riegert</span></div>
           </div>
         </div>
       </div>
      </div>
      <div class=""rec_overview"" data-tconst=""tt0385004"">
    <div class=""rec_poster"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0385004"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0385004/?ref_=tt_rec_tti""
><img height=""190"" width=""128"" alt=""Shi mian mai fu"" title=""Shi mian mai fu""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/large/film-184890147._CB379391879_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMzg4MDE0NzIwNl5BMl5BanBnXkFtZTcwMDI2NDcyMQ@@._V1_SY190_CR0,0,128,190_AL_.jpg"" /> <br/>
</a>    </div>
       <div class=""rec_actions"">
         <div class=""rec_action_divider"">
           <div class=""wlb_classic_wrapper"">
             <span class=""wlb_wrapper"">
               <a class=""rec_wlb_watchlist_btn"" data-tconst=""tt0385004"" data-size=""medium"" data-caller-name=""p13nsims-title"" data-type=""primary""></a>
             </span>
           </div>
         </div>
         <div class=""rec_action_divider"">
           <span class=""btn2_wrapper"">
             <a class=""rec_next rec_half_button btn2 medium btn2_text_on"" title=""Show me the next title"" onclick="""">
               <span class=""btn2_glyph"">0</span>
               <span class=""btn2_text"">Next &raquo;</span>
             </a>
           </span>
         </div>
             <input type=""hidden"" name=""49e6c"" value=""4998"">
       </div>
       <div class=""rec_details"">
         <div class=""rec-info"">
           <div class=""rec-jaw-upper"">
     <div class=""rec-title"">
       <a href=""/title/tt0385004/?ref_=tt_rec_tt""
><b>Shi mian mai fu</b></a>
            <span class=""nobr"">(2004)</span>
   </div>
    <div class=""rec-cert-genre rec-elipsis"">
                    Certificate: 14A
                     Action
 <span class=""ghost"">|</span>
                     Adventure
 <span class=""ghost"">|</span>
                     Drama
    </div>
             <div class=""rec-rating"">
<div class=""rating rating-list"" data-starbar-class=""rating-list"" data-auth="""" data-user="""" id=""tt0385004|imdb|7.6|7.6|p13nsims-title|tt0446029|title|main"" data-ga-identifier=""""
title=""Users rated this 7.6/10 (79,358 votes) - click stars to rate"" >
<span class=""rating-bg"">&nbsp;</span>
<span class=""rating-imdb "" style=""width: 106.4px"">&nbsp;</span>
<span class=""rating-stars"">
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>1</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>2</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>3</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>4</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>5</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>6</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>7</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>8</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>9</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>10</span></a>
</span>
<span class=""rating-rating ""><span class=""value"">7.6</span><span class=""grey"">/</span><span class=""grey"">10</span></span>
<span class=""rating-cancel ""><a href=""/title/tt0385004/vote?v=X;k="" title=""Delete"" rel=""nofollow""><span>X</span></a></span>
&nbsp;</div>
               <div class=""rec-outline"">
    <p>
A romantic police captain breaks a beautiful member of a rebel group out of prison to help her rejoin her fellows, but things are not what they seem.    </p>
               </div>
             </div>
           </div>
           <div class=""rec-jaw-lower"">
             <div class=""rec-jaw-teeth""></div>
 <div class=""rec-director rec-ellipsis"">
      <b>Director:</b>
Yimou Zhang  </div>
<div class=""rec-actor rec-ellipsis""> <span>
    <b>Stars:</b>
Ziyi Zhang,
Takeshi Kaneshiro,
Andy Lau</span></div>
           </div>
         </div>
       </div>
      </div>
      <div class=""rec_overview"" data-tconst=""tt0477347"">
    <div class=""rec_poster"" data-info="""" data-spec=""p13nsims:tt0446029"" data-tconst=""tt0477347"">
        <div class=""rec_overlay"">
            <div class=""rec_filter""></div>
            <div class=""glyph rec_watchlist_glyph""></div>
            <div class=""glyph rec_blocked_glyph""></div>
            <div class=""glyph rec_rating_glyph""></div>
            <div class=""glyph rec_pending_glyph""></div>
        </div>
<a href=""/title/tt0477347/?ref_=tt_rec_tti""
><img height=""190"" width=""128"" alt=""Night at the Museum"" title=""Night at the Museum""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/large/film-184890147._CB379391879_.png""class=""loadlate hidden rec_poster_img"" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTQyOTM4MDMxN15BMl5BanBnXkFtZTcwODg5NTQzMw@@._V1_SY190_CR1,0,128,190_AL_.jpg"" /> <br/>
</a>    </div>
       <div class=""rec_actions"">
         <div class=""rec_action_divider"">
           <div class=""wlb_classic_wrapper"">
             <span class=""wlb_wrapper"">
               <a class=""rec_wlb_watchlist_btn"" data-tconst=""tt0477347"" data-size=""medium"" data-caller-name=""p13nsims-title"" data-type=""primary""></a>
             </span>
           </div>
         </div>
         <div class=""rec_action_divider"">
           <span class=""btn2_wrapper"">
             <a class=""rec_next rec_half_button btn2 medium btn2_text_on"" title=""Show me the next title"" onclick="""">
               <span class=""btn2_glyph"">0</span>
               <span class=""btn2_text"">Next &raquo;</span>
             </a>
           </span>
         </div>
             <input type=""hidden"" name=""49e6c"" value=""4998"">
       </div>
       <div class=""rec_details"">
         <div class=""rec-info"">
           <div class=""rec-jaw-upper"">
     <div class=""rec-title"">
       <a href=""/title/tt0477347/?ref_=tt_rec_tt""
><b>Night at the Museum</b></a>
            <span class=""nobr"">(2006)</span>
   </div>
    <div class=""rec-cert-genre rec-elipsis"">
                    Certificate: PG
                     Action
 <span class=""ghost"">|</span>
                     Adventure
 <span class=""ghost"">|</span>
                     Comedy
    </div>
             <div class=""rec-rating"">
<div class=""rating rating-list"" data-starbar-class=""rating-list"" data-auth="""" data-user="""" id=""tt0477347|imdb|6.3|6.3|p13nsims-title|tt0446029|title|main"" data-ga-identifier=""""
title=""Users rated this 6.3/10 (169,335 votes) - click stars to rate"" >
<span class=""rating-bg"">&nbsp;</span>
<span class=""rating-imdb "" style=""width: 88.2px"">&nbsp;</span>
<span class=""rating-stars"">
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>1</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>2</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>3</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>4</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>5</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>6</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>7</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>8</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>9</span></a>
      <a href=""/register/login?why=vote&ref_=tt_ov_rt""
rel=""nofollow"" title=""Register or login to rate this title"" ><span>10</span></a>
</span>
<span class=""rating-rating ""><span class=""value"">6.3</span><span class=""grey"">/</span><span class=""grey"">10</span></span>
<span class=""rating-cancel ""><a href=""/title/tt0477347/vote?v=X;k="" title=""Delete"" rel=""nofollow""><span>X</span></a></span>
&nbsp;</div>
               <div class=""rec-outline"">
    <p>
A newly recruited night security guard at the Museum of Natural History discovers that an ancient curse causes the animals and exhibits on display to come to life and wreak havoc.    </p>
               </div>
             </div>
           </div>
           <div class=""rec-jaw-lower"">
             <div class=""rec-jaw-teeth""></div>
 <div class=""rec-director rec-ellipsis"">
      <b>Director:</b>
Shawn Levy  </div>
<div class=""rec-actor rec-ellipsis""> <span>
    <b>Stars:</b>
Ben Stiller,
Carla Gugino,
Ricky Gervais</span></div>
           </div>
         </div>
       </div>
      </div>
   </div>
            </div>
        </div>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleRecsWidget_finished');
    }
  </script>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleCastWidget_started');
    }
  </script>
    <div class=""article"" id=""titleCast"">
    <span class=rightcornerlink >
            <a href=""/register/login?why=edit&ref_=tt_cl""
rel=""login"">Edit</a>
    </span>
        <h2>Cast</h2>
        <table class=""cast_list"">
  <tr><td colspan=""4"" class=""castlist_label"">Cast overview, first billed only:</td></tr>
      <tr class=""odd"">
          <td class=""primary_photo"">
<a href=""/name/nm0148418/?ref_=tt_cl_i1""
><img height=""44"" width=""32"" alt=""Michael Cera"" title=""Michael Cera""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/32x44/name-2138558783._CB379389446_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BNTgyNDgxMjUyOV5BMl5BanBnXkFtZTcwMDYxNzY1OQ@@._V1_SX32_CR0,0,32,44_AL_.jpg"" /></a>          </td>
          <td class=""itemprop"" itemprop=""actor"" itemscope itemtype=""http://schema.org/Person"">
<a href=""/name/nm0148418/?ref_=tt_cl_t1""
itemprop='url'> <span class=""itemprop"" itemprop=""name"">Michael Cera</span>
</a>          </td>
          <td class=""ellipsis"">
              ...
          </td>
          <td class=""character"">
              <div>
            <a href=""/character/ch0117739/?ref_=tt_cl_t1"" >Scott Pilgrim</a>
              </div>
          </td>
      </tr>
      <tr class=""even"">
          <td class=""primary_photo"">
<a href=""/name/nm0683467/?ref_=tt_cl_i2""
><img height=""44"" width=""32"" alt=""Alison Pill"" title=""Alison Pill""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/32x44/name-2138558783._CB379389446_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMjA4NDMyMDkzMl5BMl5BanBnXkFtZTcwNjQ4ODgwMg@@._V1_SX32_CR0,0,32,44_AL_.jpg"" /></a>          </td>
          <td class=""itemprop"" itemprop=""actor"" itemscope itemtype=""http://schema.org/Person"">
<a href=""/name/nm0683467/?ref_=tt_cl_t2""
itemprop='url'> <span class=""itemprop"" itemprop=""name"">Alison Pill</span>
</a>          </td>
          <td class=""ellipsis"">
              ...
          </td>
          <td class=""character"">
              <div>
            <a href=""/character/ch0131062/?ref_=tt_cl_t2"" >Kim Pine</a>
              </div>
          </td>
      </tr>
      <tr class=""odd"">
          <td class=""primary_photo"">
<a href=""/name/nm0916406/?ref_=tt_cl_i3""
><img height=""44"" width=""32"" alt=""Mark Webber"" title=""Mark Webber""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/32x44/name-2138558783._CB379389446_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTQwNzgyNTY0OV5BMl5BanBnXkFtZTgwNzM3ODA3MTE@._V1_SX32_CR0,0,32,44_AL_.jpg"" /></a>          </td>
          <td class=""itemprop"" itemprop=""actor"" itemscope itemtype=""http://schema.org/Person"">
<a href=""/name/nm0916406/?ref_=tt_cl_t3""
itemprop='url'> <span class=""itemprop"" itemprop=""name"">Mark Webber</span>
</a>          </td>
          <td class=""ellipsis"">
              ...
          </td>
          <td class=""character"">
              <div>
            <a href=""/character/ch0131066/?ref_=tt_cl_t3"" >Stephen Stills</a>
              </div>
          </td>
      </tr>
      <tr class=""even"">
          <td class=""primary_photo"">
<a href=""/name/nm2215447/?ref_=tt_cl_i4""
><img height=""44"" width=""32"" alt=""Johnny Simmons"" title=""Johnny Simmons""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/32x44/name-2138558783._CB379389446_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTA1MzM3MDY4MjZeQTJeQWpwZ15BbWU3MDU1NTIyNzc@._V1_SX32_CR0,0,32,44_AL_.jpg"" /></a>          </td>
          <td class=""itemprop"" itemprop=""actor"" itemscope itemtype=""http://schema.org/Person"">
<a href=""/name/nm2215447/?ref_=tt_cl_t4""
itemprop='url'> <span class=""itemprop"" itemprop=""name"">Johnny Simmons</span>
</a>          </td>
          <td class=""ellipsis"">
              ...
          </td>
          <td class=""character"">
              <div>
            <a href=""/character/ch0132188/?ref_=tt_cl_t4"" >Young Neil</a>
              </div>
          </td>
      </tr>
      <tr class=""odd"">
          <td class=""primary_photo"">
<a href=""/name/nm2771798/?ref_=tt_cl_i5""
><img height=""44"" width=""32"" alt=""Ellen Wong"" title=""Ellen Wong""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/32x44/name-2138558783._CB379389446_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTk4MDAxMzQyNF5BMl5BanBnXkFtZTcwMDgyMzUzNw@@._V1_SY44_CR16,0,32,44_AL_.jpg"" /></a>          </td>
          <td class=""itemprop"" itemprop=""actor"" itemscope itemtype=""http://schema.org/Person"">
<a href=""/name/nm2771798/?ref_=tt_cl_t5""
itemprop='url'> <span class=""itemprop"" itemprop=""name"">Ellen Wong</span>
</a>          </td>
          <td class=""ellipsis"">
              ...
          </td>
          <td class=""character"">
              <div>
            <a href=""/character/ch0125522/?ref_=tt_cl_t5"" >Knives Chau</a>
              </div>
          </td>
      </tr>
      <tr class=""even"">
          <td class=""primary_photo"">
<a href=""/name/nm0001085/?ref_=tt_cl_i6""
><img height=""44"" width=""32"" alt=""Kieran Culkin"" title=""Kieran Culkin""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/32x44/name-2138558783._CB379389446_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTYzODUyMTU5M15BMl5BanBnXkFtZTcwNTQ0ODk2Mw@@._V1_SY44_CR0,0,32,44_AL_.jpg"" /></a>          </td>
          <td class=""itemprop"" itemprop=""actor"" itemscope itemtype=""http://schema.org/Person"">
<a href=""/name/nm0001085/?ref_=tt_cl_t6""
itemprop='url'> <span class=""itemprop"" itemprop=""name"">Kieran Culkin</span>
</a>          </td>
          <td class=""ellipsis"">
              ...
          </td>
          <td class=""character"">
              <div>
            <a href=""/character/ch0131064/?ref_=tt_cl_t6"" >Wallace Wells</a>
              </div>
          </td>
      </tr>
      <tr class=""odd"">
          <td class=""primary_photo"">
<a href=""/name/nm0447695/?ref_=tt_cl_i7""
><img height=""44"" width=""32"" alt=""Anna Kendrick"" title=""Anna Kendrick""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/32x44/name-2138558783._CB379389446_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMjIzOTA0OTQyN15BMl5BanBnXkFtZTcwMjE1OTIwMw@@._V1_SX32_CR0,0,32,44_AL_.jpg"" /></a>          </td>
          <td class=""itemprop"" itemprop=""actor"" itemscope itemtype=""http://schema.org/Person"">
<a href=""/name/nm0447695/?ref_=tt_cl_t7""
itemprop='url'> <span class=""itemprop"" itemprop=""name"">Anna Kendrick</span>
</a>          </td>
          <td class=""ellipsis"">
              ...
          </td>
          <td class=""character"">
              <div>
            <a href=""/character/ch0131059/?ref_=tt_cl_t7"" >Stacey Pilgrim</a>
              </div>
          </td>
      </tr>
      <tr class=""even"">
          <td class=""primary_photo"">
<a href=""/name/nm2201555/?ref_=tt_cl_i8""
><img height=""44"" width=""32"" alt=""Aubrey Plaza"" title=""Aubrey Plaza""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/32x44/name-2138558783._CB379389446_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMjIyMzYyMjQ5OV5BMl5BanBnXkFtZTcwMTA0MTkxNw@@._V1_SX32_CR0,0,32,44_AL_.jpg"" /></a>          </td>
          <td class=""itemprop"" itemprop=""actor"" itemscope itemtype=""http://schema.org/Person"">
<a href=""/name/nm2201555/?ref_=tt_cl_t8""
itemprop='url'> <span class=""itemprop"" itemprop=""name"">Aubrey Plaza</span>
</a>          </td>
          <td class=""ellipsis"">
              ...
          </td>
          <td class=""character"">
              <div>
            <a href=""/character/ch0131065/?ref_=tt_cl_t8"" >Julie Powers</a>
              </div>
          </td>
      </tr>
      <tr class=""odd"">
          <td class=""primary_photo"">
<a href=""/name/nm0935541/?ref_=tt_cl_i9""
><img height=""44"" width=""32"" alt=""Mary Elizabeth Winstead"" title=""Mary Elizabeth Winstead""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/32x44/name-2138558783._CB379389446_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTUwNjk4ODIwMF5BMl5BanBnXkFtZTcwMzU2MDYwOQ@@._V1_SX32_CR0,0,32,44_AL_.jpg"" /></a>          </td>
          <td class=""itemprop"" itemprop=""actor"" itemscope itemtype=""http://schema.org/Person"">
<a href=""/name/nm0935541/?ref_=tt_cl_t9""
itemprop='url'> <span class=""itemprop"" itemprop=""name"">Mary Elizabeth Winstead</span>
</a>          </td>
          <td class=""ellipsis"">
              ...
          </td>
          <td class=""character"">
              <div>
            <a href=""/character/ch0119014/?ref_=tt_cl_t9"" >Ramona Flowers</a>
              </div>
          </td>
      </tr>
      <tr class=""even"">
          <td class=""primary_photo"">
<a href=""/name/nm2313157/?ref_=tt_cl_i10""
><img height=""44"" width=""32"" alt=""Ben Lewis"" title=""Ben Lewis""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/32x44/name-2138558783._CB379389446_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMTk1NTg1OTQ2NV5BMl5BanBnXkFtZTcwMTQzNzc0OA@@._V1_SY44_CR1,0,32,44_AL_.jpg"" /></a>          </td>
          <td class=""itemprop"" itemprop=""actor"" itemscope itemtype=""http://schema.org/Person"">
<a href=""/name/nm2313157/?ref_=tt_cl_t10""
itemprop='url'> <span class=""itemprop"" itemprop=""name"">Ben Lewis</span>
</a>          </td>
          <td class=""ellipsis"">
              ...
          </td>
          <td class=""character"">
              <div>
            <a href=""/character/ch0244030/?ref_=tt_cl_t10"" >Other Scott</a>
              </div>
          </td>
      </tr>
      <tr class=""odd"">
          <td class=""primary_photo"">
<a href=""/name/nm1815689/?ref_=tt_cl_i11""
><img height=""44"" width=""32"" alt=""Nelson Franklin"" title=""Nelson Franklin""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/32x44/name-2138558783._CB379389446_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMjY0NDcxNzk0Ml5BMl5BanBnXkFtZTcwMDcxNjE3MQ@@._V1_SX32_CR0,0,32,44_AL_.jpg"" /></a>          </td>
          <td class=""itemprop"" itemprop=""actor"" itemscope itemtype=""http://schema.org/Person"">
<a href=""/name/nm1815689/?ref_=tt_cl_t11""
itemprop='url'> <span class=""itemprop"" itemprop=""name"">Nelson Franklin</span>
</a>          </td>
          <td class=""ellipsis"">
              ...
          </td>
          <td class=""character"">
              <div>
            <a href=""/character/ch0137207/?ref_=tt_cl_t11"" >Comeau</a>
              </div>
          </td>
      </tr>
      <tr class=""even"">
          <td class=""primary_photo"">
<a href=""/name/nm1869640/?ref_=tt_cl_i12""
><img height=""44"" width=""32"" alt=""Kristina Pesic"" title=""Kristina Pesic""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/32x44/name-2138558783._CB379389446_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BNjE4MTAzMTU1OF5BMl5BanBnXkFtZTgwMjgwMzI1MTE@._V1_SX32_CR0,0,32,44_AL_.jpg"" /></a>          </td>
          <td class=""itemprop"" itemprop=""actor"" itemscope itemtype=""http://schema.org/Person"">
<a href=""/name/nm1869640/?ref_=tt_cl_t12""
itemprop='url'> <span class=""itemprop"" itemprop=""name"">Kristina Pesic</span>
</a>          </td>
          <td class=""ellipsis"">
              ...
          </td>
          <td class=""character"">
              <div>
            <a href=""/character/ch0244031/?ref_=tt_cl_t12"" >Sandra</a>
              </div>
          </td>
      </tr>
      <tr class=""odd"">
          <td class=""primary_photo"">
<a href=""/name/nm2618497/?ref_=tt_cl_i13""
><img height=""44"" width=""32"" alt=""Ingrid Haas"" title=""Ingrid Haas""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/32x44/name-2138558783._CB379389446_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMjMzODAyOTg1MV5BMl5BanBnXkFtZTgwNTgzOTQxMjE@._V1_SX32_CR0,0,32,44_AL_.jpg"" /></a>          </td>
          <td class=""itemprop"" itemprop=""actor"" itemscope itemtype=""http://schema.org/Person"">
<a href=""/name/nm2618497/?ref_=tt_cl_t13""
itemprop='url'> <span class=""itemprop"" itemprop=""name"">Ingrid Haas</span>
</a>          </td>
          <td class=""ellipsis"">
              ...
          </td>
          <td class=""character"">
              <div>
            <a href=""/character/ch0244032/?ref_=tt_cl_t13"" >Monique</a>
              </div>
          </td>
      </tr>
      <tr class=""even"">
          <td class=""primary_photo"">
<a href=""/name/nm0653279/?ref_=tt_cl_i14""
><img height=""44"" width=""32"" alt=""Marlee Otto"" title=""Marlee Otto""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/32x44/name-2138558783._CB379389446_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BNzgzNzY4NjYxMV5BMl5BanBnXkFtZTgwNTM5MjM5MDE@._V1_SY44_CR16,0,32,44_AL_.jpg"" /></a>          </td>
          <td class=""itemprop"" itemprop=""actor"" itemscope itemtype=""http://schema.org/Person"">
<a href=""/name/nm0653279/?ref_=tt_cl_t14""
itemprop='url'> <span class=""itemprop"" itemprop=""name"">Marlee Otto</span>
</a>          </td>
          <td class=""ellipsis"">
              ...
          </td>
          <td class=""character"">
              <div>
            Party Goer
              </div>
          </td>
      </tr>
      <tr class=""odd"">
          <td class=""primary_photo"">
<a href=""/name/nm2012029/?ref_=tt_cl_i15""
><img height=""44"" width=""32"" alt=""Will Bowes"" title=""Will Bowes""src=""http://ia.media-imdb.com/images/G/01/imdb/images/nopicture/32x44/name-2138558783._CB379389446_.png""class=""loadlate hidden "" loadlate=""http://ia.media-imdb.com/images/M/MV5BMzg5MDkzMjcwM15BMl5BanBnXkFtZTcwNjU4MzQ1OA@@._V1_SY44_CR1,0,32,44_AL_.jpg"" /></a>          </td>
          <td class=""itemprop"" itemprop=""actor"" itemscope itemtype=""http://schema.org/Person"">
<a href=""/name/nm2012029/?ref_=tt_cl_t15""
itemprop='url'> <span class=""itemprop"" itemprop=""name"">Will Bowes</span>
</a>          </td>
          <td class=""ellipsis"">
              ...
          </td>
          <td class=""character"">
              <div>
            Party Goer
  (as Will Seatle Bowes)
              </div>
          </td>
      </tr>
        </table>
        <div class=""see-more"">
            <a href=""fullcredits?ref_=tt_cl_sm#cast""
>See full cast</a>&nbsp;&raquo;
        </div>
    </div>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleCastWidget_finished');
    }
  </script>
    <!-- no content received for slot: maindetails_center_ad -->
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleStorylineWidget_started');
    }
  </script>
    <div class = ""article"" id=""titleStoryLine"">
    <span class=rightcornerlink >
            <a href=""/register/login?why=edit&ref_=tt_stry""
rel=""login"">Edit</a>
    </span>
        <h2>Storyline</h2>
        <div class=""inline canwrap"" itemprop=""description"">
            <p>
Scott Pilgrim plays in a band which aspires to success. He dates Knives Chau, a high-school girl five years younger, and he hasn't recovered from being dumped by his former girlfriend, now a success with her own band. When Scott falls for Ramona Flowers, he has trouble breaking up with Knives and tries to romance Ramona. As if juggling two women wasn't enough, Ramona comes with baggage: seven ex-lovers, with each of whom Scott must do battle to the death in order to win Ramona.                <em class=""nobr"">Written by
<a href=""/search/title?plot_author=Jim Beaver <jumblejim@prodigy.net>&view=simple&sort=alpha""
>Jim Beaver &lt;jumblejim@prodigy.net&gt;</a></em>            </p>
        </div>
        <span class=""see-more inline"">
                <a href=""/title/tt0446029/plotsummary?ref_=tt_stry_pl""
>Plot Summary</a>
    <span>|</span>
        <a href=""/title/tt0446029/synopsis?ref_=tt_stry_pl""
>Plot Synopsis</a>
    </span>
        <hr />
        <div class=""see-more inline canwrap"" itemprop=""keywords"">
            <h4 class=""inline"">Plot Keywords:</h4>
<a href=""/keyword/band?ref_=tt_stry_kw""
> <span class=""itemprop"" itemprop=""keywords"">band</span></a>
                    <span>|</span>
<a href=""/keyword/dating?ref_=tt_stry_kw""
> <span class=""itemprop"" itemprop=""keywords"">dating</span></a>
                    <span>|</span>
<a href=""/keyword/high-school?ref_=tt_stry_kw""
> <span class=""itemprop"" itemprop=""keywords"">high school</span></a>
                    <span>|</span>
<a href=""/keyword/hipster?ref_=tt_stry_kw""
> <span class=""itemprop"" itemprop=""keywords"">hipster</span></a>
                    <span>|</span>
<a href=""/keyword/rock-band?ref_=tt_stry_kw""
> <span class=""itemprop"" itemprop=""keywords"">rock band</span></a>
                                            <span>|</span>&nbsp;<nobr><a href=""/title/tt0446029/keywords?ref_=tt_stry_kw""
>See more</a>&nbsp;&raquo;</nobr>
        </div>
        <hr />
        <div class=""txt-block"">
            <h4 class=""inline"">Taglines:</h4>
Get the hot girl. Defeat her evil exes. Hit love where it hurts.                <span class=""see-more inline"">
<a href=""/title/tt0446029/taglines?ref_=tt_stry_tg""
> See more</a>&nbsp;&raquo;
                </span>
        </div>
        <hr />
        <div class=""see-more inline canwrap"" itemprop=""genre"">
            <h4 class=""inline"">Genres:</h4>
<a href=""/genre/Action?ref_=tt_stry_gnr""
> Action</a>&nbsp;<span>|</span>
<a href=""/genre/Comedy?ref_=tt_stry_gnr""
> Comedy</a>&nbsp;<span>|</span>
<a href=""/genre/Romance?ref_=tt_stry_gnr""
> Romance</a>
        </div>
             <hr/>
    <div class=""txt-block"">
            <h4 class=""inline"">Certificate:</h4>
            <span itemprop=""contentRating"">PG</span>
<span class=""ghost"">|</span>            <span class=""see-more inline"">
<a href=""/title/tt0446029/parentalguide?ref_=tt_stry_pg#certification""
> See all certifications</a>&nbsp;&raquo;
            </span>
    </div>
    <div class=""txt-block"">
        <h4 class=""inline"">Parents Guide:</h4>
        <span class=""see-more inline"" itemprop=""audience"" itemscope itemtype=""http://schema.org/Audience"">
<a href=""/title/tt0446029/parentalguide?ref_=tt_stry_pg""
itemprop='url'> View content advisory</a>&nbsp;&raquo;
        </span>
    </div>
    </div>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleStorylineWidget_finished');
    }
  </script>

  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleDetailsWidget_started');
    }
  </script>
    <div class = ""article"" id=""titleDetails"">
    <span class=rightcornerlink >
            <a href=""/register/login?why=edit&ref_=tt_dt_dt""
rel=""login"">Edit</a>
    </span>
        <h2>Details</h2>
      <div class=""txt-block"">
      <h4 class=""inline"">Official Sites:</h4>
    <a href=""/offsite/?page-action=imdb&token=BCYtDhgFPRiMnZsYaz5j7GzkivsUmWP_MocGvElraucF75oUfdl82Y0-anJfuGXq4cBB2_lOsZhG%0D%0AUC7dxUM2Ex0LlA4OhRNs3ZXZj7HsDXMgjy_sBdqDg0aQtdZC2kksdfSgF1B9aUQJUnplAPTj-Ask%0D%0AtrOlDZc5hHqjZA5BHcxx3VtgDqWwtpN_KwYCQ7sHoIfxCIb5Gh7MT2UWoRYQWMDK9EpWZ-n1KFAK%0D%0APBk72pCMKAvXhV5CT4DBHA5mQPRq2akv%0D%0A&ref_=tt_pdt_ofs_offsite_0""
rel=""nofollow"" itemprop='url'>Official site [France]</a>
          <span class=""ghost"">|</span>
    <a href=""/offsite/?page-action=imdb&token=BCYnXyh1ZsRSQBKLHBi7KHV_f27uhHVxkG6qxWKBEI1VCfPmbtjfXDQ9pTbmesxmTgdvYwDwBzsi%0D%0ASwikEQnvu3WyNKw45AlVVWtHWaErdzGN2Wm9DiL3-Bkg2RWHy1A21MhEIpIPv4CQPxRXBMzjzJnL%0D%0AN-EX88R0iuCpbZY7GGAqZ01e2xhgB631SYm1jCcOFp08-bRCMWyOYLlpguFVM4T2vRZKKKCNhnf9%0D%0AmEqEMWkdUXI%0D%0A&ref_=tt_pdt_ofs_offsite_1""
rel=""nofollow"" itemprop='url'>Universal [United States]</a>
               <span class=""see-more inline"">
      </span>
      </div>
    <div class=""txt-block"">
    <h4 class=""inline"">Country:</h4>
        <a href=""/country/us?ref_=tt_dt_dt""
itemprop='url'>USA</a>
              <span class=""ghost"">|</span>
        <a href=""/country/gb?ref_=tt_dt_dt""
itemprop='url'>UK</a>
              <span class=""ghost"">|</span>
        <a href=""/country/ca?ref_=tt_dt_dt""
itemprop='url'>Canada</a>
              <span class=""ghost"">|</span>
        <a href=""/country/jp?ref_=tt_dt_dt""
itemprop='url'>Japan</a>
    </div>
    <div class=""txt-block"">
    <h4 class=""inline"">Language:</h4>
        <a href=""/language/en?ref_=tt_dt_dt""
itemprop='url'>English</a>
    </div>
    <div class=""txt-block"">
    <h4 class=""inline"">Release Date:</h4> 13 August 2010 (Canada)
    <span class=""see-more inline"">
      <a href=""releaseinfo?ref_=tt_dt_dt""
itemprop='url'>See more</a>&nbsp;&raquo;
    </span>
    </div>
      <div class=""txt-block"">
      <h4 class=""inline"">Also Known As:</h4> Scott Pilgrim Contra o Mundo
      <span class=""see-more inline"">
        <a href=""releaseinfo?ref_=tt_dt_dt#akas""
itemprop='url'>See more</a>&nbsp;&raquo;
      </span>
      </div>
    <div class=""txt-block"">
    <h4 class=""inline"">Filming Locations:</h4>
    <a href=""/search/title?locations=Bloor Street West, Toronto, Ontario, Canada""
itemprop='url'>Bloor Street West, Toronto, Ontario, Canada</a>
      <span class=""see-more inline"">
        <a href=""locations?ref_=tt_dt_dt""
itemprop='url'>See more</a>&nbsp;&raquo;
      </span>
    </div>
    <hr />
    <h3>Box Office</h3>
      <div class=""txt-block"">
      <h4 class=""inline"">Budget:</h4>        $60,000,000
      <span class=""attribute"">(estimated)</span>
      </div>
    <div class=""txt-block"">
    <h4 class=""inline"">Opening Weekend:</h4>         &pound;1,604,545
      (UK)
      <span class=""attribute"">(27 August 2010)</span>
    </div>
    <div class=""txt-block"">
    <h4 class=""inline"">Gross:</h4>        $31,494,270
      <span class=""attribute"">(USA)</span>
      <span class=""attribute"">(2 October 2010)</span>
    </div>
  <span class=""see-more inline"">
    <a href=""business?ref_=tt_dt_bus""
itemprop='url'>See more</a>&nbsp;&raquo;
  </span>
  <hr />
  <h3>Company Credits</h3>
    <div class=""txt-block"">
    <h4 class=""inline"">Production Co:</h4>
        <span itemprop=""creator"" itemscope itemtype=""http://schema.org/Organization"">
<a href=""/company/co0005073?ref_=tt_dt_co""
itemprop='url'><span class=""itemprop"" itemprop=""name"">Universal Pictures</span></a></span>,        <span itemprop=""creator"" itemscope itemtype=""http://schema.org/Organization"">
<a href=""/company/co0093810?ref_=tt_dt_co""
itemprop='url'><span class=""itemprop"" itemprop=""name"">Marc Platt Productions</span></a></span>,        <span itemprop=""creator"" itemscope itemtype=""http://schema.org/Organization"">
<a href=""/company/co0131363?ref_=tt_dt_co""
itemprop='url'><span class=""itemprop"" itemprop=""name"">Big Talk Productions</span></a></span>      <span class=""see-more inline"">
        <a href=""companycredits?ref_=tt_dt_co""
itemprop='url'>See more</a>&nbsp;&raquo;
      </span>
    </div>
  <div class=""txt-block"">
  Show detailed
<a href=""http://pro.imdb.com/title/tt0446029/companycredits?rf=cons_tt_cocred_tt&ref_=cons_tt_cocred_tt""
itemprop='url'>company contact information</a>
  on
  <a href=""http://pro.imdb.com/signup/index.html?rf=cons_tt_cocred_spl&ref_=cons_tt_cocred_spl""
itemprop='url'>IMDbPro</a>&nbsp;&raquo;
  </div>
  <hr />
  <h3>Technical Specs</h3>
    <div class=""txt-block"">
      <h4 class=""inline"">Runtime:</h4>
        <time itemprop=""duration"" datetime=""PT112M"">112 min</time>
    </div>
    <div class=""txt-block"">
    <h4 class=""inline"">Sound Mix:</h4>
        <a href=""/search/title?sound_mixes=sdds&ref_=tt_dt_spec""
itemprop='url'>SDDS</a>
<span class=""ghost"">|</span>        <a href=""/search/title?sound_mixes=dolby_digital&ref_=tt_dt_spec""
itemprop='url'>Dolby Digital</a>
<span class=""ghost"">|</span>        <a href=""/search/title?sound_mixes=dts&ref_=tt_dt_spec""
itemprop='url'>DTS</a>
    </div>
    <div class=""txt-block"">
    <h4 class=""inline"">Color:</h4>
        <a href=""/search/title?colors=color&ref_=tt_dt_spec""
itemprop='url'>Color</a>
    </div>
    <div class=""txt-block"">
    <h4 class=""inline"">Aspect Ratio:</h4> 1.85 : 1
    </div>
  See <a href=""technical?ref_=tt_dt_spec""
itemprop='url'>full technical specs</a>&nbsp;&raquo;
    </div>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleDetailsWidget_finished');
    }
  </script>

  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleDidYouKnowWidget_started');
    }
  </script>
    <div id=""titleDidYouKnow"" class=""article"">
    <span class=rightcornerlink >
            <a href=""/register/login?why=edit&ref_=tt_trv_trv""
rel=""login"">Edit</a>
    </span>
        <h2>Did You Know?</h2>
    <div id=""trivia"" class=""txt-block"">
        <h4>Trivia</h4>
<a href=""/name/nm0942367/?ref_=tt_trv_trv"">Edgar Wright</a> obtained permission to use the famous theme song from the SNES game, <a href=""/title/tt0263641/?ref_=tt_trv_trv"">Zeruda no densetsu: Kamigami no toraif&ocirc;su</a> (1991), by writing a letter to Nintendo, saying that it is considered to be ""the nursery rhyme of this generation"". He was also allowed to use the <a href=""/title/tt0098904/?ref_=tt_trv_trv"">Seinfeld</a> (1989) theme song for a sitcom-style sequence.        <a href=""trivia?ref_=tt_trv_trv""
class=""nobr"" >See more</a>  &raquo;
    </div>
                <hr />
     <div id=""goofs""  class=""txt-block"">
        <h4>Goofs</h4>
While the band room is at the back of Lee's Palace, when Scott is thrown through the wall, he should have ended up in the parking lot that is actually across the alley.        <a href=""trivia?tab=gf&ref_=tt_trv_gf""
class=""nobr"" >See more</a>  &raquo;
    </div>
                <hr />
    <div id=""quotes"" class=""text-block"">
        <h4>Quotes</h4>
<a href=""/name/nm0148418/?ref_=tt_trv_qu""
><span class=""character"">Scott Pilgrim</span></a>:
Ciao Knives!
<br />        <a href=""trivia?tab=qt&ref_=tt_trv_qu""
class=""nobr"" >See more</a> &raquo;
    </div>
                <hr />
     <div id=""crazyCredits""  class=""txt-block"">
        <h4>Crazy Credits</h4>
As the film ends, ""Continue?"" screen countdown appears, similar to games like Street Fighter 2, which counts down the last few seconds before the credits begin.        <a href=""trivia?tab=cz&ref_=tt_trv_cc""
class=""nobr"" >See more</a>  &raquo;
    </div>
                <hr />
    <div id=""connections"" class=""text-block"">
        <h4>Connections</h4>
        References <a href=""/title/tt0241527/?ref_=tt_trv_cnn"">Harry Potter and the Sorcerer's Stone</a>&nbsp;(2001)
        <a href=""trivia?tab=mc&ref_=tt_trv_cnn""
class=""nobr"" >See more</a> &raquo;
    </div>
                <hr />
    <div id=""soundtracks"" class=""text-block"">
        <h4>Soundtracks</h4>
Slick (Patel's Song)<br />
Written by <a href=""/name/nm1310825/?ref_=tt_trv_snd"">Dan Nakamura</a>, <a href=""/name/nm1854069/?ref_=tt_trv_snd"">Bryan Lee O'Malley</a><br />
Produced by <a href=""/name/nm1310825/?ref_=tt_trv_snd"">Dan Nakamura</a><br />
Performed by <a href=""/name/nm1310825/?ref_=tt_trv_snd"">Dan Nakamura</a> (as Dan the Automator) and <a href=""/name/nm1440863/?ref_=tt_trv_snd"">Satya Bhabha</a><br />        <a href=""soundtrack?ref_=tt_trv_snd""
class=""nobr"" >See more</a> &raquo;
    </div>
    </div>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleDidYouKnowWidget_finished');
    }
  </script>
    </div>
</div>
<div id=""content-1"" class=""redesign clear"">
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleFAQWidget_started');
    }
  </script>
    <div class=""article"" id=""titleFAQ"">
        <h2>Frequently Asked Questions</h2>
            <div class=""faq"" >
                    <div class=""odd"">
                    <b>Q:</b>
<a href=""/title/tt0446029/faq?ref_=tt_faq_1#.2.1.7""
> What is the time span of the movie?</a>
                    </div>
                    <div class=""even"">
                    <b>Q:</b>
<a href=""/title/tt0446029/faq?ref_=tt_faq_2#.2.1.6""
> What song is playing when Scott tries to find Ramona at the party?</a>
                    </div>
                    <div class=""odd"">
                    <b>Q:</b>
<a href=""/title/tt0446029/faq?ref_=tt_faq_3#.2.1.9""
> Where in Toronto does the film take place?</a>
                    </div>
            </div>
            <span class=""see-more inline"" >
                <a href=""/title/tt0446029/faq?ref_=tt_faq_sm""
class=""nobr"" >See more</a>
                <span class=""spoilers"">(Spoiler Alert!)</span></span>&nbsp;&raquo;
    </div>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleFAQWidget_finished');
    }
  </script>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleUserReviewsWidget_started');
    }
  </script>
    <div class=""article"" id=""titleUserReviewsTeaser"">
        <h2>User Reviews</h2>
        <div class=""user-comments"">
                    <div class=""tinystarbar"" title=""10/10"">
                        <div style=""width: 100px;"">&nbsp;</div>
                    </div>
                <span itemprop=""review"" itemscope itemtype=""http://schema.org/Review"">
                    <strong itemprop=""name"">Excellent, Brilliant !!!!!!!  REFRESHING</strong>
                    <span itemprop=""reviewRating"" itemscope itemtype=""http://schema.org/Rating"">
                        <meta itemprop=""worstRating"" content = ""1"" />
                        <meta itemprop=""ratingValue"" content=""10"" />
                        <meta itemprop=""bestRating"" content=""10"" />
                    </span>
                    <div class=""comment-meta"">
                        18 August 2010 | by <a href=""/user/ur6463198/?ref_=tt_urv""
><span itemprop=""author"">guapog</span></a>
                        <meta itemprop=""datePublished"" content=""2010-08-18"" />
                              (United States)
                        &ndash; <a href=""/user/ur6463198/comments?ref_=tt_urv""
>See all my reviews</a>
                    </div>
                    <div>
                        <p itemprop=""reviewBody"">This is truly a brilliant, refreshing movie. I must say that I didn&#x27;t quite know what to expect but except that I thought this movie was for teenagers and I was terribly wrong. <br /><br />I am 40 years old and I TRULY enjoyed this movie and it had a clear story line that targeted more than just teenagers. In addition, I saw every age group, race, gender in the screening that I attended which was impressive and we all were jumping and laughing at every scene as if we were all teenagers. <br /><br />I truly left the movie saying that &#x22; I cant wait to see more films put out by &#x22;Oni Productions/Closed on Mondays &#x22;. Well done !!!!!</p>
                    </div>
                </span>
                <hr />
                <div class=""yn"" id=""ynd_2297523"">
                    211 of 361 people found this review helpful.&nbsp;
                    Was this review helpful to you?
                    <button class=""btn small"" value=""Yes"" name=""ynb_2297523_yes"" onclick=""CS.TMD.user_review_vote(2297523, 'tt0446029', 'yes');"" >Yes</button>
                    <button class=""btn small"" value=""No"" name=""ynb_2297523_no"" onclick=""CS.TMD.user_review_vote(2297523, 'tt0446029', 'no');"" >No</button>
                </div>
            <div class=""see-more"">
                <a href=""/title/tt0446029/reviews-enter?ref_=tt_urv""
rel=""login"">Review this title</a>
                <span>|</span>
                    <a href=""/title/tt0446029/reviews?ref_=tt_urv""
>See all 494 user reviews</a>&nbsp;&raquo;
            </div>
        </div>
    </div>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleUserReviewsWidget_finished');
    }
  </script>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleUserReviewsWidget_finished');
    }
  </script>

    <div class=""article"" id=""boardsTeaser"">
        <h2>Message Boards</h2>
            Recent Posts
            <table class=""boards"">
                    <tr class=""odd"">
                        <td>
                            <a href=""/title/tt0446029/board/nest/230786854?ref_=tt_bd_1""
>I liked it...</a>
                        </td>
                        <td>
                            <a href=""/user/ur50918306/?ref_=tt_bd_1""
>trevbowman720</a>
                        </td>
                    </tr>
                    <tr class=""even"">
                        <td>
                            <a href=""/title/tt0446029/board/nest/227785154?ref_=tt_bd_2""
>I'd take Envy over Ramona anyday.</a>
                        </td>
                        <td>
                            <a href=""/user/ur51552744/?ref_=tt_bd_2""
>maxdee810</a>
                        </td>
                    </tr>
                    <tr class=""odd"">
                        <td>
                            <a href=""/title/tt0446029/board/nest/228299953?ref_=tt_bd_3""
>Not sure which group is funnier.</a>
                        </td>
                        <td>
                            <a href=""/user/ur18648813/?ref_=tt_bd_3""
>Jaycicle</a>
                        </td>
                    </tr>
                    <tr class=""even"">
                        <td>
                            <a href=""/title/tt0446029/board/nest/210775132?ref_=tt_bd_4""
>For some reason I couldn't stand this movie...</a>
                        </td>
                        <td>
                            <a href=""/user/ur18488683/?ref_=tt_bd_4""
>kartoon-1</a>
                        </td>
                    </tr>
                    <tr class=""odd"">
                        <td>
                            <a href=""/title/tt0446029/board/nest/219316618?ref_=tt_bd_5""
>I am deeply sorry ..</a>
                        </td>
                        <td>
                            <a href=""/user/ur11673012/?ref_=tt_bd_5""
>actually_yes</a>
                        </td>
                    </tr>
                    <tr class=""even"">
                        <td>
                            <a href=""/title/tt0446029/board/nest/212463308?ref_=tt_bd_6""
>Scott vs. Roxy : Hollywood is too scared to hit a girl.</a>
                        </td>
                        <td>
                            <a href=""/user/ur8735444/?ref_=tt_bd_6""
>mapzilla</a>
                        </td>
                    </tr>
            </table>
        <div class=""see-more"">
            <a href=""/title/tt0446029/board/?ref_=tt_bd_sm""
>Discuss Scott Pilgrim vs. the World (2010)</a> on the IMDb message boards &raquo;
        </div>
    </div>

  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleContributeWidget_started');
    }
  </script>
    <div class=""article contribute"">
        <div class=""rightcornerlink"">
<a href=""/help/?adding/&ref_=tt_cn_hlp""
>Getting Started</a>
            <span>|</span>
<a href=""/czone/?ref_=tt_cn_cz""
>Contributor Zone</a>&nbsp;&raquo;</div>
        <h2>Contribute to This Page</h2>
            <div class=""button-box"">
                <form method=""post"" action=""/updates?ref_=tt_cn_edt"">
                    <input type=""hidden"" name=""auto"" value=""legacy/title/tt0446029/"">
                        <button class=""btn primary large"" rel=""login"" type=""submit"">Edit page</button>
                </form>
            </div>
        <div class=""button-box"">
<a href=""/title/tt0446029/reviews-enter?ref_=tt_cn_urv""
class=""btn large"" rel=""login"">Write review</a>
        </div>
        <div class=""form-box"">
            <form method=""post"" action=""/character/create?ref_=tt_cn_ch"">
                <input type=""hidden"" value=""tt0446029"" name=""title"">
                <div class=""form-txt"">Create a character page for:</div>
                <select id=""character_select"" name=""name"" data-tconst=""tt0446029"">
                        <option value=""Party Goer"">Party Goer</option>
                        <option value=""Party Goer"">Party Goer</option>
                     <option disabled=""disabled"">-----------</option>
                     <option value=""..."">more...</option>
                </select>
                <button class=""btn small"">Create &raquo;</button>
                <a href=""/help/show_leaf?createchar&ref_=tt_cn_chhlp""
class=""btn small"" >?</a>
            </form>
        </div>
    </div>
  <script>
    if ('csm' in window) {
      csm.measure('csm_TitleContributeWidget_finished');
    }
  </script>
</div>
                   <br class=""clear"" />
                </div>
  <div id=""footer"" class=""ft"">
    <hr width=""100%"" size=1>
    <div id=""rvi-div"">
        <div class=""recently-viewed"">&nbsp;</div>
        <br class=""clear"">
        <hr width=""100%"" size=""1"">
    </div>
    <!-- begin BOTTOM_AD -->
<div id=""bottom_ad_wrapper"" class=""cornerstone_slot"">
<script type=""text/javascript"">
doWithAds(function(){
ad_utils.register_ad('bottom_ad');
});
</script>
<iframe id=""bottom_ad"" name=""bottom_ad"" class=""yesScript"" width=""728"" height=""90"" data-original-width=""728"" data-original-height=""90"" marginwidth=""0"" marginheight=""0"" frameborder=""0"" scrolling=""no"" allowtransparency=""true"" onload=""doWithAds.call(this, function(){ ad_utils.on_ad_load(this); });"" allowfullscreen=""true""></iframe>
</div>
<div id=""bottom_ad_reflow_helper""></div>
<script>
doWithAds(function(){
ad_utils.inject_serverside_ad('bottom_ad', '');
},""unable to inject serverside ad"");
</script>
    <p class=""footer"" align=""center"">
        <a
onclick=""(new Image()).src='/rg/home/footer/images/b.gif?link=/';""
href=""/""
>Home</a>
        | <a
onclick=""(new Image()).src='/rg/search/footer/images/b.gif?link=/search';""
href=""/search""
>Search</a>
        | <a
onclick=""(new Image()).src='/rg/siteindex/footer/images/b.gif?link=/a2z';""
href=""/a2z""
>Site Index</a>
        | <a
onclick=""(new Image()).src='/rg/intheaters/footer/images/b.gif?link=/movies-in-theaters/';""
href=""/movies-in-theaters/""
>In Theaters</a>
        | <a
onclick=""(new Image()).src='/rg/comingsoon/footer/images/b.gif?link=/movies-coming-soon/';""
href=""/movies-coming-soon/""
>Coming Soon</a>
        | <a
onclick=""(new Image()).src='/rg/topmovies/footer/images/b.gif?link=/chart/';""
href=""/chart/""
>Top Movies</a>
        | <a
onclick=""(new Image()).src='/rg/top250/footer/images/b.gif?link=/chart/top';""
href=""/chart/top""
>Top 250</a>
        | <a
onclick=""(new Image()).src='/rg/tv/footer/images/b.gif?link=/sections/tv/';""
href=""/sections/tv/""
>TV</a>
        | <a
onclick=""(new Image()).src='/rg/news/footer/images/b.gif?link=/news/';""
href=""/news/""
>News</a>
        | <a
onclick=""(new Image()).src='/rg/messageboards/footer/images/b.gif?link=/boards/';""
href=""/boards/""
>Message Boards</a>
        | <a
onclick=""(new Image()).src='/rg/pressroom/footer/images/b.gif?link=/pressroom/';""
href=""/pressroom/""
>Press Room</a>
        <br>
        <a
onclick=""(new Image()).src='/rg/register-v2/footer/images/b.gif?link=https://secure.imdb.com/register-imdb/form-v2';""
href=""https://secure.imdb.com/register-imdb/form-v2""
>Register</a>
        | <a
onclick=""(new Image()).src='/rg/advertising/footer/images/b.gif?link=/advertising/';""
href=""/advertising/""
>Advertising</a>
        | <a
onclick=""(new Image()).src='/rg/helpdesk/footer/images/b.gif?link=/helpdesk/contact';""
href=""/helpdesk/contact""
>Contact Us</a>
        | <a
onclick=""(new Image()).src='/rg/jobs/footer/images/b.gif?link=/jobs';""
href=""/jobs""
>Jobs</a>
        | <a href=""http://pro.imdb.com/signup/index.html?rf=cons_ft_hm&ref_=cons_ft_hm""
>IMDbPro</a>
        | <a
onclick=""(new Image()).src='/rg/BOXOFFICEMOJO/FOOTER/images/b.gif?link=http://www.boxofficemojo.com/';""
href=""http://www.boxofficemojo.com/""
>Box Office Mojo</a>
        | <a
onclick=""(new Image()).src='/rg/WITHOUTABOX/FOOTER/images/b.gif?link=http://www.withoutabox.com/';""
href=""http://www.withoutabox.com/""
>Withoutabox</a>
        <br /><br />
        IMDb Mobile:
          <a
onclick=""(new Image()).src='/rg/mobile-ios/footer/images/b.gif?link=/apps/ios/';""
href=""/apps/ios/""
>iPhone/iPad</a>
        | <a
onclick=""(new Image()).src='/rg/mobile-android/footer/images/b.gif?link=/android';""
href=""/android""
>Android</a>
        | <a
onclick=""(new Image()).src='/rg/mobile-web/footer/images/b.gif?link=http://m.imdb.com';""
href=""http://m.imdb.com""
>Mobile site</a>
        | <a
onclick=""(new Image()).src='/rg/mobile-win7/footer/images/b.gif?link=/windowsphone';""
href=""/windowsphone""
>Windows Phone 7</a>
        | IMDb Social:
          <a
onclick=""(new Image()).src='/rg/facebook/footer/images/b.gif?link=http://www.facebook.com/imdb';""
href=""http://www.facebook.com/imdb""
>Facebook</a>
        | <a
onclick=""(new Image()).src='/rg/twitter/footer/images/b.gif?link=http://twitter.com/imdb';""
href=""http://twitter.com/imdb""
>Twitter</a>
       <br /><br />
    </p>
    <p class=""footer"" align=""center"">
        <a
onclick=""(new Image()).src='/rg/help/footer/images/b.gif?link=/help/show_article?conditions';""
href=""/help/show_article?conditions""
>Copyright &copy;</a> 1990-2014
        <a
onclick=""(new Image()).src='/rg/help/footer/images/b.gif?link=/help/';""
href=""/help/""
>IMDb.com, Inc.</a>
        <br>
        <a
onclick=""(new Image()).src='/rg/help/footer/images/b.gif?link=/help/show_article?conditions';""
href=""/help/show_article?conditions""
>Conditions of Use</a> | <a
onclick=""(new Image()).src='/rg/help/footer/images/b.gif?link=/privacy';""
href=""/privacy""
>Privacy Policy</a> | <a
onclick=""(new Image()).src='/rg/help/footer/images/b.gif?link=//www.amazon.com/InterestBasedAds';""
href=""//www.amazon.com/InterestBasedAds""
>Interest-Based Ads</a>
        <br>
        An <span id=""amazon_logo"" class=""footer_logo"" align=""middle""></span> company.
    </p>
  <table class=""footer"" id=""amazon-affiliates"">
    <tr>
      <td colspan=""8"">
        Amazon Affiliates
      </td>
    </tr>
    <tr>
      <td class=""amazon-affiliate-site-first"">
        <a class=""amazon-affiliate-site-link"" href=""http://www.amazon.com/b?ie=UTF8&node=2676882011&tag=imdbpr1-20"">
          <span class=""amazon-affiliate-site-name"">Amazon Instant Video</span><br>
          <span class=""amazon-affiliate-site-desc"">Watch Movies &<br>TV Online</span>
        </a>
      </td>
    <td class=""amazon-affiliate-site-item-nth"">
        <a class=""amazon-affiliate-site-link"" href=http://www.amazon.com/b?ie=UTF8&node=2676882011&tag=imdbpr1-20 >
          <span class=""amazon-affiliate-site-name"">Prime Instant Video</span><br>
          <span class=""amazon-affiliate-site-desc"">Unlimited Streaming<br>of Movies & TV</span>
        </a>
    </td>
    <td class=""amazon-affiliate-site-item-nth"">
        <a class=""amazon-affiliate-site-link"" href=http://www.amazon.de/b?ie=UTF8&node=284266&tag=imdbpr1-de-21 >
          <span class=""amazon-affiliate-site-name"">Amazon Germany</span><br>
          <span class=""amazon-affiliate-site-desc"">Buy Movies on<br>DVD & Blu-ray</span>
        </a>
    </td>
    <td class=""amazon-affiliate-site-item-nth"">
        <a class=""amazon-affiliate-site-link"" href=http://www.amazon.it/b?ie=UTF8&node=412606031&tag=imdbpr1-it-21 >
          <span class=""amazon-affiliate-site-name"">Amazon Italy</span><br>
          <span class=""amazon-affiliate-site-desc"">Buy Movies on<br>DVD & Blu-ray</span>
        </a>
    </td>
    <td class=""amazon-affiliate-site-item-nth"">
        <a class=""amazon-affiliate-site-link"" href=http://www.amazon.fr/b?ie=UTF8&node=405322&tag=imdbpr1-fr-21 >
          <span class=""amazon-affiliate-site-name"">Amazon France</span><br>
          <span class=""amazon-affiliate-site-desc"">Buy Movies on<br>DVD & Blu-ray</span>
        </a>
    </td>
    <td class=""amazon-affiliate-site-item-nth"">
        <a class=""amazon-affiliate-site-link"" href=http://www.amazon.in/movies-tv-shows/b/?ie=UTF&node=976416031&tag=imdbpr1-in-21 >
          <span class=""amazon-affiliate-site-name"">Amazon India</span><br>
          <span class=""amazon-affiliate-site-desc"">Buy Movie and<br>TV Show DVDs</span>
        </a>
    </td>
    <td class=""amazon-affiliate-site-item-nth"">
        <a class=""amazon-affiliate-site-link"" href=http://www.dpreview.com >
          <span class=""amazon-affiliate-site-name"">DPReview</span><br>
          <span class=""amazon-affiliate-site-desc"">Digital<br>Photography</span>
        </a>
    </td>
    <td class=""amazon-affiliate-site-item-nth"">
        <a class=""amazon-affiliate-site-link"" href=http://www.audible.com >
          <span class=""amazon-affiliate-site-name"">Audible</span><br>
          <span class=""amazon-affiliate-site-desc"">Download<br>Audio Books</span>
        </a>
    </td>
    </tr>
  </table>
  </div>
            </div>
        </div>

<script type=""text/javascript"" src=""http://ia.media-imdb.com/images/G/01/imdb/js/collections/title-1048415205._CB345031257_.js""></script>

<script type=""text/imdblogin-js"" id=""login"">
jQuery(document).ready(function(){
    window.imdb.login_lightbox(""https://secure.imdb.com"", ""http://www.imdb.com/title/tt0446029/"");
});
</script>
        <script type=""text/javascript"">
                jQuery(
                             function() {
           var isAdvertisingThemed = !!(window.custom && window.custom.full_page && window.custom.full_page.theme),
               url = ""http://www.facebook.com/widgets/like.php?width=280&show_faces=1&layout=standard&href=http%3A%2F%2Fwww.imdb.com%2Ftitle%2Ftt0446029%2F&colorscheme=light"",
               like = document.getElementById('iframe_like');

           if (!isAdvertisingThemed && like) {
              like.src = url;
              like.onload = function () { generic.monitoring.stop_timing('facebook_like_iframe', '', false); };
           } else if (isAdvertisingThemed) {
              $('.social_networking_like').closest('.aux-content-widget-2').hide();
           }
        }
                );
                jQuery(
                             function() {
            var facebookTheme = (window.custom && window.custom.full_page &&
                    window.custom.full_page.theme) ?
                window.custom.full_page.theme : ""light"",
            url = ""//www.facebook.com/plugins/likebox.php?href=facebook.com%2Fimdb&width=300&height=190&connections=4&header=false&stream=false&colorscheme="" + facebookTheme,
            like = document.getElementById('facebookIframe'),
            twitterIframe = document.getElementById('twitterIframe');
            if (like) {
                like.src = url;
            }
            if (twitterIframe) {
                twitterIframe.src = ""http://i.media-imdb.com/images/social/twitter.html?10#imdb"";
            }
         }
                );
        </script>
<!-- begin ads footer -->
<!-- Begin SIS code -->
<iframe id=""sis_pixel_sitewide"" width=""1"" height=""1"" frameborder=""0"" marginwidth=""0"" marginheight=""0"" style=""display: none;""></iframe>
<script>
    setTimeout(function(){
        try{
            //sis3.0 pixel
            var url_sis3 = 'http://s.amazon-adsystem.com/iu3?',
                params_sis3 = [
                    ""d=imdb.com"",
                    ""a1="",
                    ""a2=01014879a8b82fafcd60c2ff4277fb13fccc627c9a223bf42c6bd42c32060854e2c4"",
                    ""pId=tt0446029"",
                    ""r=1"",
                    ""rP=http%3A%2F%2Fwww.imdb.com%2Ftitle%2Ftt0446029%2F"",
                    ""ex-hargs=v=1.0;c=IMDB;p=tt0446029;t=imdb_title_view;"",
                    ""encoding=server"",
                    ""cb=973136698718""
                ];
            (document.getElementById('sis_pixel_sitewide')).src = url_sis3 + params_sis3.join('&');
        }
        catch(e){
            if ('consoleLog' in window){
                consoleLog('Pixel failure ' + e.toString(),'sis');
            }
            if (window.ueLogError) {
                window.ueLogError(e);
            }
        }
    }, 5);
</script>
<!-- End SIS code -->
<!-- begin comscore beacon -->
<script type=""text/javascript"" src='http://ia.media-imdb.com/images/G/01/imdbads/js/beacon-232398347._CB349580400_.js'></script>
<script type=""text/javascript"">
if(window.COMSCORE){
COMSCORE.beacon({
c1: 2,
c2:""6034961"",
c3:"""",
c4:""http://www.imdb.com/title/tt0446029/"",
c5:"""",
c6:"""",
c15:""""
});
}
</script>
<noscript>
<img src=""http://b.scorecardresearch.com/p?c1=2&c2=6034961&c3=&c4=http%3A%2F%2Fwww.imdb.com%2Ftitle%2Ftt0446029%2F&c5=c6=&15=&cj=1""/>
</noscript>
<!-- end comscore beacon -->
<script>
    doWithAds(function(){
        (new Image()).src = ""http://www.amazon.com/aan/2009-05-01/imdb/default?slot=sitewide-iframe&u=973136698718&ord=973136698718"";
    },""unable to request AAN pixel"");
</script>
<script>
    doWithAds(function(){
           window.jQuery && jQuery(function(){
              generic.document_is_ready()
           });
           generic.monitoring.stop_timing('page_load','',true);
           generic.monitoring.all_events_started();
       }, ""No monitoring or document_is_ready object in generic"");
</script>
<!-- end ads footer -->
<div id=""servertime"" time=""305""/>
<script>
    if (typeof uet == 'function') {
      uet(""be"");
    }
</script>
    </body>
</html>";
        #endregion

        private readonly ImdbMovieSynopsisService _service;
        private readonly IRestApiService _restApiService;

        public ImdbMovieSynopsisServiceTests()
        {
            _restApiService = Substitute.For<IRestApiService>();
            _service = new ImdbMovieSynopsisService(_restApiService);
        }

        [Fact]
        public async Task GetSynopsis_WhenMovieNotFound_ReturnsEmptySynopsis()
        {
            // Act
            MovieSynopsis synopsis = await _service.GetSynopsis(MovieId);

            // Assert
            Assert.True(string.IsNullOrEmpty(synopsis.Outline));
            Assert.True(string.IsNullOrEmpty(synopsis.Plot));
            Assert.True(string.IsNullOrEmpty(synopsis.Tagline));
        }

        [Fact]
        public async Task GetSynopsis_WhenMovieIsFound_ReturnsOutline()
        {
            // Arrange
            _restApiService.Get("title/tt0446029/")
                .Returns(ImdbPageHtml.ToTask());

            // Act
            MovieSynopsis synopsis = await _service.GetSynopsis(MovieId);

            // Assert
            Assert.Equal("Scott Pilgrim must defeat his new girlfriend's seven evil exes in order to win her heart.", synopsis.Outline);
        }

        [Fact]
        public async Task GetSynopsis_WhenMovieIsFound_ReturnsTagline()
        {
            // Arrange
            _restApiService.Get("title/tt0446029/")
                .Returns(ImdbPageHtml.ToTask());

            // Act
            MovieSynopsis synopsis = await _service.GetSynopsis(MovieId);

            // Assert
            Assert.Equal("Get the hot girl. Defeat her evil exes. Hit love where it hurts.", synopsis.Tagline);
        }

        [Fact]
        public async void GetSynopsis_WhenMovieIsFound_ReturnsPlot()
        {
            // Arrange
            _restApiService.Get("title/tt0446029/")
                .Returns(ImdbPageHtml.ToTask());

            // Act
            MovieSynopsis synopsis = await _service.GetSynopsis(MovieId);

            // Assert
            const string expectedPlot = "Scott Pilgrim plays in a band which aspires to success. He dates Knives Chau, a high-school girl five years younger, and he hasn't recovered from being dumped by his former girlfriend, now a success with her own band. When Scott falls for Ramona Flowers, he has trouble breaking up with Knives and tries to romance Ramona. As if juggling two women wasn't enough, Ramona comes with baggage: seven ex-lovers, with each of whom Scott must do battle to the death in order to win Ramona.";
            Assert.Equal(expectedPlot, synopsis.Plot);
        }
    }
}
