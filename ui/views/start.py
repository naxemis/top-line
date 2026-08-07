import flet

from ui.views.abstract.view import View

class StartView(View):
    def run(self):
        self.page.add(
            flet.Text("Welcome to the Start Page!")
        )