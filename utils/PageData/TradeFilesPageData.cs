using System;
using TrxUITest.src.utils.PageData.Elements;

public class TradeFilesPageData : PageData
{
    public TextElement title = new TextElement("#trade-prop-tradefiles-modal-header");
    public ComplexGridElement tradeFilesDownloadGrid = new ComplexGridElement("#trade-files-grid > div > div.tg-pane-bodyer", new Type[] { typeof(CsvElement), typeof(CurrentTimestampElement), typeof(TextElement), null });
}