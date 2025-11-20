export interface Log {
    list: number[];
    msg: string;
    extras?: {
        highlight?: number[];
        alertHighlight?: number[]; // For swaps or anything that deviates from normal.
        depth?: number;
        toVisitHighlight?: number[];
        visitedHighlight?: number[];
    }
}

export interface SearchRequest {
    list: number[];
    target: number;
}

export interface PathfindingRequest {
    graph: Record<number, number[]>;
    startNode: number;
    targetNode?: number;
}