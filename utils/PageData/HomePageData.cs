using TrxUITest.src.utils.PageData.Elements;

public class HomePageData : PageData
{
    public TextElement aum = new TextElement("#aum-total");
    public TextElement hhInReview = new TextElement("#hh-in-review");
    public TextElement oob = new TextElement("#vue-route > div > div > div > div > div:nth-child(1) > div > div.mds-card__supplemental-content_trx > table > tbody > tr:nth-child(1) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement cash = new TextElement("#vue-route > div > div > div > div > div:nth-child(1) > div > div.mds-card__supplemental-content_trx > table > tbody > tr:nth-child(2) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement tlh = new TextElement(" #vue-route > div > div > div > div > div:nth-child(1) > div > div.mds-card__supplemental-content_trx > table > tbody > tr:nth-child(3) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement importStatus = new TextElement("#import-status");
    public TextElement processed = new TextElement("#vue-route > div > div > div > div > div:nth-child(2) > div > div.mds-card__caption_trx > h4 > span.highlight.bolder-header");
    public TextElement proposals = new TextElement("#vue-route > div > div > div > div > div:nth-child(2) > div > div.mds-card__caption_trx > h4 > span:nth-child(3)");
    public TextElement reviewed = new TextElement("#vue-route > div > div > div > div > div:nth-child(2) > div > div.mds-card__supplemental-content_trx > table > tbody > tr:nth-child(1) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement holds = new TextElement("#vue-route > div > div > div > div > div:nth-child(2) > div > div.mds-card__supplemental-content_trx > table > tbody > tr:nth-child(2) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement trades = new TextElement("#vue-route > div > div > div > div > div:nth-child(2) > div > div.mds-card__supplemental-content_trx > table > tbody > tr:nth-child(3) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement dismissed = new TextElement("#vue-route > div > div > div > div > div:nth-child(2) > div > div.mds-card__supplemental-content_trx > table > tbody > tr:nth-child(4) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement positions = new TextElement("#vue-route > div > div > div > div > div:nth-child(3) > div > div.mds-card__supplemental-content_trx > table.trx-mds-table.bottom-separator.mds-table_trx > tbody > tr:nth-child(1) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement prices = new TextElement("#vue-route > div > div > div > div > div:nth-child(3) > div > div.mds-card__supplemental-content_trx > table.trx-mds-table.bottom-separator.mds-table_trx > tbody > tr:nth-child(2) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement transactions = new TextElement("#vue-route > div > div > div > div > div:nth-child(3) > div > div.mds-card__supplemental-content_trx > table.trx-mds-table.bottom-separator.mds-table_trx > tbody > tr:nth-child(3) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement realGains = new TextElement("#vue-route > div > div > div > div > div:nth-child(3) > div > div.mds-card__supplemental-content_trx > table.trx-mds-table.bottom-separator.mds-table_trx > tbody > tr:nth-child(4) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement ytdGains = new TextElement("#vue-route > div > div > div > div > div:nth-child(3) > div > div.mds-card__supplemental-content_trx > table.trx-mds-table.bottom-separator.mds-table_trx > tbody > tr:nth-child(5) > td.mds-td_trx.mds-td--right_trx > div");
    public TextElement nonCriticalTRX = new TextElement("#vue-route > div > div > div > div > div:nth-child(3) > div > div.mds-card__supplemental-content_trx > table:nth-child(5) > tbody > tr:nth-child(1) > td:nth-child(2) > div");
    public TextElement nonCriticalPAS = new TextElement("#vue-route > div > div > div > div > div:nth-child(3) > div > div.mds-card__supplemental-content_trx > table:nth-child(5) > tbody > tr:nth-child(1) > td:nth-child(3) > div");
    public TextElement nonCriticalTotal = new TextElement("#vue-route > div > div > div > div > div:nth-child(3) > div > div.mds-card__supplemental-content_trx > table:nth-child(5) > tbody > tr:nth-child(1) > td.mds-td_trx.mds-td--right_trx > div > div");
    public TextElement criticalTRX = new TextElement("#vue-route > div > div > div > div > div:nth-child(3) > div > div.mds-card__supplemental-content_trx > table:nth-child(5) > tbody > tr:nth-child(2) > td:nth-child(2) > div");
    public TextElement criticalPAS = new TextElement("#vue-route > div > div > div > div > div:nth-child(3) > div > div.mds-card__supplemental-content_trx > table:nth-child(5) > tbody > tr:nth-child(2) > td:nth-child(3) > div");
    public TextElement criticalTotal = new TextElement("#vue-route > div > div > div > div > div:nth-child(3) > div > div.mds-card__supplemental-content_trx > table:nth-child(5) > tbody > tr:nth-child(2) > td.mds-td_trx.mds-td--right_trx > div > div");
}