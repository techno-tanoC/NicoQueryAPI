﻿/*
検索クエリ例
コンテンツ検索API

-----------------------------------

動画コンテンツ検索

{
  "query":"初音ミク",
  "service":[
    "video"
  ],
  "search":[
    "title",
    "description",
    "tags"
  ],
  "join":[
    "cmsid",
    "title",
    "description",
    "thumbnail_url",
    "start_time",
    "view_counter",
    "comment_counter",
    "mylist_counter",
    "channel_id",
    "main_community_id",
    "length_seconds"
  ],
  "filters":[
    {
      "type":"equal",
      "field":"ss_adult",
      "value":false
    },
    {
      "type":"range",
      "field":"start_time",
      "from":"2013-03-12 13:26:11"
    },
    {
      "type":"range",
      "field":"length_seconds",
      "from":1200,
      "include_lower":true
    },
    {
      "type":"equal",
      "field":"music_download",
      "value":true
    },
    {
      "type":"equal",
      "field":"is_free",
      "value":true
    }
  ],
  "sort_by":"view_counter",
  "order":"desc",
  "from":0,
  "size":10,
  "issuer":"apiguide",
  "reason":"ma9"
}
-----------------------------------

生放送コンテンツ検索

{
  "query":"初音ミク",
  "service":[
    "live"
  ],
  "search":[
    "title",
    "description",
    "tags"
  ],
  "join":[
    "cmsid",
    "title",
    "description",
    "community_id",
    "community_icon",
    "open_time",
    "start_time",
    "end_time",
    "view_counter",
    "comment_counter",
    "score_timeshift_reserved",
    "provider_type",
    "channel_id",
    "live_status",
    "member_only"
  ],
  "filters":[
    {
      "type":"equal",
      "field":"ss_adult",
      "value":false
    },
    {
      "type":"equal",
      "field":"live_status",
      "value":"past"
    },
    {
      "type":"equal",
      "field":"provider_type",
      "value":"official"
    },
    {
      "type":"range",
      "field":"start_time",
      "from":"2013-03-13 10:20:14",
      "include_lower":true
    },
    {
      "type":"equal",
      "field":"is_free",
      "value":true
    }
  ],
  "sort_by":"_popular",
  "order":"desc",
  "from":0,
  "size":10,
  "issuer":"apiguide",
  "reason":"ma9"
}
-----------------------------------

イラストコンテンツ検索

{
  "query":"初音ミク",
  "service":[
    "illust"
  ],
  "search":[
    "title",
    "description",
    "tags"
  ],
  "join":[
    "cmsid",
    "title",
    "description",
    "thumbnail_url",
    "start_time",
    "view_counter",
    "comment_counter",
    "mylist_counter"
  ],
  "filters":[
    {
      "type":"equal",
      "field":"ss_adult",
      "value":false
    },
    {
      "type":"equal",
      "field":"illust_type",
      "value":0
    }
  ],
  "sort_by":"last_comment_time",
  "order":"desc",
  "from":0,
  "size":10,
  "issuer":"apiguide",
  "reason":"ma9"
}
-----------------------------------

マンガコンテンツ検索

{
  "query":"初音ミク",
  "service":[
    "manga"
  ],
  "search":[
    "title",
    "description",
    "tags"
  ],
  "join":[
    "cmsid",
    "title",
    "description",
    "icon_url",
    "start_time",
    "update_time",
    "view_counter",
    "comment_counter",
    "mylist_counter",
    "category_tags",
    "is_official",
    "serial_status",
    "channel_id",
    "episode_count"
  ],
  "filters":[
    {
      "type":"range",
      "field":"episode_count",
      "from":"0",
      "include_lower":false
    },
    {
      "type":"equal",
      "field":"ss_adult",
      "value":false
    },
    {
      "type":"equal",
      "field":"category_tags",
      "value":"少年マンガ"
    }
  ],
  "sort_by":"last_comment_time",
  "order":"desc",
  "from":0,
  "size":10,
  "issuer":"apiguide",
  "reason":"ma9"
}
-----------------------------------

書籍コンテンツ検索

{
  "query":"初音ミク",
  "service":[
    "book"
  ],
  "search":[
    "title",
    "description",
    "tags"
  ],
  "join":[
    "cmsid",
    "title",
    "description",
    "thumbnail_url",
    "start_time",
    "update_time",
    "view_counter",
    "comment_counter",
    "mylist_counter",
    "tags",
    "is_official",
    "channel_id",
    "genre",
    "author",
    "publisher",
    "label",
    "is_free",
    "price",
    "series_id",
    "series_number",
    "series"
  ],
  "filters":[
    {
      "type":"equal",
      "field":"ss_adult",
      "value":false
    },
    {
      "type":"equal",
      "field":"genre",
      "value":"少年コミック"
    },
    {
      "type":"equal",
      "field":"is_free",
      "value":true
    }
  ],
  "sort_by":"last_comment_time",
  "order":"desc",
  "from":0,
  "size":10,
  "issuer":"apiguide",
  "reason":"ma9"
}
-----------------------------------

チャンネルコンテンツ検索

{
  "query":"初音ミク",
  "service":[
    "channel"
  ],
  "search":[
    "title",
    "description",
    "tags"
  ],
  "join":[
    "cmsid",
    "title",
    "description",
    "thumbnail_url",
    "start_time",
    "type",
    "company_viewname"
  ],
  "filters":[
    {
      "type":"equal",
      "field":"ss_adult",
      "value":false
    },
    {
      "type":"equal",
      "field":"type",
      "value":"normal"
    }
  ],
  "sort_by":"start_time",
  "order":"desc",
  "from":0,
  "size":10,
  "issuer":"apiguide",
  "reason":"ma9"
}
-----------------------------------

ブロマガ記事コンテンツ検索

{
  "query":"初音ミク",
  "service":[
    "channelarticle"
  ],
  "search":[
    "title",
    "description"
  ],
  "join":[
    "cmsid",
    "title",
    "description",
    "thumbnail_url",
    "channel_id",
    "start_time",
    "charticle_ppv_type",
    "view_counter",
    "comment_counter",
    "mylist_counter",
    "is_sample",
    "is_member_only"
  ],
  "filters":[
    {
      "type":"equal",
      "field":"ss_adult",
      "value":false
    },
    {
      "type":"range",
      "field":"start_time",
      "from":"2010-07-16 16:16:31",
      "include_lower":true
    },
    {
      "type":"equal",
      "field":"charticle_ppv_type",
      "value":"free"
    }
  ],
  "sort_by":"start_time",
  "order":"desc",
  "from":0,
  "size":10,
  "issuer":"apiguide",
  "reason":"ma9"
}
*/