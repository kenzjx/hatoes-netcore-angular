export interface IReport {
  reportId: number;
  projectId: number;
  positionId: number;
  time: number;
  day: string;
  type: number;
  note: string;
  status: number;
}

export interface Project {
  projectId: number;
  projectName: string;
}

export interface Position {
  positionId: number;
  positionName: string;
}
