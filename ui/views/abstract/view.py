from abc import ABC, abstractmethod

import flet

class View(ABC):
    def __init__(self, page: flet.Page):
        self.page = page

    @abstractmethod
    def run(self):
        raise NotImplementedError("Subclasses must implement the run method.")