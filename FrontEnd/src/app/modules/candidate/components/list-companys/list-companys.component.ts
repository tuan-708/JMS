import { Component } from '@angular/core';

@Component({
    selector: 'app-list-companys',
    templateUrl: './list-companys.component.html',
    styleUrls: ['./list-companys.component.css']
})
export class CandidateListCompanysComponent {
    inputValue: string = ''; // Variable to hold input value

    // onInputChange(event: Event): void {
    //     const inputValue = (event.target as HTMLInputElement).value.toLowerCase();
    //     console.log('Input changed:', inputValue);




    //     // Perform actions with the new input value
    //   }

    onInputChange(event: any): void {
        const words = ["suppose end get", "boy warrant general", "natural. delightful", "met sufficient projection ask.", "decisively everything", "principles if preference", "do", "impression", "of. preserved oh so", "difficult repulsive on", "in household. in what", "do", "miss time be. valley", "as be", "appear", "cannot so", "by.", "convinced resembled dependent", "remainder led zealously", "his shy own", "belonging. always length", "letter", "adieus", "add number moment she.", "promise few", "compass six several old", "offices removal parties", "fat. concluded", "rapturous it intention", "perfectly daughters", "is as.", "behaviour we", "improving at something", "to. evil true", "high lady roof men", "had open.", "to projection considered it", "precaution an", "melancholy or.", "wound young", "you thing", "worse along being ham.", "dissimilar of favourable solicitude", "if sympathize middletons", "at. forfeited", "up if disposing", "perfectly in an", "eagerness perceived necessary.", "belonging sir", "curiosity discovery", "extremity yet", "forfeited prevailed", "own off.", "travelling by", "introduced of", "mr terminated. knew as", "miss", "my high hope quit. in", "curiosity shameless dependent", "knowledge up.", "literature admiration", "frequently indulgence announcing", "are who you", "her. was", "least quick after", "six. so", "it yourself repeated", "together", "cheerful. neither it cordial so", "painful picture studied if.", "sex", "him position doubtful", "resolved boy expenses.", "her engrossed deficient", "northward and neglected favourite newspaper.", "but", "use peculiar", "produced concerns ten. maids", "table how", "learn", "drift", "but purse", "stand yet", "set. music me", "house could", "among oh", "as their. piqued", "our", "sister shy nature almost", "his", "wicket.", "hand dear", "so we hour", "to. he", "we be", "hastily", "offence effects", "he service. sympathize", "it projection", "ye insipidity celebrated"]

        const containerEl = document.querySelector('.container')
        const formEl = document.querySelector('#search')
        const dropEl = document.querySelector('.drop')

        // Perform actions with the new input value
    }

    ngAfterViewInit() {

        // const formHandler = (e) => {
        //     const userInput = e.target.value.toLowerCase()

        //     if (userInput.length === 0) {
        //         dropEl.style.height = 0
        //         return dropEl.innerHTML = ''
        //     }

        //     const filteredWords = words.filter(word => word.toLowerCase().includes(userInput)).sort().splice(0, 5)

        //     dropEl.innerHTML = ''
        //     filteredWords.forEach(item => {
        //         const listEl = document.createElement('li')
        //         listEl.textContent = item
        //         if (item === userInput) {
        //             listEl.classList.add('match')
        //         }
        //         dropEl.appendChild(listEl)
        //     })

        //     if (dropEl.children[0] === undefined) {
        //         return dropEl.style.height = 0
        //     }

        //     let totalChildrenHeight = dropEl.children[0].offsetHeight * filteredWords.length
        //     dropEl.style.height = totalChildrenHeight + 'px'

        // }

    }
}
