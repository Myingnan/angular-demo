import { Injectable } from '@angular/core';
@Injectable()
export class TalkService {
    private talks = [
        {
            id: 1,
            picUrl: '../../assets/portrait1.PNG',
            date: '2019/8/22 15:10',
            name: 'Magic',
            content: 'may I help you?'
        },
        {
            id: 2,
            picUrl: '../../assets/portrait2.PNG',
            date: '2019-8-22 15:11',
            name: 'Han',
            content: 'We had a damaged shipment from you.'
        },
        {
            id: 1,
            picUrl: '../../assets/portrait1.PNG',
            date: '2019-8-22 15:12',
            name: 'Magic',
            content: 'We will look into it right away for you. Was the damage extensive?'
        },
        {
            id: 2,
            picUrl: '../../assets/portrait2.PNG',
            date: '2019-8-22 15:14',
            name: 'Han',
            content: 'I had say about half of the shipment is unusable.'
        },
        {
            id: 1,
            picUrl: '../../assets/portrait1.PNG',
            date: '2019-8-22 15:16',
            name: 'Magic',
            content: 'We will send a man right out to look at it.'
        },
        {
            id: 2,
            picUrl: '../../assets/portrait2.PNG',
            date: '2019-8-22 15:17',
            name: 'Han',
            content: 'Good, we will be expecting him.'
        },
        {
            id: 1,
            picUrl: '../../assets/portrait1.PNG',
            date: '2019-8-22 15:19',
            name: 'Magic',
            content: 'How bad was the damage?'
        },
        {
            id: 2,
            picUrl: '../../assets/portrait2.PNG',
            date: '2019-8-22 15:21',
            name: 'Han',
            content: 'One packing case was crushed.'
        }
    ];
    constructor() {

    }
    getAll(): any {
        return this.talks;
    }
}