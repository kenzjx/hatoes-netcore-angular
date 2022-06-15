export interface IReport {
  id: number;
  projectId: number;
  projectName : string;
  time: number;
  day: Date;
  type: string;
  note: string;
  status: string;
  positions: Position
}

export interface Project {
  projectId: number;
  projectName: string;
}

export interface Position {
  positionId: number;
  positionName: string;
}
