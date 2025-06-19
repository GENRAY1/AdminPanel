export const ClientTag = {
    Vip: 1,
    Investor: 2,
    Active: 3,
    Inactive: 4,
    LowRisk: 5,
    HighRisk: 6,
    Margin: 7,
    Cash: 8
} as const;

export type ClientTagType = typeof ClientTag[keyof typeof ClientTag];


export const isClientTag = (tag: number): tag is ClientTagType => {
    return Object.values(ClientTag).includes(tag as ClientTagType);
};

export const clientTagLocalization: Record<ClientTagType, string> = {
    [ClientTag.Vip]: 'VIP',
    [ClientTag.Investor]: 'Investor',
    [ClientTag.Active]: 'Active',
    [ClientTag.Inactive]: 'Inactive',
    [ClientTag.LowRisk]: 'Low Risk',
    [ClientTag.HighRisk]: 'High Risk',
    [ClientTag.Margin]: 'Margin',
    [ClientTag.Cash]: 'Cash'
};

export const allClientTags = Object.values(ClientTag) as ClientTagType[]