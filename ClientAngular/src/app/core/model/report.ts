export interface IReport {
  isSelected: boolean;
  id: number;
  projectId: number;
  projectName : string;
  positionId: number;
  positionName: string;
  time: number;
  date: string;
  type: string;
  note: string;
  status: string;
  isEdit: boolean;

}

export interface Project {
  projectId: number;
  projectName: string;
}

export interface Position {
  positionId: number;
  positionName: string;
}

export const ReportColumns = [
  {
    key: 'isSelected',
    type: 'isSelected',
    label: '',
  },
  {
    key: 'projectName',
    type: 'text',
    label: 'Project',
    required: true,
  },
  {
    key: 'positionName',
    type: 'text',
    label: 'Position',
  },
  {
    key: 'time',
    type: 'string',
    label: 'Time',
  },
  {
    key: 'date',
    type: 'date',
    label: 'Day',
  },
  {
    key: 'type',
    type: 'text',
    label: 'Type',
  },
  {
    key: 'note',
    type: 'text',
    label: 'Note',
  },
  {
    key: 'status',
    type: 'text',
    label: 'Status',
  },
  {
    key: 'isEdit',
    type: 'isEdit',
    label: 'Action',
  },
];
