$(window).on('load', function () {

    fetch("/about-me").then(r => r.json()).then(aboutMe => {
        $("#about-me div.card-title").html(`${aboutMe.firstName} ${aboutMe.lastNane}`)
        $("#about-me div.info").html(aboutMe.description)
        updateSkills("")
    })
})
let skillsConteiner = $('ul#skills')
function updateSkills(query) {
    fetch(`/about-me/skills?q=${query}`).then(r => r.json()).then(skills => {

        skillsConteiner.empty()
        skills.forEach(s => {
            skillsConteiner.append($(`<li>${s}</li>`))
        })
    })
}


$("input#search").on('input', e => {
    let value = $(e.target).val()
    updateSkills(value)
   
})
