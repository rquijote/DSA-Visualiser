export interface Log {
    list: number[];
    msg: string;
    extras?: {
        highlight?: number[];
        depth?: number;
    }
}