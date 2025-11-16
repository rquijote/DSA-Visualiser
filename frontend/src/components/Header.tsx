import '../styles/header.css'
import backBtn from '../assets/left-arrow.png'

function Header({ title }: { title: string }) {
    return <div className="header">
        <img src={backBtn} className='backBtn' alt="back button" title="Icon by Riconsly - Flaticon - https://www.flaticon.com/free-icons/left-button" />
        <h1>{title}</h1>
    </div> 
}

export default Header