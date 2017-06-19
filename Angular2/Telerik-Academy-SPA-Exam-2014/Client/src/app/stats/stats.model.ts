export interface IStatsModel {
    trips: number;
    finishedTrips: number;
    users: number;
    drivers: number;
};

export const statsInitialModel: IStatsModel = {
    users: 0,
    drivers: 0,
    finishedTrips: 0,
    trips: 0
};