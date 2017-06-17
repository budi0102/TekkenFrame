using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekkenWeb
{
    public class HtmlParser
    {
        /// <summary>
        /// Singleton Instance
        /// </summary>
        public static HtmlParser Instance { get; private set; }

        #region Constructor
        /// <summary>
        /// Static Constructor
        /// </summary>
        static HtmlParser()
        {
            Instance = new HtmlParser();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public HtmlParser()
        {
            HtmlDocument = new HtmlDocument();
        }
        #endregion

        #region Public Properties
        public HtmlDocument HtmlDocument { get; set; }
        #endregion

        #region Public Methods
        public void Load(string htmlString)
        {
            HtmlDocument.LoadHtml(htmlString);
        }
        #endregion
    }
}
