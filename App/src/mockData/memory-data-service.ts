import { InMemoryDbService } from "angular-in-memory-web-api";
import { Observable } from "rxjs";
import { Talks } from "src/entity/talks";
import { Inspector } from "src/entity/inspector";
import { OverviewPageData } from 'src/entity/overviewPageData';
import { CapturePageData } from 'src/entity/capturePageData';
import { TagsPageData } from 'src/entity/tagsPageData';
import { Person } from "src/entity/person";

export class InMemoryAppDbService implements InMemoryDbService {
    createDb(): {} | Observable<{}> | Promise<{}> {
        let talks: Talks[] = [
            {
                id: "1",
                picUrl: "../../assets/talk/portrait1.PNG",
                date: "2019/8/22 15:10",
                name: "Magic",
                content: "may I help you?"
            },
            {
                id: "2",
                picUrl: "../../assets/talk/portrait2.PNG",
                date: "2019/8/22 15:11",
                name: "Han",
                content: "We had a damaged shipment from you."
            },
            {
                id: "1",
                picUrl: "../../assets/talk/portrait1.PNG",
                date: "2019/8/22 15:12",
                name: "Magic",
                content: "We will look into it right away for you. Was the damage extensive?"
            },
            {
                id: "2",
                picUrl: "../../assets/talk/portrait2.PNG",
                date: "2019/8/22 15:14",
                name: "Han",
                content: "I had say about half of the shipment is unusable."
            },
            {
                id: "1",
                picUrl: "../../assets/talk/portrait1.PNG",
                date: "2019/8/22 15:16",
                name: "Magic",
                content: "We will send a man right out to look at it."
            },
            {
                id: "2",
                picUrl: "../../assets/talk/portrait2.PNG",
                date: "2019-8-22 15:17",
                name: "Han",
                content: "Good, we will be expecting him."
            },
            {
                id: "1",
                picUrl: "../../assets/talk/portrait1.PNG",
                date: "2019-8-22 15:19",
                name: "Magic",
                content: "How bad was the damage?"
            },
            {
                id: "2",
                picUrl: "../../assets/talk/portrait2.PNG",
                date: "2019-8-22 15:21",
                name: "Han",
                content: "One packing case was crushed."
            }
        ];

        let inspector: Inspector[] = [
            {
                picUrl: "../../assets/safetyinspector/1.PNG",
                date: "2019/8/22 15:10",
                aftitle: "AI Evaluator",
                afcontent: "a cup of coffee on a table",
                attitle: "AI Tags",
                atcontent: "table: coffee: cup",
                detected: undefined
            },
            {
                picUrl: "../../assets/safetyinspector/2.PNG",
                date: "2019/8/22 15:10",
                aftitle: "AI Evaluator",
                afcontent: "a desk with a laptop computer sitting on top of a table",
                attitle: "AI Tags",
                atcontent: "table: desk: laptop: computer",
                detected: "laptop"
            },
            {
                picUrl: "../../assets/safetyinspector/3.PNG",
                date: "2019/8/22 15:10",
                aftitle: "AI Evaluator",
                afcontent: "a desk with a computer in an office",
                attitle: "AI Tags",
                atcontent: "desk: computer: office",
                detected: undefined
            },
            {
                picUrl: "../../assets/safetyinspector/4.PNG",
                date: "2019/8/22 15:10",
                aftitle: "AI Evaluator",
                afcontent: "a person swinging g golf club",
                attitle: "AI Tags",
                atcontent: "person: golf: club",
                detected: undefined
            },
            {
                picUrl: "../../assets/safetyinspector/5.PNG",
                date: "2019/8/22 15:10",
                aftitle: "AI Evaluator",
                afcontent: "a person hulding a football ball",
                attitle: "AI Tags",
                atcontent: "person: football: ball",
                detected: undefined
            },
            {
                picUrl: "../../assets/safetyinspector/7.PNG",
                date: "2019/8/22 15:10",
                aftitle: "AI Evaluator",
                afcontent: "a person using a phone",
                attitle: "AI Tags",
                atcontent: "person: phone",
                detected: undefined
            },
            {
                picUrl: "../../assets/safetyinspector/6.PNG",
                date: "2019/8/22 15:10",
                aftitle: "AI Evaluator",
                afcontent: "a person driving a car",
                attitle: "AI Tags",
                atcontent: "person: car",
                detected: undefined
            },
            {
                picUrl: "../../assets/safetyinspector/8.PNG",
                date: "2019/8/22 15:10",
                aftitle: "AI Evaluator",
                afcontent: "a tree with many apple",
                attitle: "AI Tags",
                atcontent: "tree: apple",
                detected: undefined
            }
        ];

        let overviewPageData: OverviewPageData[] = [
            {
                date: "2019/8/22 15:10",
                pic: "../../assets/overview/1.PNG",
                title1: "AI Evaluator :",
                content1: "1 Tip For Gaining Mass Fast",
                title2: "AI Tags :",
                content2: "a person swinging g club Chat bot",
            },
            {
                date: "2019/8/22 15:10",
                pic: "../../assets/overview/2.PNG",
                title1: "AI Evaluator :",
                content1: "2 Tips For Gaining Mass Fast",
                title2: "AI Tags :",
                content2: "a person swinging g club Chat bot",
            },
            {
                date: "2019/8/22 15:10",
                pic: "../../assets/overview/3.PNG",
                title1: "AI Evaluator :",
                content1: "3 Tips For Gaining Mass Fast",
                title2: "AI Tags :",
                content2: "a person swinging g club Chat bot",
            },
            {
                date: "2019/8/22 15:10",
                pic: "../../assets/overview/4.PNG",
                title1: "AI Evaluator :",
                content1: "4 Tips For Gaining Mass Fast",
                title2: "AI Tags :",
                content2: "a person swinging g club Chat bot",
            },
            {
                date: "2019/8/22 15:10",
                pic: "../../assets/overview/5.PNG",
                title1: "AI Evaluator :",
                content1: "5 Tips For Gaining Mass Fast",
                title2: "AI Tags :",
                content2: "a person swinging g club Chat bot",
            },
            {
                date: "2019/8/22 15:10",
                pic: "../../assets/overview/6.PNG",
                title1: "AI Evaluator :",
                content1: "6 Tips For Gaining Mass Fast",
                title2: "AI Tags :",
                content2: "a person swinging g club Chat bot",
            },
        ];

        let capturePageData: CapturePageData[] = [
            {
                picUrl: "/assets/racket1.PNG",
            },
            {
                picUrl: "/assets/racket2.PNG",
            },
            {
                picUrl: "/assets/racket3.PNG",
            },
            {
                picUrl: "/assets/racket4.PNG",
            },
        ];

        let tagsPageData: TagsPageData[] = [
            {
                val: "cup", isChecked: false
            },
            {
                val: "laptop", isChecked: false
            },
            {
                val: "office", isChecked: false
            },
            {
                val: "person", isChecked: true
            },
            {
                val: "ball", isChecked: false
            },
            {
                val: "phone", isChecked: false
            },
            {
                val: "car", isChecked: false
            },
            {
                val: "tree", isChecked: false
            },
        ];

        let person: Person[] = [
            {
                id: "1142210",
                date: "2019/8/22 15:10",
                name: "Cong Ma",
                content: "Falling in love with yourself first doesn’t make you vain or selfish, it makes you indestructible. "
            }
        ];

        return { talks, inspector, overviewPageData, capturePageData, tagsPageData, person };
    }
}
