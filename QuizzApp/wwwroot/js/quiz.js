
	function updateInputValue(value) {
		$('#slider-value').text(value)
	}

	$(document).on('click', ".add-answer", function () {
			var answerIndex = $(this).siblings().children('div').children('.answer-input').length
			var questionIndex = $(this).siblings().children('div').children('.question-input').attr('id').charAt(10)
			var $errorMessage = $(this).siblings().children('div').children('.question-error').children('span')

			if ($errorMessage != undefined) {
				$errorMessage.remove()
			}


			var html = '<div class="row mt-2 g-1">\
									<div class="col-11">\
										<input type="text" class="answer-input form-control" placeholder="Add answer" data-val="true" data-val-required="The Answer field is required."\
										id="Questions_' + questionIndex + '__Answers_' + answerIndex + '__AnswerContent"\
										name="Questions[' + questionIndex + '].Answers[' + answerIndex + '].AnswerContent" value="">\
										<span class="answer-error text-danger field-validation-valid" data-valmsg-for="Questions[' + questionIndex + '].Answers[' + answerIndex + '].AnswerContent"\
										data-valmsg-replace="true"></span>\
									</div>\
									<div class="col-1">\
										<input type="checkbox" title="Correct answer" class="is-correct-input col-5" data-val="true" data-val-required="The Correct field is required."\
										id="Questions_' + questionIndex + '__Answers_' + answerIndex + '__IsCorrect"\
										name="Questions[' + questionIndex + '].Answers[' + answerIndex + '].IsCorrect" value="true">\
										<button type="button" class="remove-answer btn btn-primary col-5">-</button>\
									</div>\
								</div>'
			$(this).before(html)

			$("form").removeData("validator")
			$("form").removeData("unobtrusiveValidation")
			$.validator.unobtrusive.parse("form")
		})


	$(document).on('click', ".remove-answer", function () {
		var $answers = $(this).parent().parent().siblings().children('div').children('.answer-input')
		var $spanAlerts = $(this).parent().parent().siblings().children('div').children('.answer-error')
		var $questionCheckboxes = $(this).parent().parent().siblings().children('div').children('.is-correct-input')
		var questionIndex = $(this).parent().parent().siblings().children('div').children('.question-input').attr('id').charAt(10);

		$answers.each(function (index) {
			$(this).attr('id', 'Questions_' + questionIndex + '__Answers_' + index + '__AnswerContent')
			$(this).attr('name', 'Questions[' + questionIndex + '].Answers[' + index + '].AnswerContent')
		})

		$spanAlerts.each(function (index) {
			$(this).attr('data-valmsg-for', 'Questions[' + questionIndex + '].Answers[' + index + '].AnswerContent')
		})

		$questionCheckboxes.each(function (index) {
			$(this).attr('id', 'Questions_' + questionIndex + '__Answers_' + index + '__IsCorrect')
			$(this).attr('name', 'Questions[' + questionIndex + '].Answers[' + index + '].IsCorrect')
		})

		$(this).parent().parent().remove()

		$("form").removeData("validator")
		$("form").removeData("unobtrusiveValidation")
		$.validator.unobtrusive.parse("form")
	})


	$(document).on('click', '.remove-question', function () {
		$(this).parent().parent().parent().remove()

		var $questions = $('.question-input')
		var $questionErrors = $('.question-error')

		$questions.each(function (index) {
			$(this).attr('id', 'Questions_' + index + '__QuestionContent')
			$(this).attr('name', 'Questions[' + index + '].QuestionContent')

			var $questionAnswers = $(this).parent().parent().siblings().children('div').children('.answer-input')
			var $questionAnswersErrors = $(this).parent().parent().siblings().children('div').children('.answer-error')
			var $isAnswerCorrect = $(this).parent().parent().siblings().children('div').children('.is-correct-input')

			$questionAnswers.each(function (jndex) {
				$(this).attr('id', 'Questions_' + index + '__Answers_' + jndex + '__AnswerContent')
				$(this).attr('name', 'Questions[' + index + '].Answers[' + jndex + '].AnswerContent')
			})

			$questionAnswersErrors.each(function (jndex) {
				$(this).attr('data-valmsg-for', 'Questions[' + index + '].Answers[' + jndex + '].AnswerContent')
			})

			$isAnswerCorrect.each(function (jndex) {
				$(this).attr('id', 'Questions_' + index + '__Answers_' + jndex + '__IsCorrect')
				$(this).attr('name', 'Questions[' + index + '].Answers[' + jndex + '].IsCorrect')
			})
		})

		$questionErrors.each(function (index) {
			$(this).attr('data-valmsg-for', 'Questions[' + index + '].QuestionContent')
		})

		$("form").removeData("validator")
		$("form").removeData("unobtrusiveValidation")
		$.validator.unobtrusive.parse("form")
	})


	$("#add-question").click(function () {
		var questionIndex = $('.question-input').length

		var html = '<div class="question container mt-5">\
										<div class="row g-3">\
											<div class="col-11">\
												<input type="text" class="question-input form-control form-control-lg" placeholder="Add question" data-val="true"\
												data-val-required="The Question field is required." id="Questions_' + questionIndex + '__QuestionContent"\
												name="Questions[' + questionIndex + '].QuestionContent" value="" >\
												<span class="question-error text-danger field-validation-error" data-valmsg-for="Questions[' + questionIndex + '].QuestionContent" data-valmsg-replace="true"></span>\
											</div>\
											<div class="col-1">\
												<button type="button" class="remove-question btn btn-lg btn-primary col-11">-</button>\
											</div>\
										</div>\
										<div class="row mt-3 g-1" >\
											<div class="col-11" >\
												<input type="text" class="answer-input form-control" placeholder="Add answer" data-val="true" data-val-required="The Answer field is required."\
												id="Questions_' + questionIndex + '__Answers_0__AnswerContent" name="Questions[' + questionIndex + '].Answers[0].AnswerContent" value="">\
												<span class="answer-error text-danger field-validation-valid" data-valmsg-for="Questions[' + questionIndex + '].Answers[0].AnswerContent" data-valmsg-replace="true"></span>\
											</div>\
											<div class="col-1">\
												<input type="checkbox" title="Correct answer" class="is-correct-input col-5" data-val="true" data-val-required="The Correct field is required."\
												id="Questions_' + questionIndex + '__Answers_0__IsCorrect"\
												name="Questions[' + questionIndex + '].Answers[0].IsCorrect" value="true">\
												<button type="button" class="remove-answer btn btn-primary col-5">-</button>\
											</div>\
										</div>\
										<div class="row mt-2 g-1" >\
											<div class="col-11" >\
												<input type="text" class="answer-input form-control" placeholder="Add answer" data-val="true" data-val-required="The Answer field is required."\
												id="Questions_' + questionIndex + '__Answers_1__AnswerContent" name="Questions[' + questionIndex + '].Answers[1].AnswerContent" value="">\
												<span class="answer-error text-danger field-validation-valid" data-valmsg-for="Questions[' + questionIndex + '].Answers[1].AnswerContent" data-valmsg-replace="true"></span>\
											</div>\
											<div class="col-1">\
												<input type="checkbox" title="Correct answer" class="is-correct-input col-5" data-val="true" data-val-required="The Correct field is required."\
												id="Questions_' + questionIndex + '__Answers_1__IsCorrect"\
												name="Questions[' + questionIndex + '].Answers[1].IsCorrect" value="true">\
												<button type="button" class="remove-answer btn btn-primary col-5">-</button>\
											</div>\
										</div>\
										<button type="button" class="add-answer btn btn-primary mt-2" >+</button>\
									</div>'

		$(".questions").append(html)

		$("form").removeData("validator")
		$("form").removeData("unobtrusiveValidation")
		$.validator.unobtrusive.parse("form")
	})


	$('.create_quiz').click(function (event) {

		var $questions = $(this).parent().siblings().children('.question')


		$questions.each(function (index) {
			var answersNumber = $(this).children('div').children('div').children('.answer-input').length

			if (answersNumber < 2) {

				var html = '<span id="Questions_' + index + '__QuestionContent-error" class="">Question must contains at least two answers.</span>'
				var $questionError = $(this).children('div').children('div').children('.question-error')
				if ($questionError.children('span') != undefined) {
					$questionError.children('span').text('')
				}
				$questionError.append(html)
				event.preventDefault()
			}
		})
	})
