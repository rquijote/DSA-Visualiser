export interface Log {
    list: number[];
    msg: string;
    extras?: {
        highlight?: number[];
        depth?: number;
    }
}

export interface SearchRequest {
    list: number[];
    target: number;
}

/* 
 public int[] Numbers { get; set; }
        public int Target { get; set; }
*/