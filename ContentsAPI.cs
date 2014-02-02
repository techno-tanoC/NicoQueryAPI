using System;
using System.Collections.Generic;
using System.Linq;

namespace NicoQueryAPI
{
    public class CommonQuery
    {
        public string query_string { get; set; }
        public Service service { get; set; }
        public Search search { get; set; }

        public QueryParams join { get; set; }

        public SortBy sort_by { get; set; }

        //filter list
        public List<Filter> filters { get; set; }

        public Order order { get; set; }
        public int from { get; set; }
        public int size;
        public int Size
        {
            get { return size; }
            set
            {
                if (0 > value || value > 100)
                    throw new IndexOutOfRangeException("\"size\" is from 0 to 100.");
                else
                    this.size = value;
            }
        }
        public const string issure = "NicoQueryAPI.NET(Devloping)";
        public const string reason = "ma9";

        public CommonQuery(string query_string, Service service, Search search, QueryParams join, List<Filter> filter)
        {
            this.query_string = query_string;
            this.service = service;
            this.search = search;
            this.join = join;
            sort_by = SortBy._popular;
            this.filters = filter;
            order = Order.desc;
            from = 0;
            size = 10;
        }

        public string ToJSON()
        {
            return "{" +
                "\"query\":" + query_string +
                "\"service\":[" + service + "]" +
                search +
                join +
                sort_by +
                string.Join(", ", filters.Select(f => f.ToString())) + "," +
                "\"issuer\":\"apiguide\"," +
                "\"reason\":\"ma9\"" +
                "}";
        }
    }

    public enum Service
    {
        video = 1,
        live = 1 << 1,
        illust = 1 << 2,
        manga = 1 << 3,
        book = 1 << 4,
        channel = 1 << 5,
        channelarticle = 1 << 6
    }

    [Flags]
    public enum Search
    {
        title = 1,
        description = 1 << 1,
        tags = 1 << 2
    }

    /*
    #region Join

    [Flags]
    public enum VideoJoin
    {
        cmsid = 1,
        title = 1 << 1,
        description = 1 << 2,
        thumbnail_url = 1 << 3,
        start_time = 1 << 4,
        view_counter = 1 << 5,
        comment_counter = 1 << 6,
        mylist_counter = 1 << 7,
        channel_id = 1 << 8,
        main_community_id = 1 << 9,
        length_seconds = 1 << 10,
        music_download = 1 << 11,
    }
    [Flags]
    public enum LiveJoin
    {
        cmsid = 1,
        title = 1 << 1,
        description = 1 << 2,
        community_id = 1 << 3,
        community_icon = 1 << 4,
        open_time = 1 << 5,
        start_time = 1 << 6,
        end_time = 1 << 7,
        view_counter = 1 << 8,
        comment_counter = 1 << 9,
        score_timeshift_reserved = 1 << 10,
        provider_type = 1 << 11,
        channel_id = 1 << 12,
        live_status = 1 << 13,
        member_only = 1 << 14
    }
    [Flags]
    public enum IllustJoin
    {
        cmsid = 1,
        title = 1 << 1,
        description = 1 << 2,
        thumbnail_url = 1 << 3,
        start_time = 1 << 4,
        view_counter = 1 << 5,
        comment_counter = 1 << 6,
        mylist_counter = 1 << 7
    }
    [Flags]
    public enum MangaJoin
    {
        cmsid = 1,
        title = 1 << 1,
        description = 1 << 2,
        icon_url = 1 << 3,
        start_time = 1 << 4,
        update_time = 1 << 5,
        view_counter = 1 << 6,
        comment_counter = 1 << 7,
        mylist_counter = 1 << 8,
        category_tags = 1 << 9,
        is_official = 1 << 10,
        serial_status = 1 << 11,
        channel_id = 1 << 12,
        episode_count = 1 << 13
    }
    [Flags]
    public enum BookJoin
    {
        cmsid = 1,
        title = 1 << 1,
        description = 1 << 2,
        thumbnail_url = 1 << 3,
        start_time = 1 << 4,
        update_time = 1 << 5,
        view_counter = 1 << 6,
        comment_counter = 1 << 7,
        mylist_counter = 1 << 8,
        tags = 1 << 9,
        is_official = 1 << 10,
        channel_id = 1 << 11,
        genre = 1 << 12,
        author = 1 << 13,
        publisher = 1 << 14,
        label = 1 << 15,
        is_free = 1 << 16,
        price = 1 << 17,
        series_id = 1 << 18,
        series_number = 1 << 19,
        series = 1 << 20
    }
    [Flags]
    public enum ChannelJoin
    {
        cmsid = 1,
        title = 1 << 1,
        description = 1 << 2,
        thumbnail_url = 1 << 3,
        start_time = 1 << 4,
        type = 1 << 5,
        company_viewname = 1 << 6
    }
    [Flags]
    public enum ChannelarticleJoin
    {
        cmsid = 1,
        title = 1 << 1,
        description = 1 << 2,
        thumbnail_url = 1 << 3,
        channel_id = 1 << 4,
        start_time = 1 << 5,
        charticle_ppv_type = 1 << 6,
        view_counter = 1 << 7,
        comment_counter = 1 << 8,
        mylist_counter = 1 << 9,
        is_sample = 1 << 10,
        is_member_only = 1 << 11
    }
    
    #endregion

    */

    public sealed class QueryParams
    {
        private string field;
        public readonly int canFilter;

        private QueryParams(string field)
        {
            this.field = field;
        }
        private QueryParams(string field, int canFilter)
        {
            this.field = field;
            this.canFilter = canFilter;
        }

        public override string ToString()
        {
            return field;
        }

        public static QueryParams operator |(QueryParams enum1, QueryParams enum2)
        {
            return new QueryParams(enum1.ToString() + ", " + enum2.ToString(), -1);
        }

        #region Enums

        public static class CommonEnum
        {
            public static readonly QueryParams cmsid = new QueryParams("cmsid");
            public static readonly QueryParams title = new QueryParams("title");
            public static readonly QueryParams description = new QueryParams("description");

            public static readonly QueryParams start_time = new QueryParams("start_time");

            public static readonly QueryParams ss_adult_ef = new QueryParams("ss_adult");
        }

        public static class VideoEnum
        {
            public static readonly QueryParams thumbnail_url_j = new QueryParams("thumbnail_url");
            public static readonly QueryParams view_counter = new QueryParams("view_counter");
            public static readonly QueryParams comment_counter_j = new QueryParams("comment_counter");
            public static readonly QueryParams mylist_counter_j = new QueryParams("mylist_counter");
            public static readonly QueryParams channel_id_j = new QueryParams("channel_id");
            public static readonly QueryParams main_community_id_j = new QueryParams("main_community_id");
            public static readonly QueryParams length_seconds_j = new QueryParams("length_seconds");
            public static readonly QueryParams music_download_ef = new QueryParams("music_download");

            public static readonly QueryParams is_free_ef = new QueryParams("is_free");
        }

        public static class LiveEnum
        {
            public static readonly QueryParams community_id = new QueryParams("community_id");
            public static readonly QueryParams community_icon = new QueryParams("community_icon");
            public static readonly QueryParams open_time = new QueryParams("open_time");
            public static readonly QueryParams end_time = new QueryParams("end_time");
            public static readonly QueryParams view_counter = new QueryParams("view_counter");
            public static readonly QueryParams comment_counter = new QueryParams("comment_counter");
            public static readonly QueryParams score_timeshift_reserved = new QueryParams("score_timeshift_reserved");
            public static readonly QueryParams providor_type = new QueryParams("provider_type");
            public static readonly QueryParams channel_id = new QueryParams("channel_id");
            public static readonly QueryParams live_status = new QueryParams("live_status");
            public static readonly QueryParams member_only = new QueryParams("member_only");

            public static readonly QueryParams is_free = new QueryParams("is_free");
        }

        public static class IllustEnum
        {
            public static readonly QueryParams thumbnail_url = new QueryParams("thumbnail_url");
            public static readonly QueryParams view_counter = new QueryParams("view_counter");
            public static readonly QueryParams comment_counter = new QueryParams("comment_counter");
            public static readonly QueryParams mylist_counter = new QueryParams("mylist_counter");
            public static readonly QueryParams last_comment_time = new QueryParams("last_comment_time");
            public static readonly QueryParams illust_type = new QueryParams("illust_type");
        }

        public static class MangaEnum
        {
            public static readonly QueryParams icon_url = new QueryParams("icon_url");
            public static readonly QueryParams update_time = new QueryParams("update_time");
            public static readonly QueryParams view_counter = new QueryParams("view_counter");
            public static readonly QueryParams comment_counter = new QueryParams("comment_counter");
            public static readonly QueryParams mylist_counter = new QueryParams("mylist_counter");
            public static readonly QueryParams category_tags = new QueryParams("category_tags");
            public static readonly QueryParams is_official = new QueryParams("is_official");
            public static readonly QueryParams serial_status = new QueryParams("serial_status");
            public static readonly QueryParams channel_id = new QueryParams("channel_id");
            public static readonly QueryParams episode_count = new QueryParams("episode_count");

            public static readonly QueryParams last_comment_time = new QueryParams("last_comment_time");
        }

        public static class BookEnum
        {
            public static readonly QueryParams thumbnail_url = new QueryParams("thumbnail_url");
            public static readonly QueryParams update_time = new QueryParams("update_time");
            public static readonly QueryParams view_counter = new QueryParams("view_counter");
            public static readonly QueryParams comment_counter = new QueryParams("comment_counter");
            public static readonly QueryParams mylist_counter = new QueryParams("mylist_counter");
            public static readonly QueryParams tags = new QueryParams("tags");
            public static readonly QueryParams is_official = new QueryParams("is_official");
            public static readonly QueryParams channel_id = new QueryParams("channel_id");
            public static readonly QueryParams genre = new QueryParams("genre");
            public static readonly QueryParams author = new QueryParams("author");
            public static readonly QueryParams publisher = new QueryParams("publisher");
            public static readonly QueryParams label = new QueryParams("label");
            public static readonly QueryParams is_free = new QueryParams("is_free");
            public static readonly QueryParams price = new QueryParams("price");
            public static readonly QueryParams series_id = new QueryParams("series_id");
            public static readonly QueryParams series_number = new QueryParams("series_number");
            public static readonly QueryParams series = new QueryParams("series");

            public static readonly QueryParams last_comment_time = new QueryParams("last_comment_time");
        }

        public static class ChannelEnum
        {
            public static readonly QueryParams thumbnail_url = new QueryParams("thumbnail_url");
            /// <summary>
            /// value = "normal"
            /// </summary>
            public static readonly QueryParams type = new QueryParams("type");
            public static readonly QueryParams company_viewname = new QueryParams("company_viewname");
        }

        public static class ChannelarticleEnum
        {
            public static readonly QueryParams thumbnail_url = new QueryParams("thumbnail_url");
            public static readonly QueryParams channel_id = new QueryParams("channel_id");
            
            /// <summary>
            /// value = "free"
            /// </summary>
            public static readonly QueryParams charticle_ppv_type = new QueryParams("charticle_ppv_type");
            public static readonly QueryParams view_counter = new QueryParams("view_counter");
            public static readonly QueryParams comment_counter = new QueryParams("comment_counter");
            public static readonly QueryParams mylist_counter = new QueryParams("mylist_counter");
            public static readonly QueryParams is_sample = new QueryParams("is_sample");
            public static readonly QueryParams is_member_only = new QueryParams("is_member_only");
        }

        #endregion

    }

    public class Filter
    {
        public QueryParams field;
        protected Filter(QueryParams field)
        {
            if (field.canFilter == -1)
                throw new Exception("Complex Field:" + field.ToString());
            else
                this.field = field;
        }
        public new virtual string ToString()
        {
            return "";
        }
    }
    public class EqualFilter : Filter
    {
        public string value;
        public EqualFilter(QueryParams e, bool value)
            : base(e)
        {
            this.value = value ? "true" : "false";
        }
        public EqualFilter(QueryParams e, int value)
            : base(e)
        {
            this.value = value.ToString();
        }
        public EqualFilter(QueryParams e, string value)
            : base(e)
        {
            this.value = "\"" + value + "\"";
        }
        public override string ToString()
        {
            return "{" +
                "\"type\":\"equal\"" +
                ",\"field\":\"" + field.ToString() + "\"" +
                ",\"value\":" + value +
                "}";
        }
    }
    public class RangeFilter : Filter
    {
        public string from;
        public string to;
        public bool include_upper;//開始指定を含むか否か(省略時含む)
        public bool include_lower;//終端指定を含むか否か(省略時含む)

        public RangeFilter(QueryParams e, int from = -1, int to = -1, bool include_upper = true, bool include_lower = true)
            : base(e)
        {
            this.from = from == -1 ? null : from.ToString();
            this.to = to == -1 ? null : to.ToString();
            this.include_upper = include_upper;
            this.include_lower = include_lower;
        }
        public RangeFilter(QueryParams e, string from = "", string to = "", bool include_upper = true, bool include_lower = true)
            : base(e)
        {
            this.from = from == null || from == "" ? null : "\"" + from + "\"";
            this.to = to == null || to == "" ? null : "\"" + to + "\"";
            this.include_upper = include_upper;
            this.include_lower = include_lower;
        }
        public override string ToString()
        {
            return "{" +
                "\"type\":\"range\"" +
                ",\"field\":\"" + field.ToString() + "\"" +
                (from != null ? ",\"from\":" + from : "") +
                (to != null ? ",\"to\":" + to : "") +
                (include_upper ? "" : ",\"include_upper\":false") +
                (include_lower ? "" : ",\"include_lower\":false") +
                "}";

        }
    }

    public enum Order
    {
        desc,
        asc,
    }

        public enum SortBy
    {
        _popular,
        _explore,
        _live_recent,
    }
}
