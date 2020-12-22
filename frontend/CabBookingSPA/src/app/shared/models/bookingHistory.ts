export interface BookingHistory {

    id: number;
    email: string;
    fromPlaceId: number;
    toPlaceId: number;
    pickupAddress: string;
    cabTypeId: number;
    contactNo: string;
    charge: number;
    feedback: string;
  }