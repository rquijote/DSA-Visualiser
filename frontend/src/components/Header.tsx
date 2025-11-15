import '../styles/header.css'
import backBtn from '../assets/left-arrow.png'

function Header({ title }: { title: string }) {
    return <div className="header">
        <img src={backBtn} className='backBtn' alt="back button" title="Icon by Lizel Arina - Flaticon" />
        <h1>{title}</h1>
    </div> 
}

export default Header