export interface Anime {
    id: string
    title: string
    releaseDate: string
    description: string
    authorFirstName: string
    authorLastName: string
    genres: string[]
  }

  export const blankAnime = {
      id: '',
      title: '',
      releaseDate: '',
      description: '',
      authorFirstName: '',
      authorLastName: '',
      genres: []
  }
  